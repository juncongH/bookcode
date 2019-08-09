using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace LevelAdjust
{
    public partial class Form1 : Form
    {
        Formula formula = new Formula();

        List<ViewData> DStations;
        List<Station> CStations;
        List<Segment> Segments;
        double H_start;
        double H_end;
        private BindingList<ViewData> Bdata;
        Series serP;
        string re_text;


        public Form1()
        {
            InitializeComponent();
        }

        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DStations = new List<ViewData>();
            CStations = new List<Station>();

            formula.Readfile(out DStations, out CStations, out H_start, out H_end);

            Bdata = new BindingList<ViewData>(DStations);
            this.dataGridView1.DataSource = Bdata;
            MessageBox.Show("文件读取完成！");
        }

        private void 手簿计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = CStations.Count;

            CStations[0].a15 = 0;
            formula.DataCalculate(0, CStations[0]);

            for (int i = 1; i < n; i++)
            {
                formula.DataCalculate(CStations[i - 1].a15, CStations[i]);
            }
            MessageBox.Show("手簿计算完成！");
        }

        private void 高程平差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formula.Station_Segment(CStations, out Segments);

            formula.LevAdjust(H_start, H_end, Segments);

            MessageBox.Show("高程平差完成！");

            serP = new Series();
            formula.DrawP(Segments, H_start, out serP);
            chart1.Series.Clear();
            chart1.Series.Add(serP);
            chart1.Series["Series1"].LegendText = "水准点";
            chart1.DataBind();
            MessageBox.Show("图形绘制完成！");

        }

        private void 保存图形为BMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;
            file.Filter = "BMP files(*.bmp)|*.bmp";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                chart1.SaveImage(file.FileName, ChartImageFormat.Bmp);
                MessageBox.Show("图形保存完成！");
            }
            else
            { return; }
        }

        private void 数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 线路图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            手簿计算ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            高程平差ToolStripMenuItem_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存图形为DxfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;
            file.Filter = "Dxf files(*.dxf)|*.dxf";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(file.FileName.ToString());

                sw.WriteLine("0");
                sw.WriteLine("SECTION");
                sw.WriteLine("2");
                sw.WriteLine("ENTITLES");

                sw.WriteLine("0");
                sw.WriteLine("POINT");
                sw.WriteLine("8");
                sw.WriteLine("点层");
                sw.WriteLine("10");
                sw.WriteLine(0);
                sw.WriteLine("20");
                sw.WriteLine(H_start);

                sw.WriteLine("0");
                sw.WriteLine("TEXT");
                sw.WriteLine("8");
                sw.WriteLine("注记");
                sw.WriteLine("10");
                sw.WriteLine(0);
                sw.WriteLine("20");
                sw.WriteLine(H_start);
                sw.WriteLine("40");
                sw.WriteLine(10);
                sw.WriteLine("1");
                sw.WriteLine(CStations[0].backName);

                double Dis = 0;
                for (int i = 0; i < Segments.Count; i++)
                {
                    Dis += Segments[i].dis;

                    sw.WriteLine("0");
                    sw.WriteLine("POINT");
                    sw.WriteLine("8");
                    sw.WriteLine("点层");
                    sw.WriteLine("10");
                    sw.WriteLine(Dis);
                    sw.WriteLine("20");
                    sw.WriteLine(Segments[i].He);

                    sw.WriteLine("0");
                    sw.WriteLine("TEXT");
                    sw.WriteLine("8");
                    sw.WriteLine("注记");
                    sw.WriteLine("10");
                    sw.WriteLine(Dis);
                    sw.WriteLine("20");
                    sw.WriteLine(Segments[i].He);
                    sw.WriteLine("40");
                    sw.WriteLine(10);
                    sw.WriteLine("1");
                    sw.WriteLine(Segments[i].endname);
                }

                sw.WriteLine("0");
                sw.WriteLine("ENDSEC");
                sw.WriteLine("0");
                sw.WriteLine("EOF");

                sw.Close();
            }
            else
            {
                return;
            }
        }
    }
}
