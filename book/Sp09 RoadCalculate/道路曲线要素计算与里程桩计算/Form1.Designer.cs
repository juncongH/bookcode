namespace 道路曲线要素计算与里程桩计算
{
    partial class ZHX
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
            this.JDX = new System.Windows.Forms.Label();
            this.JDY = new System.Windows.Forms.Label();
            this.JDX_V = new System.Windows.Forms.TextBox();
            this.JDY_V = new System.Windows.Forms.TextBox();
            this.ROTATE = new System.Windows.Forms.Label();
            this.ROTATE_V_D = new System.Windows.Forms.TextBox();
            this.HCLENGTH = new System.Windows.Forms.Label();
            this.HCLENGTH_V = new System.Windows.Forms.TextBox();
            this.DIR_RIGHT = new System.Windows.Forms.RadioButton();
            this.DIR_LEFT = new System.Windows.Forms.RadioButton();
            this.KJD = new System.Windows.Forms.Label();
            this.KJD_V = new System.Windows.Forms.TextBox();
            this.danwei1 = new System.Windows.Forms.Label();
            this.danwei3 = new System.Windows.Forms.Label();
            this.danwei2 = new System.Windows.Forms.Label();
            this.ROTATE_V_F = new System.Windows.Forms.TextBox();
            this.ROTATE_V_M = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.RADIUS = new System.Windows.Forms.Label();
            this.RADIUS_V = new System.Windows.Forms.TextBox();
            this.KI = new System.Windows.Forms.Label();
            this.KI_V = new System.Windows.Forms.TextBox();
            this.ZH = new System.Windows.Forms.Label();
            this.ZHY = new System.Windows.Forms.Label();
            this.ZHX_V = new System.Windows.Forms.TextBox();
            this.ZHY_V = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // JDX
            // 
            this.JDX.AutoSize = true;
            this.JDX.Location = new System.Drawing.Point(36, 137);
            this.JDX.Name = "JDX";
            this.JDX.Size = new System.Drawing.Size(76, 15);
            this.JDX.TabIndex = 8;
            this.JDX.Text = "JD点X坐标";
            // 
            // JDY
            // 
            this.JDY.AutoSize = true;
            this.JDY.Location = new System.Drawing.Point(36, 179);
            this.JDY.Name = "JDY";
            this.JDY.Size = new System.Drawing.Size(76, 15);
            this.JDY.TabIndex = 9;
            this.JDY.Text = "JD点Y坐标";
            // 
            // JDX_V
            // 
            this.JDX_V.Location = new System.Drawing.Point(155, 132);
            this.JDX_V.Name = "JDX_V";
            this.JDX_V.Size = new System.Drawing.Size(255, 25);
            this.JDX_V.TabIndex = 2;
            // 
            // JDY_V
            // 
            this.JDY_V.Location = new System.Drawing.Point(155, 174);
            this.JDY_V.Name = "JDY_V";
            this.JDY_V.Size = new System.Drawing.Size(255, 25);
            this.JDY_V.TabIndex = 3;
            // 
            // ROTATE
            // 
            this.ROTATE.AutoSize = true;
            this.ROTATE.Location = new System.Drawing.Point(56, 222);
            this.ROTATE.Name = "ROTATE";
            this.ROTATE.Size = new System.Drawing.Size(37, 15);
            this.ROTATE.TabIndex = 10;
            this.ROTATE.Text = "转角";
            // 
            // ROTATE_V_D
            // 
            this.ROTATE_V_D.Location = new System.Drawing.Point(155, 215);
            this.ROTATE_V_D.Name = "ROTATE_V_D";
            this.ROTATE_V_D.Size = new System.Drawing.Size(53, 25);
            this.ROTATE_V_D.TabIndex = 4;
            // 
            // HCLENGTH
            // 
            this.HCLENGTH.AutoSize = true;
            this.HCLENGTH.Location = new System.Drawing.Point(33, 305);
            this.HCLENGTH.Name = "HCLENGTH";
            this.HCLENGTH.Size = new System.Drawing.Size(97, 15);
            this.HCLENGTH.TabIndex = 11;
            this.HCLENGTH.Text = "缓冲曲线长度";
            // 
            // HCLENGTH_V
            // 
            this.HCLENGTH_V.Location = new System.Drawing.Point(155, 300);
            this.HCLENGTH_V.Name = "HCLENGTH_V";
            this.HCLENGTH_V.Size = new System.Drawing.Size(255, 25);
            this.HCLENGTH_V.TabIndex = 8;
            // 
            // DIR_RIGHT
            // 
            this.DIR_RIGHT.AutoSize = true;
            this.DIR_RIGHT.Location = new System.Drawing.Point(38, 434);
            this.DIR_RIGHT.Name = "DIR_RIGHT";
            this.DIR_RIGHT.Size = new System.Drawing.Size(73, 19);
            this.DIR_RIGHT.TabIndex = 11;
            this.DIR_RIGHT.TabStop = true;
            this.DIR_RIGHT.Text = "右偏向";
            this.DIR_RIGHT.UseVisualStyleBackColor = true;
            // 
            // DIR_LEFT
            // 
            this.DIR_LEFT.AutoSize = true;
            this.DIR_LEFT.Location = new System.Drawing.Point(155, 434);
            this.DIR_LEFT.Name = "DIR_LEFT";
            this.DIR_LEFT.Size = new System.Drawing.Size(73, 19);
            this.DIR_LEFT.TabIndex = 12;
            this.DIR_LEFT.TabStop = true;
            this.DIR_LEFT.Text = "左偏向";
            this.DIR_LEFT.UseVisualStyleBackColor = true;
            // 
            // KJD
            // 
            this.KJD.AutoSize = true;
            this.KJD.Location = new System.Drawing.Point(41, 348);
            this.KJD.Name = "KJD";
            this.KJD.Size = new System.Drawing.Size(67, 15);
            this.KJD.TabIndex = 0;
            this.KJD.Text = "交点里程";
            // 
            // KJD_V
            // 
            this.KJD_V.Location = new System.Drawing.Point(155, 343);
            this.KJD_V.Name = "KJD_V";
            this.KJD_V.Size = new System.Drawing.Size(255, 25);
            this.KJD_V.TabIndex = 9;
            // 
            // danwei1
            // 
            this.danwei1.AutoSize = true;
            this.danwei1.Location = new System.Drawing.Point(214, 219);
            this.danwei1.Name = "danwei1";
            this.danwei1.Size = new System.Drawing.Size(22, 15);
            this.danwei1.TabIndex = 12;
            this.danwei1.Text = "度";
            // 
            // danwei3
            // 
            this.danwei3.AutoSize = true;
            this.danwei3.Location = new System.Drawing.Point(388, 219);
            this.danwei3.Name = "danwei3";
            this.danwei3.Size = new System.Drawing.Size(22, 15);
            this.danwei3.TabIndex = 13;
            this.danwei3.Text = "秒";
            // 
            // danwei2
            // 
            this.danwei2.AutoSize = true;
            this.danwei2.Location = new System.Drawing.Point(301, 219);
            this.danwei2.Name = "danwei2";
            this.danwei2.Size = new System.Drawing.Size(22, 15);
            this.danwei2.TabIndex = 14;
            this.danwei2.Text = "分";
            // 
            // ROTATE_V_F
            // 
            this.ROTATE_V_F.Location = new System.Drawing.Point(242, 215);
            this.ROTATE_V_F.Name = "ROTATE_V_F";
            this.ROTATE_V_F.Size = new System.Drawing.Size(53, 25);
            this.ROTATE_V_F.TabIndex = 5;
            // 
            // ROTATE_V_M
            // 
            this.ROTATE_V_M.Location = new System.Drawing.Point(329, 215);
            this.ROTATE_V_M.Name = "ROTATE_V_M";
            this.ROTATE_V_M.Size = new System.Drawing.Size(53, 25);
            this.ROTATE_V_M.TabIndex = 6;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(106, 481);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(102, 37);
            this.submit.TabIndex = 13;
            this.submit.Text = "确定";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // RADIUS
            // 
            this.RADIUS.AutoSize = true;
            this.RADIUS.Location = new System.Drawing.Point(56, 262);
            this.RADIUS.Name = "RADIUS";
            this.RADIUS.Size = new System.Drawing.Size(37, 15);
            this.RADIUS.TabIndex = 15;
            this.RADIUS.Text = "半径";
            // 
            // RADIUS_V
            // 
            this.RADIUS_V.Location = new System.Drawing.Point(155, 257);
            this.RADIUS_V.Name = "RADIUS_V";
            this.RADIUS_V.Size = new System.Drawing.Size(256, 25);
            this.RADIUS_V.TabIndex = 7;
            // 
            // KI
            // 
            this.KI.AutoSize = true;
            this.KI.Location = new System.Drawing.Point(33, 391);
            this.KI.Name = "KI";
            this.KI.Size = new System.Drawing.Size(82, 15);
            this.KI.TabIndex = 17;
            this.KI.Text = "目标点里程";
            // 
            // KI_V
            // 
            this.KI_V.Location = new System.Drawing.Point(155, 386);
            this.KI_V.Name = "KI_V";
            this.KI_V.Size = new System.Drawing.Size(257, 25);
            this.KI_V.TabIndex = 10;
            // 
            // ZH
            // 
            this.ZH.AutoSize = true;
            this.ZH.Location = new System.Drawing.Point(37, 53);
            this.ZH.Name = "ZH";
            this.ZH.Size = new System.Drawing.Size(75, 15);
            this.ZH.TabIndex = 19;
            this.ZH.Text = "起点X坐标";
            // 
            // ZHY
            // 
            this.ZHY.AutoSize = true;
            this.ZHY.Location = new System.Drawing.Point(37, 95);
            this.ZHY.Name = "ZHY";
            this.ZHY.Size = new System.Drawing.Size(75, 15);
            this.ZHY.TabIndex = 20;
            this.ZHY.Text = "起点Y坐标";
            // 
            // ZHX_V
            // 
            this.ZHX_V.Location = new System.Drawing.Point(155, 48);
            this.ZHX_V.Name = "ZHX_V";
            this.ZHX_V.Size = new System.Drawing.Size(255, 25);
            this.ZHX_V.TabIndex = 0;
            // 
            // ZHY_V
            // 
            this.ZHY_V.Location = new System.Drawing.Point(155, 90);
            this.ZHY_V.Name = "ZHY_V";
            this.ZHY_V.Size = new System.Drawing.Size(255, 25);
            this.ZHY_V.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.导入文件ToolStripMenuItem.Text = "导入文件";
            this.导入文件ToolStripMenuItem.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ZHX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 547);
            this.Controls.Add(this.ZHY_V);
            this.Controls.Add(this.ZHX_V);
            this.Controls.Add(this.ZHY);
            this.Controls.Add(this.ZH);
            this.Controls.Add(this.KI_V);
            this.Controls.Add(this.KI);
            this.Controls.Add(this.RADIUS_V);
            this.Controls.Add(this.RADIUS);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.ROTATE_V_M);
            this.Controls.Add(this.ROTATE_V_F);
            this.Controls.Add(this.danwei2);
            this.Controls.Add(this.danwei3);
            this.Controls.Add(this.danwei1);
            this.Controls.Add(this.KJD_V);
            this.Controls.Add(this.KJD);
            this.Controls.Add(this.DIR_LEFT);
            this.Controls.Add(this.DIR_RIGHT);
            this.Controls.Add(this.HCLENGTH_V);
            this.Controls.Add(this.HCLENGTH);
            this.Controls.Add(this.ROTATE_V_D);
            this.Controls.Add(this.ROTATE);
            this.Controls.Add(this.JDY_V);
            this.Controls.Add(this.JDX_V);
            this.Controls.Add(this.JDY);
            this.Controls.Add(this.JDX);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ZHX";
            this.Text = "道路曲线要素与里程桩计算应用程序";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label JDX;
        private System.Windows.Forms.Label JDY;
        private System.Windows.Forms.TextBox JDX_V;
        private System.Windows.Forms.TextBox JDY_V;
        private System.Windows.Forms.Label ROTATE;
        private System.Windows.Forms.TextBox ROTATE_V_D;
        private System.Windows.Forms.Label HCLENGTH;
        private System.Windows.Forms.TextBox HCLENGTH_V;
        private System.Windows.Forms.RadioButton DIR_RIGHT;
        private System.Windows.Forms.RadioButton DIR_LEFT;
        private System.Windows.Forms.Label KJD;
        private System.Windows.Forms.TextBox KJD_V;
        private System.Windows.Forms.Label danwei1;
        private System.Windows.Forms.Label danwei3;
        private System.Windows.Forms.Label danwei2;
        private System.Windows.Forms.TextBox ROTATE_V_F;
        private System.Windows.Forms.TextBox ROTATE_V_M;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label RADIUS;
        private System.Windows.Forms.TextBox RADIUS_V;
        private System.Windows.Forms.Label KI;
        private System.Windows.Forms.TextBox KI_V;
        private System.Windows.Forms.Label ZH;
        private System.Windows.Forms.Label ZHY;
        private System.Windows.Forms.TextBox ZHX_V;
        private System.Windows.Forms.TextBox ZHY_V;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

