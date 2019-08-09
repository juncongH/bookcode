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
using System.Windows.Forms.DataVisualization.Charting;

namespace 道路曲线要素计算与里程桩计算
{
    public partial class ZHX : Form
    {
        //int x1, y1, x2, y2;
        //定义曲线要素
        double a, R, T, L, E, q, Ls, D;
        //定义主点里程
        double Kzh, Khy, Kqz, Kyh, Khz, Kjd;
        //定义线路坐标
        double JD_X, JD_Y, ZH_X, ZH_Y;
        double K,A1,A2;
        double du, fen, miao;
        public ZHX()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                //弧度制表示转角
                du = Convert.ToDouble(ROTATE_V_D.Text);
                fen = Convert.ToDouble(ROTATE_V_F.Text);
                miao = Convert.ToDouble(ROTATE_V_M.Text);
                a = (du + fen / 60 + miao / 3600) * Math.PI / 180;

                JD_X = Convert.ToDouble(JDX_V.Text);
                JD_Y = Convert.ToDouble(JDY_V.Text);
                Ls = Convert.ToDouble(HCLENGTH_V.Text);
                R = Convert.ToDouble(RADIUS_V.Text);
                Kjd = Convert.ToDouble(KJD_V.Text);

                K = Convert.ToDouble(KI_V.Text);

                ZH_X = Convert.ToDouble(ZHX_V.Text);
                ZH_Y = Convert.ToDouble(ZHY_V.Text);
                A1 = Math.Atan((JD_Y - ZH_Y) / (JD_X - ZH_X));
                A2 = A1 + a;

                if (DIR_RIGHT.Checked)
                    D = 1;
                if (DIR_LEFT.Checked)
                    D = -1;
            }
            catch(FormatException)
            {
                MessageBox.Show("数据格式错误或为空！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //圆曲线
            if (Ls == 0)
            {
                T = R * Math.Tan(a / 2);
                L = R * a * Math.PI / 180;
                E = R * (1 / Math.Cos(a / 2) - 1);
                q = 2 * T - L;

                Kzh = Kjd - T;
                Kqz = Kzh + L / 2;
                Khz = Kzh + L;
                Khy = 0;
                Kyh = 0;

                double x_zh, y_zh, x_hz, y_hz;
                x_zh = JD_X - T * Math.Cos(A1);
                y_zh = JD_Y - T * Math.Sin(A1);
                x_hz = JD_X - T * Math.Cos(A2);
                y_hz = JD_Y - T * Math.Sin(A2);

                double fai, l, x, y, X, Y;
                if(K<=Kqz)
                {
                    l = K - Kzh;
                    fai = l * 180 / R / Math.PI;
                    x = R * Math.Sin(fai);
                    y = R * (1 - Math.Cos(fai));
                    X = x_zh + x * Math.Cos(A1) - D * y * Math.Sin(A1);
                    Y = y_zh + x * Math.Sin(A1) + D * y * Math.Cos(A1);
                }
                else
                {
                    l = Kzh - K;
                    fai = l * 180 / R / Math.PI;
                    x = R * Math.Sin(fai);
                    y = R * (1 - Math.Cos(fai));
                    X = x_hz + x * Math.Cos(A2) + D * y * Math.Sin(A2);
                    Y = y_hz + x * Math.Sin(A2) - D * y * Math.Cos(A2);
                }
            }

            //带有缓和曲线
            if(Ls>0)
            {
                double m, P, B;
                m = Ls / 2 - Math.Pow(Ls, 3) / 240 / R / R;
                P = Ls * Ls / 24 / R;
                B = Ls / R / 2;

                T = m + (R + P) * Math.Tan(a / 2);
                L = R * (a - 2 * B) + 2 * Ls;
                E = (R + P) * (1 / Math.Cos(a / 2)) - R;
                q = 2 * T - L;

                Kzh = Kjd - T;
                Khy = Kzh + Ls;
                Kqz = Kzh + L / 2;
                Kyh = Kzh + L + Ls;
                Khz = Kyh + Ls;

                double x_zh, y_zh, x_hz, y_hz;
                x_zh = JD_X - T * Math.Cos(A1);
                y_zh = JD_Y - T * Math.Sin(A1);
                x_hz = JD_X - T * Math.Cos(A2);
                y_hz = JD_Y - T * Math.Sin(A2);

                double fai, l, x, y, X, Y;
                l = 0;
                if(K<=Khy||K>=Kyh)
                {
                    if (K <= Khy)
                        l = K - Kzh;
                    if (Kyh <= K && K < Khz)
                        l = Khz - K;
                    x = l - Math.Pow(l, 5) / 40 / R / R / Ls / Ls;
                    y = Math.Pow(l, 3) / 6 / R / Ls;
                }
                else
                {
                    l = K - Kzh;
                    fai = B + (l - Ls) * 180 / R / Math.PI;
                    x = m + R * Math.Sin(fai);
                    y = P + R * (1 - Math.Cos(fai));
                }
                if(K<Khy)
                {
                    X = x_zh + x * Math.Cos(A1) - D * y * Math.Sin(A1);
                    Y = y_zh + x * Math.Sin(A1) + D * y * Math.Cos(A1);
                }
                else
                {
                    X = x_hz + x * Math.Cos(A2) + D * y * Math.Sin(A2);
                    Y = y_hz + x * Math.Sin(A2) - D * y * Math.Cos(A2);
                }
                MessageBox.Show("曲线要素是："+"T:"+T.ToString()+"\n"+"L:" + L.ToString()+"\n"+ "E:" + E.ToString()+"\n"+ "q:" + q.ToString() + "\n"+"结果是：(" + X.ToString() + "," + Y.ToString() + ")");
                Point ZH = new Point();
                Point HZ = new Point();
                Point FY = new Point();
                ZH.X = Convert.ToInt32(x_zh);
                ZH.Y = Convert.ToInt32(y_zh);
                HZ.X = Convert.ToInt32(x_hz);
                HZ.Y = Convert.ToInt32(y_hz);
                FY.X = Convert.ToInt32(X);
                FY.Y = Convert.ToInt32(Y);
            }
        }

        private void 导入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string info = openFileDialog1.FileName;
                if ((info.Substring(info.IndexOf(".") + 1) != "txt"))
                    MessageBox.Show("文件格式错误，请选择文本文件！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StreamReader fs = new StreamReader(info);
                string s=fs.ReadLine();
                string[] ss = s.Split(',');
                ZHX_V.Text = ss[0];
                ZHY_V.Text = ss[1];
                JDX_V.Text = ss[2];
                JDY_V.Text = ss[3];
                ROTATE_V_D.Text = ss[4];
                ROTATE_V_F.Text = ss[5];
                ROTATE_V_M.Text = ss[6];
                RADIUS_V.Text = ss[7];
                HCLENGTH_V.Text = ss[8];
                KJD_V.Text = ss[9];
                KI_V.Text = ss[10];
                if (ss[11] == "1")
                    DIR_RIGHT.Checked = true;
                if (ss[11] == "-1")
                    DIR_LEFT.Checked = true;
            }
        }
    }
}
