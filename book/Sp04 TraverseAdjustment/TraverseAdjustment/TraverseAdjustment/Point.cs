using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraverseAdjustment
{
    class Point
    {
        //点类：点名，观测角，下一条边方位角，下一条边长度，坐标增量，坐标
        public string Name { get; set; }
        public double Angle { get; set; }
        public double Azimuth { get; set; }
        public double S { get; set; }
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
