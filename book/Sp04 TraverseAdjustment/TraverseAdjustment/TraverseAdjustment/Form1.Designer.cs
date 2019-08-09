namespace TraverseAdjustment
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开数据文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存报告ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存BMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存DXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算方位角ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标近似平差ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导线略图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据表格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.导线图形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.计算CToolStripMenuItem,
            this.查看VToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开数据文件ToolStripMenuItem,
            this.保存报告ToolStripMenuItem,
            this.保存报告ToolStripMenuItem1,
            this.保存BMPToolStripMenuItem,
            this.保存DXFToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开数据文件ToolStripMenuItem
            // 
            this.打开数据文件ToolStripMenuItem.Name = "打开数据文件ToolStripMenuItem";
            this.打开数据文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开数据文件ToolStripMenuItem.Text = "打开数据文件";
            this.打开数据文件ToolStripMenuItem.Click += new System.EventHandler(this.打开数据文件ToolStripMenuItem_Click);
            // 
            // 保存报告ToolStripMenuItem
            // 
            this.保存报告ToolStripMenuItem.Name = "保存报告ToolStripMenuItem";
            this.保存报告ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存报告ToolStripMenuItem.Text = "保存导线表";
            // 
            // 保存报告ToolStripMenuItem1
            // 
            this.保存报告ToolStripMenuItem1.Name = "保存报告ToolStripMenuItem1";
            this.保存报告ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.保存报告ToolStripMenuItem1.Text = "保存报告";
            this.保存报告ToolStripMenuItem1.Click += new System.EventHandler(this.保存报告ToolStripMenuItem1_Click);
            // 
            // 保存BMPToolStripMenuItem
            // 
            this.保存BMPToolStripMenuItem.Name = "保存BMPToolStripMenuItem";
            this.保存BMPToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存BMPToolStripMenuItem.Text = "保存BMP";
            this.保存BMPToolStripMenuItem.Click += new System.EventHandler(this.保存BMPToolStripMenuItem_Click);
            // 
            // 保存DXFToolStripMenuItem
            // 
            this.保存DXFToolStripMenuItem.Name = "保存DXFToolStripMenuItem";
            this.保存DXFToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存DXFToolStripMenuItem.Text = "保存DXF";
            this.保存DXFToolStripMenuItem.Click += new System.EventHandler(this.保存DXFToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 计算CToolStripMenuItem
            // 
            this.计算CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算方位角ToolStripMenuItem,
            this.坐标近似平差ToolStripMenuItem});
            this.计算CToolStripMenuItem.Name = "计算CToolStripMenuItem";
            this.计算CToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.计算CToolStripMenuItem.Text = "计算(&C)";
            // 
            // 计算方位角ToolStripMenuItem
            // 
            this.计算方位角ToolStripMenuItem.Name = "计算方位角ToolStripMenuItem";
            this.计算方位角ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.计算方位角ToolStripMenuItem.Text = "角度近似平差";
            this.计算方位角ToolStripMenuItem.Click += new System.EventHandler(this.计算方位角ToolStripMenuItem_Click);
            // 
            // 坐标近似平差ToolStripMenuItem
            // 
            this.坐标近似平差ToolStripMenuItem.Name = "坐标近似平差ToolStripMenuItem";
            this.坐标近似平差ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.坐标近似平差ToolStripMenuItem.Text = "坐标近似平差";
            this.坐标近似平差ToolStripMenuItem.Click += new System.EventHandler(this.坐标近似平差ToolStripMenuItem_Click);
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导线略图ToolStripMenuItem,
            this.计算报告ToolStripMenuItem,
            this.数据表格ToolStripMenuItem,
            this.导线图形ToolStripMenuItem});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.查看VToolStripMenuItem.Text = "查看(&V)";
            // 
            // 导线略图ToolStripMenuItem
            // 
            this.导线略图ToolStripMenuItem.Name = "导线略图ToolStripMenuItem";
            this.导线略图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导线略图ToolStripMenuItem.Text = "导线略图";
            this.导线略图ToolStripMenuItem.Click += new System.EventHandler(this.导线略图ToolStripMenuItem_Click);
            // 
            // 计算报告ToolStripMenuItem
            // 
            this.计算报告ToolStripMenuItem.Name = "计算报告ToolStripMenuItem";
            this.计算报告ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.计算报告ToolStripMenuItem.Text = "计算报告";
            this.计算报告ToolStripMenuItem.Click += new System.EventHandler(this.计算报告ToolStripMenuItem_Click);
            // 
            // 数据表格ToolStripMenuItem
            // 
            this.数据表格ToolStripMenuItem.Name = "数据表格ToolStripMenuItem";
            this.数据表格ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据表格ToolStripMenuItem.Text = "数据表格";
            this.数据表格ToolStripMenuItem.Click += new System.EventHandler(this.数据表格ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 319);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(718, 287);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图形";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(718, 287);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(724, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "报告";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(718, 287);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(724, 293);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "图形";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Location = new System.Drawing.Point(18, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // 导线图形ToolStripMenuItem
            // 
            this.导线图形ToolStripMenuItem.Name = "导线图形ToolStripMenuItem";
            this.导线图形ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导线图形ToolStripMenuItem.Text = "导线图形";
            this.导线图形ToolStripMenuItem.Click += new System.EventHandler(this.导线图形ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 369);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TraverseAdjustment";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开数据文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存报告ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存BMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存DXFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算方位角ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标近似平差ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导线略图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 数据表格ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 导线图形ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

