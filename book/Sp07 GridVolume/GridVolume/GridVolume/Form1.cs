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

namespace GridVolume
{
    public partial class Form1 : Form
    {
        //实例化类formula
        Formula formula = new Formula();

        //存储用于计算用的数据
        List<Point> CPoints = new List<Point>();
        //存储用于显示的数据
        List<Point> DPoints = new List<Point>();
        //基点P0
        Point P0 = new Point();
        //排序后的点集
        List<Point> OPoints = new List<Point>();
        //凸包点集合
        List<Point> PolyPoints = new List<Point>();
        //与datagridview绑定的链表
        private BindingList<Point> Bdata;
        //图形数据
        Series serP, serL, serG;
        //格网的边长
        double L;
        //格网点的链表
        List<GridPoint> GPoints;
        //外包矩形
        double xmax, xmin, ymax, ymin;
        //高程基准
        double h0;
        //报告
        string re_text;


        public Form1()
        {
            InitializeComponent();
        }

        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPoints = new List<Point>();
            DPoints = new List<Point>();

            formula.ReadFile(out DPoints);
            CPoints = DPoints;

            Bdata = new BindingList<Point>(DPoints);
            this.dataGridView1.DataSource = Bdata;

            //绘制图形，撰写报告
            serP = new Series();
            double xmax, xmin, ymax, ymin;
            formula.DrawPoints(DPoints, out serP, out  xmax, out xmin, out ymax, out ymin);
            chart1.ChartAreas[0].AxisY.Minimum = ymin - 10;
            chart1.ChartAreas[0].AxisY.Maximum = ymax + 10;
            chart1.ChartAreas[0].AxisX.Minimum = xmin - 10;
            chart1.ChartAreas[0].AxisX.Maximum = xmax + 10;
            chart1.Series.Clear();
            chart1.Series.Add(serP);
            chart1.Series["Series1"].LegendText = "数据点";
            chart1.DataBind();
            MessageBox.Show("数据读取完毕！");
            MessageBox.Show("散点图绘制完毕！");
            tabControl1.SelectedIndex = 3;
        }

        private void 生成凸包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formula.Polygon(CPoints, out P0, out OPoints, out PolyPoints);
            serL = new Series();
            formula.DrawPoly(PolyPoints, out serL);
            chart1.Series.Add(serL);
            chart1.Series["Series2"].LegendText = "凸包多边形";
            chart1.DataBind();
            MessageBox.Show("凸包多边形生成完毕！");
            MessageBox.Show("凸包多边形绘制完毕！");
            tabControl1.SelectedIndex = 3;
        }

        private void 建立格网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                MessageBox.Show("请输入格网大小！");
                return;
            }
            else
            {
                L = double.Parse(toolStripTextBox1.Text);

                GPoints = new List<GridPoint>();
                formula.Grid(L, PolyPoints, out GPoints, out xmax, out xmin, out ymax, out ymin);
                List<Point> serGPoints = new List<Point>();
                formula.DrawGrid(L, xmax, xmin, ymax, ymin, out serGPoints);
                serG = new Series();
                serG.ChartType = SeriesChartType.Line;
                serG.Color = Color.Yellow;
                DataPoint p;
                for (int i = 0; i < serGPoints.Count; i++)
                {
                    p = new DataPoint();
                    p.SetValueXY(serGPoints[i].X, serGPoints[i].Y);
                    serG.Points.Add(p);
                }
                chart1.Series.Add(serG);
                chart1.Series["Series3"].LegendText = "格网";
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(chart1.ChartAreas[0].CursorX.SelectionStart, chart1.ChartAreas[0].CursorX.SelectionEnd);
                chart1.DataBind();
                MessageBox.Show("格网生成完成！");
                MessageBox.Show("格网绘制完成！");
                tabControl1.SelectedIndex = 3;
            }
        }

        private void 计算体积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text == "")
            {
                MessageBox.Show("请输入高程基准！");
                return;
            }
            else
            {
                h0 = double.Parse(toolStripTextBox2.Text);
                double r = 0.5 * (xmax - xmin + ymax - ymin) * 0.4;

                double V = 0;
                formula.CVolume(L, h0, r, CPoints, GPoints, out V);

                MessageBox.Show("体积计算完成！");

                formula.Report(L, h0, xmax, xmin, ymax, ymin, GPoints, PolyPoints, CPoints, V, out re_text);

                MessageBox.Show("报告撰写完成！");

                richTextBox1.Text = re_text;
                tabControl1.SelectedIndex = 2;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            打开数据文件ToolStripMenuItem_Click(sender, e);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            保存报告ToolStripMenuItem_Click(sender, e);
        }

        private void 图形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void 报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 保存报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All files(*.*)|(*.*)";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arr = re_text.Split('\n');
                myStream = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < arr.Count(); i++)
                {
                    myStream.WriteLine(arr[i]);
                }
                myStream.Close();
                MessageBox.Show("报告保存完毕！");
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

        private void 保存图形为BMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "bmp文件|*.bmp";
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Bmp);
                MessageBox.Show("图形保存完成！");
            }
        }
    }
}
