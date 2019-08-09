using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinVolume
{
    public partial class Form1 : Form
    {
        Formula formula = new Formula();

        //用于显示的数据
        List<dataPoint> DPoints;
        //与datagridview绑定的数据
        private BindingList<dataPoint> Bdata;
        //用于计算的数据
        List<Point> CPoints;
        //构成Tin的三角形列表
        List<Triangle> TinTriangle;
        //高程基准
        double h0;
        //体积
        double V;
        //报告
        string re_text;

        public Form1()
        {
            InitializeComponent();
        }

        private void 打开数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DPoints = new List<dataPoint>();

            formula.ReadFile(out DPoints);

            Bdata = new BindingList<dataPoint>(DPoints);
            dataGridView1.DataSource = Bdata;

            Point p;
            CPoints = new List<Point>();
            for (int i = 0; i < DPoints.Count; i++)
            {
                p = new Point();
                p.Name = DPoints[i].Name;
                p.X = DPoints[i].X;
                p.Y = DPoints[i].Y;
                p.H = DPoints[i].H;
                p.num = i;
                CPoints.Add(p);
            }
            MessageBox.Show("原始数据读取完成！");
        }

        private void 生成不规则三角网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TinTriangle = new List<Triangle>();
            formula.GetTin(CPoints, out TinTriangle);
            MessageBox.Show("Tin构建完成!");
        }

        private void 体积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                MessageBox.Show("请输入高程基准！");
                return;
            }
            else
            {
                List<double >Vi = new List<double>();
                h0 = double.Parse(toolStripTextBox1.Text);
                formula.GetVolume(h0, TinTriangle, out V, out Vi);
                formula.Report(TinTriangle, Vi, h0, V, out re_text);
                MessageBox.Show("体积计算完成！");
                MessageBox.Show("报告撰写完成！");
                richTextBox1.Text = re_text;
            }
        }
    }
}
