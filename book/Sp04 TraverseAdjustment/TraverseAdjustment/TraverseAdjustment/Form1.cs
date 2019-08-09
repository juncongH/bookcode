using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace TraverseAdjustment
{
    public partial class Form1 : Form
    {
        //用于存储控制点坐标
        List<Point> SPoints = new List<Point>();
        //用于存储计算用的数据
        List<Point> CPoints = new List<Point>();
        //用于存储显示用的数据
        List<dataview> DPoints = new List<dataview>();
        private BindingList<dataview> Bdata;
        //三个精度常数
        double const1, const2, const3;
        //始终方位角
        double SAzimuth, EAzimuth;
        //方位角闭合差以及限差
        double fbeta;
        double allowance;
        //导线全长及纵横坐标闭合差以及导线全长闭合差及限差
        double SigmaS, fx, fy, fs, allowance2;
        //报告
        string richtext = null;

        Formula formula = new Formula();

        public Form1()
        {
            InitializeComponent();
            Bdata = new BindingList<dataview>(DPoints);
            this.dataGridView1.DataSource = Bdata;

            this.dataGridView1.Columns[0].HeaderText = "点名";
            this.dataGridView1.Columns[1].HeaderText = "观测角°″′";
            this.dataGridView1.Columns[2].HeaderText = "方位角°″′";
            this.dataGridView1.Columns[3].HeaderText = "边长(m)";
            this.dataGridView1.Columns[4].HeaderText = "ΔX(m)";
            this.dataGridView1.Columns[5].HeaderText = "ΔY(m)";
            this.dataGridView1.Columns[6].HeaderText = "X(m)";
            this.dataGridView1.Columns[7].HeaderText = "Y(m)";
        }


        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SPoints = new List<Point>();
            CPoints = new List<Point>();

            formula.Readfile(out const1, out const2, out const3, out SPoints, out CPoints);

            SAzimuth = formula.Azimuth1(SPoints[1].X, SPoints[1].Y, SPoints[0].X, SPoints[0].Y);
            EAzimuth = formula.Azimuth1(SPoints[3].X, SPoints[3].Y, SPoints[2].X, SPoints[2].Y);

            int n1 = CPoints.Count;

            dataview data = new dataview();
            data.Name = SPoints[0].Name; data.X = SPoints[0].X.ToString(); data.Y = SPoints[0].Y.ToString();
            DPoints.Add(data);
            data = new dataview();
            data.Azimuth = formula.Dms2Str(formula.Rad2Dms(SAzimuth));
            DPoints.Add(data);
            for (int i = 0; i < n1; i++)
            {
                data = new dataview();
                data.Name = CPoints[i].Name; data.Angle = formula.Dms2Str(formula.Rad2Dms(CPoints[i].Angle));
                if (i == 0)
                {
                    data.X = SPoints[1].X.ToString();
                    data.Y = SPoints[1].Y.ToString();
                }
                if (i == 18)
                {
                    data.X = SPoints[2].X.ToString();
                    data.Y = SPoints[2].Y.ToString();
                }
                DPoints.Add(data);
                data = new dataview();
                if (i == 18)
                {

                }
                else
                    data.S = CPoints[i].S.ToString();
                DPoints.Add(data);
            }
            data = new dataview();
            data.Name = SPoints[3].Name;
            data.X = SPoints[3].X.ToString();
            data.Y = SPoints[3].Y.ToString();
            DPoints.Add(data);

            Bdata = new BindingList<dataview>(DPoints);
            this.dataGridView1.DataSource = Bdata;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 计算方位角ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n1 = CPoints.Count;
            double alpha;
            for (int i = 0; i < n1; i++)
            {
                if (i == 0)
                    alpha = SAzimuth;
                else
                    alpha = CPoints[i - 1].Azimuth;
                CPoints[i].Azimuth = formula.Azimuth2(alpha, CPoints[i].Angle);
            }
            for (int i = 0; i < n1; i++)
            {
                DPoints[(i + 2) * 2 - 1].Azimuth = formula.Dms2Str(formula.Rad2Dms(CPoints[i].Azimuth));
            }

            fbeta = CPoints[18].Azimuth - EAzimuth;
            allowance = 24.0 * Math.Sqrt(n1);
            if (Math.Abs(fbeta) <= allowance / 3600.0 / 180.0 * Math.PI)
            {
                for (int i = 0; i < n1; i++)
                {
                    CPoints[i].Angle -= fbeta / n1;
                    if (i == 0)
                        alpha = SAzimuth;
                    else
                        alpha = CPoints[i - 1].Azimuth;
                    CPoints[i].Azimuth = formula.Azimuth2(alpha, CPoints[i].Angle);
                    DPoints[(i + 1) * 2].Angle = formula.Dms2Str(formula.Rad2Dms(CPoints[i].Angle));
                    DPoints[(i + 2) * 2 - 1].Azimuth = formula.Dms2Str(formula.Rad2Dms(CPoints[i].Azimuth));
                }
                MessageBox.Show("方位角闭合差在限差以内！\n角度近似平差完成！");
            }
            else
            {
                MessageBox.Show("方位角闭合差超限！");
            }

            Bdata = new BindingList<dataview>(DPoints);
            this.dataGridView1.DataSource = Bdata;
        }

        private void 坐标近似平差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n1 = CPoints.Count;

            CPoints[0].X = SPoints[1].X;
            CPoints[0].Y = SPoints[1].Y;
            CPoints[n1 - 1].X = SPoints[2].X;
            CPoints[n1 - 1].Y = SPoints[2].Y;

            fx = SPoints[1].X - SPoints[2].X;
            fy = SPoints[1].Y - SPoints[2].Y;
            for (int i = 0; i < n1 - 1; i++)
            {
                CPoints[i].DeltaX = CPoints[i].S * Math.Cos(CPoints[i].Azimuth);
                CPoints[i].DeltaY = CPoints[i].S * Math.Sin(CPoints[i].Azimuth);
                fx += CPoints[i].DeltaX;
                fy += CPoints[i].DeltaY;
                SigmaS += CPoints[i].S;
            }
            fs = Math.Sqrt(fx * fx + fy * fy);
            allowance2 = 1.0 / 5000.0;
            if ((fs / SigmaS) <= allowance2)
            {
                for (int i = 0; i < n1 - 1; i++)
                {
                    CPoints[i].DeltaX -= fx / SigmaS * CPoints[i].S;
                    CPoints[i].DeltaY -= fy / SigmaS * CPoints[i].S;
                    if (i == 0)
                    {
                        CPoints[i].X = SPoints[1].X;
                        CPoints[i].Y = SPoints[1].Y;
                    }
                    else
                    {
                        CPoints[i].X = CPoints[i - 1].X + CPoints[i].DeltaX;
                        CPoints[i].Y = CPoints[i - 1].Y + CPoints[i].DeltaY;
                    }
                    if (i <= 17)
                    {
                        DPoints[(i + 2) * 2 - 1].DeltaX = CPoints[i].DeltaX.ToString("f5");
                        DPoints[(i + 2) * 2 - 1].DeltaY = CPoints[i].DeltaY.ToString("f5");
                        DPoints[(i + 1) * 2].X = CPoints[i].X.ToString("f5");
                        DPoints[(i + 1) * 2].Y = CPoints[i].Y.ToString("f5");
                    }
                }
                MessageBox.Show("导线全长相对闭合差符合限差！\n坐标近似平差完成！");
            }
            else
            {
                MessageBox.Show("导线全长相对闭合差超限！");
            }
            Bdata = new BindingList<dataview>(DPoints);
            this.dataGridView1.DataSource = Bdata;

            //绘制图形，撰写报告
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Point;
            DataPoint p;
            p = new DataPoint();
            p.SetValueXY(SPoints[0].Y, SPoints[0].X);
            ser.Points.Add(p);
            for (int i = 0; i < n1; i++)
            {
                p = new DataPoint();
                p.SetValueXY(CPoints[i].Y, CPoints[i].X);
                ser.Points.Add(p);
            }
            p = new DataPoint();
            p.SetValueXY(SPoints[3].Y, SPoints[3].X);
            ser.Points.Add(p);
            chart1.ChartAreas[0].AxisY.Minimum = 3415000;
            chart1.ChartAreas[0].AxisY.Maximum = 3419000;
            chart1.Series.Add(ser);
            chart1.DataBind();
            MessageBox.Show("图形绘制完毕！");

            richtext = formula.report(allowance, allowance2, n1, SigmaS, fbeta, fx, fy, SAzimuth, EAzimuth, CPoints, SPoints);
            richTextBox1.Text = richtext;
            MessageBox.Show("计算报告撰写完毕！");
        }

        private void 导线略图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 计算报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 数据表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 保存BMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "bmp文件|*.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Bmp);
            }
        }

        private void 保存DXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "DXF文件|*.dxf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("代码不难，但是太复杂，记不住");
            }
        }

        private void 保存报告ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All files(*.*)|(*.*)";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arr = richtext.Split('\n');
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

        private void 导线图形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Width /= 2;
            pictureBox1.Height /= 2;
        }
    }
}
