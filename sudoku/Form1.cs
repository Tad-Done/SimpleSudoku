using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {
        int m_size = 9;
        TextBox[] tb = new TextBox[81];
        static Random ran = new Random();

        class Coord
        {
            public int x, y;

        };

        class Cell
        {
            public int value;
            public ArrayList validList;
            public bool isProcessed;

            public Cell() { isProcessed = false; }

            public void PickNextValidValue()
            {
                
                int i = ran.Next(validList.Count);
                value = (int)validList[i];
                validList.RemoveAt(i);
                isProcessed = true;
            }

            public void Clear()
            {
                value = 0;
                isProcessed = false;
            }
        };

        Cell[,] cells = new Cell[9, 9];

        public Form1()
        {
            InitializeComponent();
        }

        Coord NextCoord(Coord co)
        {
            Coord ret=new Coord();
            if (co.y == m_size - 1)
            {
                ret.x = (co.x + 1) % 9;
                ret.y = 0;
            }
            else
            {
                ret.y = co.y + 1;
                ret.x = co.x;
            }
            return ret;
        }

        Coord PrevCoord(Coord co)
        {
            Coord ret = new Coord();
            if (co.y == 0)
            {
                ret.x = (m_size+co.x - 1) % m_size;
                ret.y = m_size-1;
            }
            else
            {
                ret.y = co.y - 1;
                ret.x = co.x;
            }
            return ret;
        }

        ArrayList GetValidValueList(Coord co)
        {
            ArrayList ret = new ArrayList();
            for (int i = 1; i <= m_size; i++)
                ret.Add(i);
            for (int i = 0; i < m_size; i++)
            {
                if (ret.Count == 0) break;
                if (cells[i, co.y].isProcessed)
                {
                    if (ret.IndexOf(cells[i, co.y].value) != -1)
                        ret.Remove(cells[i, co.y].value);
                }
            }
            for (int i = 0; i < m_size; i++)
            {
                if (cells[co.x, i].isProcessed)
                {
                    if (ret.Count == 0) break;
                    if (ret.IndexOf(cells[co.x, i].value) != -1)
                        ret.Remove(cells[co.x, i].value);
                }
            }
            for (int i = co.x- co.x % 3; i <co.x- co.x % 3 + 3; i++) 
                for(int j =co.y- co.y % 3; j <co.y- co.y % 3 + 3; j++)
                {
                    if (ret.Count == 0) break;
                    if (cells[i, j].isProcessed)
                    {
                        if (ret.IndexOf(cells[i, j].value) != -1)
                            ret.Remove(cells[i, j].value);
                    }
                }
            return ret;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for(int i = 0; i < 81; i++)
            {
                tb[i] = new TextBox();
                tb[i].ReadOnly = true;
                tb[i].BackColor = SystemColors.Control;
                tb[i].Font = new Font("宋体", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                tb[i].Location = new Point(6 + 37 * (i % 9), 32 + 37 * (i / 9));
                tb[i].MaxLength = 1;
                
                tb[i].Width=35;
                tb[i].TabIndex = 83;

                tb[i].TextChanged += textBox_TextChanged;
                
                Controls.Add(tb[i]);
                cells[i % 9, i / 9] = new Cell();
                //tb[i].DataBindings.Add("Text", cells[i % 9, i / 9], "value");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            for (int i = 0; i < 9; i++)
            {
                g.DrawRectangle(Pens.Black, 5+37*3*(i/3), 31+37*3*(i%3),37*3-1, 37*3-1);
            }
        }

        private void tbInit(bool readOnly=true)
        {
            foreach(TextBox textBox in tb)
            {
                textBox.Text = "";
                textBox.BackColor = SystemColors.Control;
                textBox.ForeColor = Color.Black;
                textBox.ReadOnly = readOnly;
            }
        }

        private void SingleCheck(object sender)
        {
            foreach (ToolStripMenuItem menuitem in ToolStripMenuItemMode.DropDownItems)
                menuitem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void textBox_TextChanged(object sender,EventArgs e)
        {
            if (((TextBox)sender).Text.Length != 0)
                if (((TextBox)sender).Text[0] < '0' || ((TextBox)sender).Text[0] > '9')
                    ((TextBox)sender).Text = "";
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            tbInit();
            Coord coCurrent=new Coord();
            coCurrent.x = 0;
            coCurrent.y = 0;
            foreach (Cell cell in cells)
                cell.Clear();
            while (true)
            {
                Cell c = cells[coCurrent.x,coCurrent.y];
                ArrayList al = new ArrayList();

                if (!c.isProcessed)
                {
                    al = GetValidValueList(coCurrent);
                    c.validList = al;

                }

                if(c.validList.Count>0)
                {
                    c.PickNextValidValue();
                    if (coCurrent.x == m_size - 1 && coCurrent.y == m_size - 1)
                    {
                        break;
                    }
                    else
                    {
                        coCurrent = NextCoord(coCurrent);
                    }

                }
                else
                {
                    if(coCurrent.x==0&&coCurrent.y==0)
                    {
                        break;
                    }
                    else
                    {
                        c.Clear();
                        coCurrent = PrevCoord(coCurrent);
                    }
                }
                
            }
            ArrayList arr = new ArrayList();
            Random ran = new Random();
            for(int i = 0; i < 60; i++)
            {
                arr.Add(ran.Next(81));
            }
            for(int i = 0; i < 81; i++)
            {
                if (arr.IndexOf(i) == -1)
                    tb[i].Text = cells[i / 9, i % 9].value.ToString();
                else
                {
                    tb[i].ReadOnly = false;
                    tb[i].BackColor = SystemColors.Window;
                    tb[i].ForeColor = Color.Blue;
                }
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            int[,] mat = new int[9, 9];
            for (int i = 0; i < 81; i++) 
            {
                if(tb[i].Text.Count()!=0 &&tb[i].Text[0] <= '9'&& tb[i].Text[0] > '0')
                {
                    mat[i / 9, i % 9] = tb[i].Text[0] - '0';
                }
                else
                {
                    MessageBox.Show("未完成！");
                    return;
                }
            }
            for(int i = 0; i < 9; i++)
            {
                bool[] flag = new bool[9] { false , false , false , false , false , false , false , false, false };
                bool[] flagt = new bool[9] { false, false, false, false, false, false, false, false, false };
                bool[] flagb = new bool[9] { false, false, false, false, false, false, false, false, false };

                for (int j = 0; j < 9; j++)
                {
                    if (flag[mat[i, j]-1])
                    {
                        MessageBox.Show("有错误！");
                        return;
                    }
                    else
                    {
                        flag[mat[i,j]-1] = true;
                    }

                    if (flagt[mat[j,i]-1])
                    {
                        MessageBox.Show("有错误！");
                        return;
                    }
                    else
                    {
                        flagt[mat[j,i]-1] = true;
                    }

                    if (flagb[mat[i - i % 3 + j / 3, (i % 3) * 3 + j % 3] - 1])
                    {
                        MessageBox.Show("有错误！");
                        return;
                    }
                    else
                    {
                        flagb[mat[i - i % 3 + j / 3, (i % 3) * 3 + j % 3] - 1] = true;
                    }
                }
            }
            MessageBox.Show("完成！");
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            //tbInit();
            for (int i = 0; i < 81; i++)
            {
                if (cells[i / 9, i % 9].isProcessed)
                {
                    tb[i].Text = cells[i / 9, i % 9].value.ToString();
                    tb[i].ReadOnly = true;
                }
                else
                {
                    return;
                }
            }
        }

        private void ToolStripMenuItemGen_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }

        private void ToolStripMenuItemSolve_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }
    }
}
