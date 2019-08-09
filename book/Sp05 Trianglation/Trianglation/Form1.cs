using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trianglation
{
    public partial class Form1 : Form
    {
        Formula formula = new Formula();

        //起始高程
        double H_start;
        //用于计算用的数据链表
        List<Station> CStations;
        List<HStation> HStations;
        //用于显示用的数据链表
        List<DStation> DStations;
        //用于与datagridview绑定的链表
        private BindingList<DStation> Bdata;
        //图形数据
        Series serp;


        public Form1()
        {
            InitializeComponent();
        }

        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CStations = new List<Station>();
            DStations = new List<DStation>();

            formula.Readfile(out CStations, out DStations, out H_start);

            Bdata = new BindingList<DStation>(DStations);
            dataGridView1.DataSource = Bdata;

            MessageBox.Show("数据读取完成！");
        }

        private void 保存图形为BMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "All Files(*.*)|*.*|BMP(*.bmp)|*.bmp";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                chart1.SaveImage(file.FileName.ToString(), ChartImageFormat.Bmp);
                MessageBox.Show("图形保存完成！");
            }
            else
            {return;}
        }

        private void 计算手簿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 水准路线图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 平差报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 手簿计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CStations = formula.CalculStation(CStations);
            int n = CStations.Count;

            for (int i = 0; i < n; i++)
            {
                DStations[i].f = CStations[i].f.ToString("f4");
                DStations[i].D = CStations[i].D.ToString("f4");
                DStations[i].h = CStations[i].h.ToString("f4");
            }
            for (int i = 0; i < n; i= i+ 2)
            {
                DStations[i].h_ave = CStations[i].h_ave.ToString("f4");
                DStations[i].TorF = CStations[i].TorF;
            }

            Bdata = new BindingList<DStation>(DStations);
            dataGridView1.DataSource = Bdata;

            MessageBox.Show("手簿计算完成！");
        }

        private void 保存图形为DxfToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void 高程平差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HStations = new List<HStation>();
            formula.LevelAdjust(CStations, H_start, out HStations);
            double u = 0;
            formula.CalculError(HStations, out u);
            MessageBox.Show("高程平差完成！");
            formula.Drawp(HStations, out serp);
            //chart1.Series.Clear();
            chart1.Series["Series1"] = serp;
            //chart1.Series.Add(serp);
            //chart1.Series["Series1"].LegendText = "水准点";
            //chart1.DataBind();
            MessageBox.Show("图形绘制完成！");

            Series serp1 = new Series();
            formula.Drawp(HStations, out serp1);
            chart1.Series[1] = serp1;
            chart1.Series[1].ChartArea = "ChartArea2";
            //chart1.Series.Add(serp1);
            chart1.DataBind();
        }
    }
}
