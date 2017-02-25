namespace sudoku
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMode = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.难度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.蓝色格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.红色格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绿色格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.紫色格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(200, 599);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(114, 44);
            this.buttonCheck.TabIndex = 81;
            this.buttonCheck.Text = "检查";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(12, 599);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(114, 44);
            this.buttonGenerate.TabIndex = 82;
            this.buttonGenerate.Text = "新游戏";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonAnswer
            // 
            this.buttonAnswer.Location = new System.Drawing.Point(387, 599);
            this.buttonAnswer.Name = "buttonAnswer";
            this.buttonAnswer.Size = new System.Drawing.Size(114, 44);
            this.buttonAnswer.TabIndex = 83;
            this.buttonAnswer.Text = "解答";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMode,
            this.难度ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 32);
            this.menuStrip1.TabIndex = 84;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMode
            // 
            this.ToolStripMenuItemMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemGen,
            this.ToolStripMenuItemSolve});
            this.ToolStripMenuItemMode.Name = "ToolStripMenuItemMode";
            this.ToolStripMenuItemMode.Size = new System.Drawing.Size(58, 28);
            this.ToolStripMenuItemMode.Text = "模式";
            // 
            // ToolStripMenuItemGen
            // 
            this.ToolStripMenuItemGen.Checked = true;
            this.ToolStripMenuItemGen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItemGen.Name = "ToolStripMenuItemGen";
            this.ToolStripMenuItemGen.Size = new System.Drawing.Size(165, 30);
            this.ToolStripMenuItemGen.Text = "随机生成";
            this.ToolStripMenuItemGen.Click += new System.EventHandler(this.ToolStripMenuItemGen_Click);
            // 
            // ToolStripMenuItemSolve
            // 
            this.ToolStripMenuItemSolve.Name = "ToolStripMenuItemSolve";
            this.ToolStripMenuItemSolve.Size = new System.Drawing.Size(165, 30);
            this.ToolStripMenuItemSolve.Text = "解答模式";
            this.ToolStripMenuItemSolve.Click += new System.EventHandler(this.ToolStripMenuItemSolve_Click);
            // 
            // 难度ToolStripMenuItem
            // 
            this.难度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.难度ToolStripMenuItem.Name = "难度ToolStripMenuItem";
            this.难度ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.难度ToolStripMenuItem.Text = "难度";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Checked = true;
            this.easyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.easyToolStripMenuItem.Text = "easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.easyToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.normalToolStripMenuItem.Text = "normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.hardToolStripMenuItem.Text = "hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.difficultToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.蓝色格ToolStripMenuItem,
            this.红色格ToolStripMenuItem,
            this.绿色格ToolStripMenuItem,
            this.紫色格ToolStripMenuItem});
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(129, 30);
            this.清除ToolStripMenuItem.Text = "清除";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 30);
            this.toolStripMenuItem1.Text = "所有格";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 蓝色格ToolStripMenuItem
            // 
            this.蓝色格ToolStripMenuItem.Name = "蓝色格ToolStripMenuItem";
            this.蓝色格ToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.蓝色格ToolStripMenuItem.Text = "蓝色格";
            this.蓝色格ToolStripMenuItem.Click += new System.EventHandler(this.蓝色格ToolStripMenuItem_Click);
            // 
            // 红色格ToolStripMenuItem
            // 
            this.红色格ToolStripMenuItem.Name = "红色格ToolStripMenuItem";
            this.红色格ToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.红色格ToolStripMenuItem.Text = "红色格";
            this.红色格ToolStripMenuItem.Click += new System.EventHandler(this.红色格ToolStripMenuItem_Click);
            // 
            // 绿色格ToolStripMenuItem
            // 
            this.绿色格ToolStripMenuItem.Name = "绿色格ToolStripMenuItem";
            this.绿色格ToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.绿色格ToolStripMenuItem.Text = "绿色格";
            this.绿色格ToolStripMenuItem.Click += new System.EventHandler(this.绿色格ToolStripMenuItem_Click);
            // 
            // 紫色格ToolStripMenuItem
            // 
            this.紫色格ToolStripMenuItem.Name = "紫色格ToolStripMenuItem";
            this.紫色格ToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.紫色格ToolStripMenuItem.Text = "紫色格";
            this.紫色格ToolStripMenuItem.Click += new System.EventHandler(this.紫色格ToolStripMenuItem_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 599);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(114, 44);
            this.buttonClear.TabIndex = 85;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Visible = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(226, 568);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(71, 18);
            this.labelTimer.TabIndex = 86;
            this.labelTimer.Text = "0:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 656);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "数独";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMode;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSolve;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ToolStripMenuItem 难度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 蓝色格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 红色格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绿色格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 紫色格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label labelTimer;
    }
}

