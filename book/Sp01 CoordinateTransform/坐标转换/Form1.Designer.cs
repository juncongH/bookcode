namespace 坐标转换
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1_Z = new System.Windows.Forms.TextBox();
            this.textBox1_Y = new System.Windows.Forms.TextBox();
            this.textBox1_X = new System.Windows.Forms.TextBox();
            this.label1_Z = new System.Windows.Forms.Label();
            this.label1_Y = new System.Windows.Forms.Label();
            this.label1_X = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1_H = new System.Windows.Forms.Label();
            this.label1_L = new System.Windows.Forms.Label();
            this.label1_B = new System.Windows.Forms.Label();
            this.textBox1_H = new System.Windows.Forms.TextBox();
            this.textBox1_L = new System.Windows.Forms.TextBox();
            this.textBox1_B = new System.Windows.Forms.TextBox();
            this.textBox1_f = new System.Windows.Forms.TextBox();
            this.textBox1_a = new System.Windows.Forms.TextBox();
            this.label1_f = new System.Windows.Forms.Label();
            this.label1_a = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2_L = new System.Windows.Forms.TextBox();
            this.textBox2_H = new System.Windows.Forms.TextBox();
            this.textBox2_Z = new System.Windows.Forms.TextBox();
            this.textBox2_B = new System.Windows.Forms.TextBox();
            this.textBox2_X = new System.Windows.Forms.TextBox();
            this.textBox2_Y = new System.Windows.Forms.TextBox();
            this.textBox2_f = new System.Windows.Forms.TextBox();
            this.textBox2_a = new System.Windows.Forms.TextBox();
            this.label2_H = new System.Windows.Forms.Label();
            this.label2_L = new System.Windows.Forms.Label();
            this.label2_B = new System.Windows.Forms.Label();
            this.label2_Z = new System.Windows.Forms.Label();
            this.label2_Y = new System.Windows.Forms.Label();
            this.label2_X = new System.Windows.Forms.Label();
            this.label2_f = new System.Windows.Forms.Label();
            this.label2_a = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.导入文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointinfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(673, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1_Z);
            this.tabPage1.Controls.Add(this.textBox1_Y);
            this.tabPage1.Controls.Add(this.textBox1_X);
            this.tabPage1.Controls.Add(this.label1_Z);
            this.tabPage1.Controls.Add(this.label1_Y);
            this.tabPage1.Controls.Add(this.label1_X);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1_H);
            this.tabPage1.Controls.Add(this.label1_L);
            this.tabPage1.Controls.Add(this.label1_B);
            this.tabPage1.Controls.Add(this.textBox1_H);
            this.tabPage1.Controls.Add(this.textBox1_L);
            this.tabPage1.Controls.Add(this.textBox1_B);
            this.tabPage1.Controls.Add(this.textBox1_f);
            this.tabPage1.Controls.Add(this.textBox1_a);
            this.tabPage1.Controls.Add(this.label1_f);
            this.tabPage1.Controls.Add(this.label1_a);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BLH->XYZ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1_Z
            // 
            this.textBox1_Z.Location = new System.Drawing.Point(473, 281);
            this.textBox1_Z.Name = "textBox1_Z";
            this.textBox1_Z.Size = new System.Drawing.Size(156, 25);
            this.textBox1_Z.TabIndex = 19;
            // 
            // textBox1_Y
            // 
            this.textBox1_Y.Location = new System.Drawing.Point(473, 222);
            this.textBox1_Y.Name = "textBox1_Y";
            this.textBox1_Y.Size = new System.Drawing.Size(156, 25);
            this.textBox1_Y.TabIndex = 18;
            // 
            // textBox1_X
            // 
            this.textBox1_X.Location = new System.Drawing.Point(473, 163);
            this.textBox1_X.Name = "textBox1_X";
            this.textBox1_X.Size = new System.Drawing.Size(156, 25);
            this.textBox1_X.TabIndex = 17;
            // 
            // label1_Z
            // 
            this.label1_Z.AutoSize = true;
            this.label1_Z.Location = new System.Drawing.Point(438, 286);
            this.label1_Z.Name = "label1_Z";
            this.label1_Z.Size = new System.Drawing.Size(15, 15);
            this.label1_Z.TabIndex = 16;
            this.label1_Z.Text = "Z";
            // 
            // label1_Y
            // 
            this.label1_Y.AutoSize = true;
            this.label1_Y.Location = new System.Drawing.Point(438, 227);
            this.label1_Y.Name = "label1_Y";
            this.label1_Y.Size = new System.Drawing.Size(15, 15);
            this.label1_Y.TabIndex = 15;
            this.label1_Y.Text = "Y";
            // 
            // label1_X
            // 
            this.label1_X.AutoSize = true;
            this.label1_X.Location = new System.Drawing.Point(438, 168);
            this.label1_X.Name = "label1_X";
            this.label1_X.Size = new System.Drawing.Size(15, 15);
            this.label1_X.TabIndex = 14;
            this.label1_X.Text = "X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1_H
            // 
            this.label1_H.AutoSize = true;
            this.label1_H.Location = new System.Drawing.Point(66, 289);
            this.label1_H.Name = "label1_H";
            this.label1_H.Size = new System.Drawing.Size(37, 15);
            this.label1_H.TabIndex = 12;
            this.label1_H.Text = "高程";
            // 
            // label1_L
            // 
            this.label1_L.AutoSize = true;
            this.label1_L.Location = new System.Drawing.Point(66, 231);
            this.label1_L.Name = "label1_L";
            this.label1_L.Size = new System.Drawing.Size(37, 15);
            this.label1_L.TabIndex = 11;
            this.label1_L.Text = "经度";
            // 
            // label1_B
            // 
            this.label1_B.AutoSize = true;
            this.label1_B.Location = new System.Drawing.Point(66, 173);
            this.label1_B.Name = "label1_B";
            this.label1_B.Size = new System.Drawing.Size(37, 15);
            this.label1_B.TabIndex = 10;
            this.label1_B.Text = "纬度";
            // 
            // textBox1_H
            // 
            this.textBox1_H.Location = new System.Drawing.Point(151, 284);
            this.textBox1_H.Name = "textBox1_H";
            this.textBox1_H.Size = new System.Drawing.Size(199, 25);
            this.textBox1_H.TabIndex = 9;
            // 
            // textBox1_L
            // 
            this.textBox1_L.Location = new System.Drawing.Point(151, 226);
            this.textBox1_L.Name = "textBox1_L";
            this.textBox1_L.Size = new System.Drawing.Size(199, 25);
            this.textBox1_L.TabIndex = 8;
            // 
            // textBox1_B
            // 
            this.textBox1_B.Location = new System.Drawing.Point(151, 168);
            this.textBox1_B.Name = "textBox1_B";
            this.textBox1_B.Size = new System.Drawing.Size(199, 25);
            this.textBox1_B.TabIndex = 7;
            // 
            // textBox1_f
            // 
            this.textBox1_f.Location = new System.Drawing.Point(151, 110);
            this.textBox1_f.Name = "textBox1_f";
            this.textBox1_f.Size = new System.Drawing.Size(199, 25);
            this.textBox1_f.TabIndex = 5;
            // 
            // textBox1_a
            // 
            this.textBox1_a.Location = new System.Drawing.Point(151, 52);
            this.textBox1_a.Name = "textBox1_a";
            this.textBox1_a.Size = new System.Drawing.Size(199, 25);
            this.textBox1_a.TabIndex = 4;
            // 
            // label1_f
            // 
            this.label1_f.AutoSize = true;
            this.label1_f.Location = new System.Drawing.Point(51, 115);
            this.label1_f.Name = "label1_f";
            this.label1_f.Size = new System.Drawing.Size(67, 15);
            this.label1_f.TabIndex = 2;
            this.label1_f.Text = "扁率倒数";
            // 
            // label1_a
            // 
            this.label1_a.AutoSize = true;
            this.label1_a.Location = new System.Drawing.Point(58, 57);
            this.label1_a.Name = "label1_a";
            this.label1_a.Size = new System.Drawing.Size(52, 15);
            this.label1_a.TabIndex = 1;
            this.label1_a.Text = "长半轴";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件ToolStripMenuItem,
            this.保存文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.导入文件ToolStripMenuItem.Text = "导入文件";
            this.导入文件ToolStripMenuItem.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.保存文件ToolStripMenuItem.Text = "保存文件";
            this.保存文件ToolStripMenuItem.Click += new System.EventHandler(this.保存文件ToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox2_L);
            this.tabPage2.Controls.Add(this.textBox2_H);
            this.tabPage2.Controls.Add(this.textBox2_Z);
            this.tabPage2.Controls.Add(this.textBox2_B);
            this.tabPage2.Controls.Add(this.textBox2_X);
            this.tabPage2.Controls.Add(this.textBox2_Y);
            this.tabPage2.Controls.Add(this.textBox2_f);
            this.tabPage2.Controls.Add(this.textBox2_a);
            this.tabPage2.Controls.Add(this.label2_H);
            this.tabPage2.Controls.Add(this.label2_L);
            this.tabPage2.Controls.Add(this.label2_B);
            this.tabPage2.Controls.Add(this.label2_Z);
            this.tabPage2.Controls.Add(this.label2_Y);
            this.tabPage2.Controls.Add(this.label2_X);
            this.tabPage2.Controls.Add(this.label2_f);
            this.tabPage2.Controls.Add(this.label2_a);
            this.tabPage2.Controls.Add(this.menuStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(665, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XYZ->BLH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2_L
            // 
            this.textBox2_L.Location = new System.Drawing.Point(450, 228);
            this.textBox2_L.Name = "textBox2_L";
            this.textBox2_L.Size = new System.Drawing.Size(173, 25);
            this.textBox2_L.TabIndex = 16;
            // 
            // textBox2_H
            // 
            this.textBox2_H.Location = new System.Drawing.Point(450, 280);
            this.textBox2_H.Name = "textBox2_H";
            this.textBox2_H.Size = new System.Drawing.Size(173, 25);
            this.textBox2_H.TabIndex = 15;
            // 
            // textBox2_Z
            // 
            this.textBox2_Z.Location = new System.Drawing.Point(123, 290);
            this.textBox2_Z.Name = "textBox2_Z";
            this.textBox2_Z.Size = new System.Drawing.Size(173, 25);
            this.textBox2_Z.TabIndex = 4;
            // 
            // textBox2_B
            // 
            this.textBox2_B.Location = new System.Drawing.Point(450, 181);
            this.textBox2_B.Name = "textBox2_B";
            this.textBox2_B.Size = new System.Drawing.Size(173, 25);
            this.textBox2_B.TabIndex = 13;
            // 
            // textBox2_X
            // 
            this.textBox2_X.Location = new System.Drawing.Point(123, 176);
            this.textBox2_X.Name = "textBox2_X";
            this.textBox2_X.Size = new System.Drawing.Size(173, 25);
            this.textBox2_X.TabIndex = 2;
            // 
            // textBox2_Y
            // 
            this.textBox2_Y.Location = new System.Drawing.Point(123, 233);
            this.textBox2_Y.Name = "textBox2_Y";
            this.textBox2_Y.Size = new System.Drawing.Size(173, 25);
            this.textBox2_Y.TabIndex = 3;
            // 
            // textBox2_f
            // 
            this.textBox2_f.Location = new System.Drawing.Point(123, 119);
            this.textBox2_f.Name = "textBox2_f";
            this.textBox2_f.Size = new System.Drawing.Size(173, 25);
            this.textBox2_f.TabIndex = 1;
            // 
            // textBox2_a
            // 
            this.textBox2_a.Location = new System.Drawing.Point(123, 62);
            this.textBox2_a.Name = "textBox2_a";
            this.textBox2_a.Size = new System.Drawing.Size(173, 25);
            this.textBox2_a.TabIndex = 0;
            // 
            // label2_H
            // 
            this.label2_H.AutoSize = true;
            this.label2_H.Location = new System.Drawing.Point(398, 285);
            this.label2_H.Name = "label2_H";
            this.label2_H.Size = new System.Drawing.Size(15, 15);
            this.label2_H.TabIndex = 8;
            this.label2_H.Text = "H";
            // 
            // label2_L
            // 
            this.label2_L.AutoSize = true;
            this.label2_L.Location = new System.Drawing.Point(398, 233);
            this.label2_L.Name = "label2_L";
            this.label2_L.Size = new System.Drawing.Size(15, 15);
            this.label2_L.TabIndex = 7;
            this.label2_L.Text = "L";
            // 
            // label2_B
            // 
            this.label2_B.AutoSize = true;
            this.label2_B.Location = new System.Drawing.Point(398, 186);
            this.label2_B.Name = "label2_B";
            this.label2_B.Size = new System.Drawing.Size(15, 15);
            this.label2_B.TabIndex = 6;
            this.label2_B.Text = "B";
            // 
            // label2_Z
            // 
            this.label2_Z.AutoSize = true;
            this.label2_Z.Location = new System.Drawing.Point(59, 295);
            this.label2_Z.Name = "label2_Z";
            this.label2_Z.Size = new System.Drawing.Size(15, 15);
            this.label2_Z.TabIndex = 5;
            this.label2_Z.Text = "Z";
            // 
            // label2_Y
            // 
            this.label2_Y.AutoSize = true;
            this.label2_Y.Location = new System.Drawing.Point(59, 238);
            this.label2_Y.Name = "label2_Y";
            this.label2_Y.Size = new System.Drawing.Size(15, 15);
            this.label2_Y.TabIndex = 4;
            this.label2_Y.Text = "Y";
            // 
            // label2_X
            // 
            this.label2_X.AutoSize = true;
            this.label2_X.Location = new System.Drawing.Point(59, 181);
            this.label2_X.Name = "label2_X";
            this.label2_X.Size = new System.Drawing.Size(15, 15);
            this.label2_X.TabIndex = 3;
            this.label2_X.Text = "X";
            // 
            // label2_f
            // 
            this.label2_f.AutoSize = true;
            this.label2_f.Location = new System.Drawing.Point(33, 124);
            this.label2_f.Name = "label2_f";
            this.label2_f.Size = new System.Drawing.Size(67, 15);
            this.label2_f.TabIndex = 2;
            this.label2_f.Text = "扁率倒数";
            // 
            // label2_a
            // 
            this.label2_a.AutoSize = true;
            this.label2_a.Location = new System.Drawing.Point(40, 67);
            this.label2_a.Name = "label2_a";
            this.label2_a.Size = new System.Drawing.Size(52, 15);
            this.label2_a.TabIndex = 1;
            this.label2_a.Text = "长半轴";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件ToolStripMenuItem1,
            this.保存ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(659, 28);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 导入文件ToolStripMenuItem1
            // 
            this.导入文件ToolStripMenuItem1.Name = "导入文件ToolStripMenuItem1";
            this.导入文件ToolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
            this.导入文件ToolStripMenuItem1.Text = "导入文件";
            this.导入文件ToolStripMenuItem1.Click += new System.EventHandler(this.导入文件ToolStripMenuItem1_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(665, 401);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BL->xy";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_name});
            this.dataGridView1.DataSource = this.pointinfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // p_name
            // 
            this.p_name.HeaderText = "点名";
            this.p_name.Name = "p_name";
            // 
            // pointinfoBindingSource
            // 
            this.pointinfoBindingSource.DataSource = typeof(坐标转换.Form1.Pointinfo);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(665, 401);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "xy->BL";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(62, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 469);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "坐标转换";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointinfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1_Z;
        private System.Windows.Forms.TextBox textBox1_Y;
        private System.Windows.Forms.TextBox textBox1_X;
        private System.Windows.Forms.Label label1_Z;
        private System.Windows.Forms.Label label1_Y;
        private System.Windows.Forms.Label label1_X;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1_H;
        private System.Windows.Forms.Label label1_L;
        private System.Windows.Forms.Label label1_B;
        private System.Windows.Forms.TextBox textBox1_H;
        private System.Windows.Forms.TextBox textBox1_L;
        private System.Windows.Forms.TextBox textBox1_B;
        private System.Windows.Forms.TextBox textBox1_f;
        private System.Windows.Forms.TextBox textBox1_a;
        private System.Windows.Forms.Label label1_f;
        private System.Windows.Forms.Label label1_a;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2_L;
        private System.Windows.Forms.TextBox textBox2_H;
        private System.Windows.Forms.TextBox textBox2_Z;
        private System.Windows.Forms.TextBox textBox2_B;
        private System.Windows.Forms.TextBox textBox2_X;
        private System.Windows.Forms.TextBox textBox2_Y;
        private System.Windows.Forms.TextBox textBox2_f;
        private System.Windows.Forms.TextBox textBox2_a;
        private System.Windows.Forms.Label label2_H;
        private System.Windows.Forms.Label label2_L;
        private System.Windows.Forms.Label label2_B;
        private System.Windows.Forms.Label label2_Z;
        private System.Windows.Forms.Label label2_Y;
        private System.Windows.Forms.Label label2_X;
        private System.Windows.Forms.Label label2_f;
        private System.Windows.Forms.Label label2_a;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name;
        private System.Windows.Forms.BindingSource pointinfoBindingSource;
        private System.Windows.Forms.Button button3;
    }
}

