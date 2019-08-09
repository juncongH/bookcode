using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridVolume
{
    class GridPoint
    {
        public Point p1 { set; get; }
        public Point p2 { set; get; }
        public Point p3 { set; get; }
        public Point p4 { set; get; }
        public Point p0 { set; get; }
        public bool InPoly;
    }
}
