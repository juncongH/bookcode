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

namespace test01
{
    public partial class Form1 : Form
    {
        formula f = new formula();
        List<data> Data;
        List<result> Result = new List<result>();
        string text;

        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ReadFile(out Data);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Y, M, D, H, N, S;
            data p1 = new data();
            data p2 = new data();
            result r;
            for (int i=0;i<Data.Count-1;i++)
            {
                r = new result();
                p1 = Data[i];
                p2 = Data[i + 1];
                r.name = Convert.ToString(i);
                f.transtime(p1.time, out Y, out M, out D, out H, out N, out S);
                f.CalMJD(D, Y, M, H, N, S, out r.MJD1);
                f.transtime(p2.time, out Y, out M, out D, out H, out N, out S);
                f.CalMJD(D, Y, M, H, N, S, out r.MJD2);
                f.CalSpeedAngle(p1, p2, out r.speed, out r.angle);

                Result.Add(r);
            }
            f.Report(Result, out text);
            richTextBox1.Text = text;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter w;
            saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arr = text.Split('\n');
                w = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < arr.Count(); i++)
                {
                    w.WriteLine(arr[i]);
                }
                w.Close();
            }
        }
    }
}
