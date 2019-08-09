using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelAdjust
{
    class Segment
    {
        public string startname { set; get; }
        public string endname { set; get; }
        public double Hs { set; get; }
        public double He { set; get; }
        public double dis { set; get; }
        public double deltaH { set; get; }
        public double v { set; get; }                               
    }
}
