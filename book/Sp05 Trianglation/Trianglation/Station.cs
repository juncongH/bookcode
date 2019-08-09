using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trianglation
{
    class Station
    {
        public string Seg_name { set; get; }
        public string toandfor { set; get; }
        public double S { set; get; }
        public double Alpha { set; get; }
        public double i { set; get; }
        public double v { set; get; }
        public double f { set; get; }
        public double D { set; get; }
        public double h { set; get; }
        public double h_ave { set; get; }
        public string TorF { set; get; }
    }

    class DStation
    {
        public string Seg_name { set; get; }
        public string toandfor { set; get; }
        public string  S { set; get; }
        public string Alpha { set; get; }
        public string i { set; get; }
        public string v { set; get; }
        public string f { set; get; }
        public string D { set; get; }
        public string h { set; get; }
        public string h_ave { set; get; }
        public string TorF { set; get; }
    }

    class HStation
    {
        public string seg_name { set; get; }
        public double h { set; get; }
        public double h_v { set; get; }
        public double D { set; get; }
        public double v { set; get; }
        public double Hs { set; get; }
        public double He { set; get; }
    }
}
