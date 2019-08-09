using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pro_Sec
{
    public partial class Form1 : Form
    {
        Formula formula = new Formula();

        //散点链表
        List<Point> CPoints;
        //用于与datagridview绑定的链表
        private BindingList<Point> Bdata;
        //关键点
        Point K0, K1, K2, M, N;
        //纵横断面内差点点集
        List<Point> Pro_P, M_P, N_P;
        //参考高程
        double H0;
        double pro_area;
        double M_area;
        double N_area;

        //图形数据
        Series SerP, SerPro, SerPro1, SerPro2, SerM, SerN;


        public Form1()
        {
            InitializeComponent();
        }

        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPoints = new List<Point>();
            K0 = new Point();
            K1 = new Point();
            K2 = new Point();

            formula.Readfile(out H0, out CPoints, out K0, out K1, out K2);

            Bdata = new BindingList<Point>(CPoints);
            dataGridView1.DataSource = Bdata;

            MessageBox.Show("数据读取完成！");

        }

        private void 纵断面计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pro_P = new List<Point>();

            formula.ComputePro_P(CPoints, K0, K1, K2, out Pro_P);

            formula.ComputePro_Area(CPoints, H0, K0, K1, K2, out pro_area);

            MessageBox.Show("纵断面计算完成！");
        }

        private void 保存图形为BMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "BMP Files(*.bmp)|*.bmp";
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                chart1.SaveImage(file.FileName, ChartImageFormat.Bmp);
                MessageBox.Show("图形保存完成!");
            }
            else
            {
                return;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 断面图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 横断面计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_P = new List<Point>();
            N_P = new List<Point>();

            formula.ComputeMN(K0, K1, K2, out M, out N);

            formula.ComputeM_P(K0, K1, M, CPoints, out  M_P);
            formula.ComputeM_P(K1, K2, N, CPoints, out  N_P);

            formula.Compute_Area(M_P, H0, out M_area);
            formula.Compute_Area(N_P, H0, out N_area);

            MessageBox.Show("横断面计算完成！");

            formula.Draw(Pro_P, M_P, N_P, CPoints, out SerP, out SerPro, out SerPro1, out SerPro2, out SerM, out  SerN);

            chart1.Series["Series1"] = SerP;
            chart1.Series[0].LegendText = "数据点";
            chart1.Series["Series2"] = SerPro;
            chart1.Series[1].LegendText = "纵断面";
            chart1.Series["Series3"] = SerPro1;
            chart1.Series[2].LegendText = "横断面1";
            chart1.Series["Series4"] = SerPro2;
            chart1.Series[3].LegendText = "横断面2";

            chart1.Series["Series5"] = SerM;
            chart1.Series[4].ChartArea = "ChartArea2";
            chart1.Series[4].LegendText = "横断面1";

            chart1.Series["Series6"] = SerN;
            chart1.Series[5].ChartArea = "ChartArea3";
            chart1.Series[5].LegendText = "横断面2";


            chart1.DataBind();
        }


    }
}
