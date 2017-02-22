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
        enum difficulty { easy=30,normal=40,hard=50};
        difficulty diff=difficulty.easy;
        myTextBox[] tb = new myTextBox[81];
        static Random ran = new Random();
        Color[] colorList = new Color[4] { Color.Blue,Color.Red,Color.Green,Color.Purple};

        class myTextBox : TextBox
        {
            const int WM_LBUTTONDBLCLK = 0x0203;
            public event Mydoubleclick MyMousedoubleclick;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_LBUTTONDBLCLK)
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 2, MousePosition.X, MousePosition.Y, 0);
                    if (MyMousedoubleclick != null)
                        MyMousedoubleclick(this, e);
                    return;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            public delegate void Mydoubleclick(object sender, MouseEventArgs e);
        }

        class Coord
        {
            public int x, y;
            public bool direction;

            public Coord(int X=0, int Y=0) { x = X; y = Y; direction = true; }

            public void NextCoord()
            {
                if (y == 9 - 1)
                {
                    x = (x + 1) % 9;
                    y = 0;
                }
                else
                {
                    y = y + 1;
                }
                direction = true;
            }

            public void PrevCoord()
            {
                if (y == 0)
                {
                    x = (9 + x - 1) % 9;
                    y = 9 - 1;
                }
                else
                {
                    y = y - 1;
                }
                direction = false;
            }
        };

        class Cell
        {
            public int value;
            public ArrayList validList;
            public bool isProcessed;
            public bool isLocked;

            public Cell() { value = 0; isProcessed = false; isLocked = false; validList = new ArrayList(); }

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
                isLocked = false;
                validList.Clear();
            }
        };

        Cell[,] cells = new Cell[9, 9];

        public Form1()
        {
            InitializeComponent();
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
            //diff = difficulty.easy;
            for(int i = 0; i < 81; i++)
            {
                tb[i] = new myTextBox();
                tb[i].ReadOnly = true;
                tb[i].BackColor = SystemColors.Control;
                tb[i].Font = new Font("宋体", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                tb[i].Location = new Point(6 + 37 * (i % 9), 32 + 37 * (i / 9));
                tb[i].MaxLength = 1;
                
                tb[i].Width=35;
                tb[i].TabIndex = 83;

                tb[i].TextChanged += textBox_TextChanged;
                tb[i].MyMousedoubleclick += textBox_DoubleClick;
                
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
                textBox.BackColor = (readOnly)?SystemColors.Control:SystemColors.Window;
                textBox.ForeColor = Color.Black;
                textBox.ReadOnly = readOnly;
            }
        }

        private void SingleCheck(object sender)
        {
            foreach (ToolStripMenuItem menuitem in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
                menuitem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void textBox_TextChanged(object sender,EventArgs e)
        {
            if (((TextBox)sender).Text.Length != 0)
                if (((TextBox)sender).Text[0] <= '0' || ((TextBox)sender).Text[0] > '9')
                    ((TextBox)sender).Text = "";
        }

        private void textBox_DoubleClick(object sender,MouseEventArgs e)
        {
            int ind = Array.IndexOf(colorList, ((TextBox)sender).ForeColor);
            if (ind != -1)
                ((TextBox)sender).ForeColor = colorList[(ind + 1) % 4];
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            tbInit();
            Coord coCurrent=new Coord();
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
                        coCurrent.NextCoord();
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
                        coCurrent.PrevCoord();
                    }
                }
                
            }
            HashSet<int> set = new HashSet<int>();
            Random ran = new Random();
            while (set.Count < (int)diff)
                set.Add(ran.Next(81));
            for(int i = 0; i < 81; i++)
            {
                if (!set.Contains(i))
                    tb[i].Text = cells[i / 9, i % 9].value.ToString();
                else
                {
                    tb[i].ReadOnly = false;
                    tb[i].BackColor = SystemColors.Window;
                    tb[i].ForeColor = Color.Blue;
                }
            }
        }

        private int check(bool mode=true)
        {
            
            int[,] mat = new int[9, 9];
            for (int i = 0; i < 81; i++)
            {
                if (tb[i].Text.Count() != 0 && tb[i].Text[0] <= '9' && tb[i].Text[0] > '0')
                {
                    mat[i / 9, i % 9] = tb[i].Text[0] - '0';
                }
                else
                {
                    if (mode)
                    {
                        MessageBox.Show("未完成！");
                        return -2;
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                bool[] flag = new bool[9] { false, false, false, false, false, false, false, false, false };
                bool[] flagt = new bool[9] { false, false, false, false, false, false, false, false, false };
                bool[] flagb = new bool[9] { false, false, false, false, false, false, false, false, false };

                for (int j = 0; j < 9; j++)
                {
                    if (mat[i, j] != 0)
                        if (flag[mat[i, j] - 1])
                        {
                            MessageBox.Show("有错误！");
                            return -1;
                        }
                        else
                        {
                            flag[mat[i, j] - 1] = true;
                        }

                    if (mat[j, i] != 0)
                        if (flagt[mat[j, i] - 1])
                        {
                            MessageBox.Show("有错误！");
                            return -1;
                        }
                        else
                        {
                            flagt[mat[j, i] - 1] = true;
                        }

                    if (mat[i - i % 3 + j / 3, (i % 3) * 3 + j % 3] != 0)
                        if (flagb[mat[i - i % 3 + j / 3, (i % 3) * 3 + j % 3] - 1])
                        {
                            MessageBox.Show("有错误！");
                            return -1;
                        }
                        else
                        {
                            flagb[mat[i - i % 3 + j / 3, (i % 3) * 3 + j % 3] - 1] = true;
                        }
                }
            }
            if(mode)
                MessageBox.Show("完成！");
            return 0;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            check();
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItemGen.Checked == true)
            {
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
            else if(check(false)==0)
            {
                for (int i = 0; i < 81; i++)
                {
                    cells[i / 9, i % 9].Clear();
                    if (tb[i].Text!="")
                    {
                        cells[i / 9, i % 9].value= tb[i].Text[0]-'0';
                        cells[i / 9, i % 9].isProcessed = true;
                        cells[i / 9, i % 9].isLocked = true;
                    }
                }
                Coord coCurrent = new Coord();
                while (true)
                {
                    Cell c = cells[coCurrent.x, coCurrent.y];
                    ArrayList al = new ArrayList();

                    if (!c.isLocked)
                    {
                        if (!c.isProcessed)
                        {
                            al = GetValidValueList(coCurrent);
                            c.validList = al;

                        }

                        if (c.validList.Count > 0)
                        {
                            c.PickNextValidValue();
                            if (coCurrent.x == m_size - 1 && coCurrent.y == m_size - 1)
                            {
                                break;
                            }
                            else
                            {
                                coCurrent.NextCoord();
                            }

                        }
                        else
                        {
                            if (coCurrent.x == 0 && coCurrent.y == 0)
                            {
                                break;
                            }
                            else
                            {
                                c.Clear();
                                coCurrent.PrevCoord();
                            }
                        }
                    }
                    else
                    {
                        if (coCurrent.direction)
                        {
                            if (coCurrent.x == 8 && coCurrent.y == 8)
                                break;
                            coCurrent.NextCoord();
                        }
                        else
                        {
                            if (coCurrent.x == 0 && coCurrent.y == 0)
                            {
                                MessageBox.Show("无法生成！");
                                return;
                            }
                            coCurrent.PrevCoord();
                        }
                    }
                }
                for (int i = 0; i < 81; i++)
                {
                    if (!cells[i/9,i%9].isLocked)
                        tb[i].Text = cells[i / 9, i % 9].value.ToString();
                }
            }
        }

        private void ToolStripMenuItemGen_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItemGen.Checked == true)
                return;
            SingleCheck(sender);
            tbInit();
            buttonCheck.Visible = true;
            buttonGenerate.Visible = true;
            buttonClear.Visible = false;
        }

        private void ToolStripMenuItemSolve_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItemSolve.Checked == true)
                return;
            SingleCheck(sender);
            tbInit(false);
            buttonCheck.Visible = false;
            buttonGenerate.Visible = false;
            buttonClear.Visible = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tbInit(false);
            foreach (Cell cell in cells)
                cell.Clear();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
            diff = difficulty.easy;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
            diff = difficulty.normal;
        }

        private void difficultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
            diff = difficulty.hard;
        }
    }
}
