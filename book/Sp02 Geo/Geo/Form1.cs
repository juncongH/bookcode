using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Geo
{
    public partial class Form1 : Form
    {
        Formula formula = new Formula();

        //椭球参数
        double a;
        double f;
        //datagridview显示用的数据
        List<DGeoLine> DLines;
        //计算用的数据
        List<GeoLine> CLines;
        //datagridview数据绑定
        private BindingList<DGeoLine> Bdata;



        public Form1()
        {
            InitializeComponent();
        }

        private void 打开正算数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLines = new List<GeoLine>();
            DLines = new List<DGeoLine>();

            formula.Readfile1(out a, out f, out DLines, out CLines);

            Bdata = new BindingList<DGeoLine>(DLines);
            dataGridView1.DataSource = Bdata;

            MessageBox.Show("正算数据读取完成！");
        }

        private void 打开反算数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLines = new List<GeoLine>();
            DLines = new List<DGeoLine>();

            formula.Readfile2(out a, out f, out DLines, out CLines);

            Bdata = new BindingList<DGeoLine>(DLines);
            dataGridView1.DataSource = Bdata;

            MessageBox.Show("反算数据读取完成！");
        }

        private void 正算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DLines[0].B2 == null)
            {
                double n = CLines.Count;
                for (int i = 0; i < n; i++)
                {
                    double b1 = formula.Dms2Rad(CLines[i].B1);
                    double l1 = formula.Dms2Rad(CLines[i].L1);
                    double a1 = formula.Dms2Rad(CLines[i].A1);
                    double s  = CLines[i].S;
                    double b2,l2,a2;
                    formula.GeolineZheng(a, f, b1, l1, a1, s, out b2, out l2, out a2);
                    CLines[i].B2 = formula.Rad2Dms(b2);
                    CLines[i].L2 = formula.Rad2Dms(l2);
                    CLines[i].A2 = formula.Rad2Dms(a2);
                }

                for (int i = 0; i < n; i++)
                {
                    DLines[i].B2 = formula.Dms2Str(CLines[i].B2);
                    DLines[i].L2 = formula.Dms2Str(CLines[i].L2);
                    DLines[i].A2 = formula.Dms2Str(CLines[i].A2);
                }

                Bdata = new BindingList<DGeoLine>(DLines);
                dataGridView1.DataSource = Bdata;

                MessageBox.Show("正算完成！");


            }
            else
            {
                return;
            }
        }

        private void 反算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoLine G;
            DGeoLine M;
            for (int i = 0; i < CLines.Count; i++)
            {
                G = CLines[i];
                M = DLines[i];
                double S = G.S;
                double A1 = G.A1;
                double A2 = G.A2;
                formula.GeoLineFan(a, f, G, out S, out A1, out A2);
                M.S = S.ToString("f3");
                M.A1 = formula.Dms2Str(formula.Rad2Dms(A1));
                M.A2 = formula.Dms2Str(formula.Rad2Dms(A2));
            }

            Bdata = new BindingList<DGeoLine>(DLines);
            dataGridView1.DataSource = Bdata;
        }
    }
}
