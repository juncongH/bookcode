using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test04
{
    public partial class Form1 : Form
    {
        formula f = new formula();
        List<data> Data;
        List<result> S;
        List<result> U=new List<result>();

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
            

            result r1 = new result(), r2 = new result(), r3 = new result(), r4 = new result();
            r1.name = "地大";
            r2.name = "光谷";
            r3.name = "图书城";
            r4.name = "华工";
            r1.s = r2.s = r3.s = r4.s = 9999;
            U.Add(r1);
            U.Add(r2);
            U.Add(r3);
            U.Add(r4);

            f.Cal(Data, U, out S);

        }
    }
}
