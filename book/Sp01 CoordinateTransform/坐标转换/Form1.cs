using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 坐标转换
{
    public partial class Form1 : Form
    {
        double a, f, e1, L0;
        double X, Y, Z;
        double B, L, H;
        List<Pointinfo> result=new List<Pointinfo>();
        List<Pointinfo> data;
 
        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter f = new StreamWriter(saveFileDialog1.FileName, true);
                for (int i=0;i<result.Count;i++)
                {
                    if(tabControl1.SelectedTab==tabPage1)
                    {
                        string res = result[i].p_name + "," + result[i].x + "," + result[i].y + "," + result[i].z;
                        f.WriteLine(res);
                    } 
                }
                f.Close();
            }
        }

        private void 导入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                List<Pointinfo> data = readdata(openFileDialog1.FileName);
                for(int i=0;i<data.Count;i++)
                {
                    if (tabControl1.SelectedTab==tabPage1)
                    {
                        BLHtransformXYZ(readBLdata(data[i].b.ToString()) * Math.PI / 180, readBLdata(data[i].l.ToString()) * Math.PI / 180, data[i].h, out X, out Y, out Z);
                        //textBox1_X.Text = X.ToString();
                        //textBox1_Y.Text = Y.ToString();
                        //textBox1_Z.Text = Z.ToString();
                        data[i].x = X;
                        data[i].y = Y;
                        data[i].z = Z;
                    }
                    result.Add(data[i]);
                }
                MessageBox.Show("导入成功！");
            }
        }

        public List<Pointinfo> readdata(string path)
        {
            string[] lines;
            List<Pointinfo> data= new List<Pointinfo>();
            lines = File.ReadAllLines(path);
            a = Convert.ToDouble(lines[0].Split(',')[1]);
            f = 1 / Convert.ToDouble(lines[1].Split(',')[1]);
            e1 = Math.Sqrt(2 * f - f * f);

            Pointinfo p;
            for(int i=3;i<lines.Length;i++)
            {
                p = new Pointinfo();
                string[] str = lines[i].Split(',');
                p.p_name = str[0];
                if(tabControl1.SelectedTab==tabPage1)
                {
                    p.b = Convert.ToDouble(str[1]);
                    p.l = Convert.ToDouble(str[2]);
                    p.h = Convert.ToDouble(str[3]);
                }
                if(tabControl1.SelectedTab==tabPage2)
                {
                    p.x = Convert.ToDouble(str[1]);
                    p.y = Convert.ToDouble(str[2]);
                    p.z = Convert.ToDouble(str[3]);
                }
                data.Add(p);
            }
            return data;
        }

        private void 导入文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<Pointinfo> data = readdata(openFileDialog1.FileName);
                for (int i = 0; i < data.Count; i++)
                {
                    if (tabControl1.SelectedTab == tabPage2)
                    {
                        XYZtranformBLH(data[i].x, data[i].y, data[i].z, out B, out L, out H);
                        data[i].b = B;
                        data[i].l = L;
                        data[i].h = H;
                    }
                    result.Add(data[i]);
                }
                MessageBox.Show("导入成功！");
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter f = new StreamWriter(saveFileDialog1.FileName, true);
                for (int i = 0; i < result.Count; i++)
                {
                    if (tabControl1.SelectedTab == tabPage2)
                    {
                        string res = result[i].p_name + "," + result[i].b + "," + result[i].l + "," + result[i].h;
                        f.WriteLine(res);
                    }
                }
                f.Close();
            }
        }

        public class Pointinfo
        {
            public string p_name;
            public double b, l, h, x, y, z;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BPoint = new BindingList<Pointinfo>(data);
            this.dataGridView1.DataSource = BPoint;
        }

        public double readBLdata(string d)
        {
            double du, fen, miao;
            du = Convert.ToDouble(d.Split('.')[0]);
            fen = Convert.ToDouble(d.Split('.')[1].Substring(0, 2));
            miao = Convert.ToDouble(d.Split('.')[1].Substring(2)) / 100;
            return du + fen / 60 + miao / 3600;
        }

        public void BLHtransformXYZ(double B,double L,double H,out double X,out double Y,out double Z)
        {
            double W = Math.Sqrt(1 - e1 * e1 * Math.Sin(B) * Math.Sin(B));
            double N = a / W;
            X = (N + H) * Math.Cos(B) * Math.Cos(L);
            Y = (N + H) * Math.Cos(B) * Math.Sin(L);
            Z = (N * (1 - e1 * e1) + H) * Math.Sin(B);
        }

        public void XYZtranformBLH(double X,double Y,double Z,out double B,out double L,out double H)
        {
            L = Math.Atan(Y / X) * 180 / Math.PI;
            if (L < 0)
                L = L + 180;
            double B0 = 0;
            double N, t;
            do
            {
                N = a / Math.Sqrt(1 - e1 * e1 * Math.Sin(B0) * Math.Sin(B0));
                B = Math.Atan((Z + N * e1 * e1 * Math.Sin(B0)) / Math.Sqrt(X * X + Y * Y));
                t = B - B0;
                B0 = B;
            } while (Math.Abs(t) > 10e-10);
            B = B0 * 180 / Math.PI;
            H = Math.Sqrt(X * X + Y * Y) / Math.Cos(B * Math.PI / 180) - N;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1_a.Text);
                f = 1 / Convert.ToDouble(textBox1_f.Text);
                e1 = Math.Sqrt(2 * f - f * f);

                BLHtransformXYZ(readBLdata(textBox1_B.Text) * Math.PI / 180, readBLdata(textBox1_L.Text) * Math.PI / 180, Convert.ToDouble(textBox1_H.Text), out X, out Y, out Z);
                textBox1_X.Text = X.ToString();
                textBox1_Y.Text = Y.ToString();
                textBox1_Z.Text = Z.ToString();
            }
           catch(FormatException)
            {
                MessageBox.Show("数据格式错误或未输入数据","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox2_a.Text);
                f = 1 / Convert.ToDouble(textBox2_f.Text);
                e1 = Math.Sqrt(2 * f - f * f);

                XYZtranformBLH(Convert.ToDouble(textBox2_X.Text), Convert.ToDouble(textBox2_Y.Text), Convert.ToDouble(textBox2_Z.Text), out B, out L, out H);
                textBox2_B.Text = B.ToString();
                textBox2_L.Text = L.ToString();
                textBox2_H.Text = H.ToString();
            }
            catch(FormatException)
            {
                MessageBox.Show("数据格式错误或未输入数据", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private BindingList<Pointinfo> BPoint;




    }
}
