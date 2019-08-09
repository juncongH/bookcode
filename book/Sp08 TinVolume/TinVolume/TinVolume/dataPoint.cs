using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinVolume
{
    class dataPoint
    {
        public string Name { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
        public double H { set; get; }
    }

    class Point : dataPoint
    {
        public int num { set; get; }
    }

    class Line
    {
        public Point p1 { set; get; }
        public Point p2 { set; get; }

        public Line Newline(Point pp1, Point pp2)
        {
            Line line = new Line();
            if (pp1.num < pp2.num)
            {
                line.p1 = pp1;
                line.p2 = pp2;
            }
            else
            {
                line.p1 = pp2;
                line.p2 = pp1;
            } 
            return line;
        }
    }

    class Triangle
    {
        public string Name { set; get; }
        public Point p1 { set; get; }
        public Point p2 { set; get; }
        public Point p3 { set; get; }
        public Line l1 { set; get; }
        public Line l2 { set; get; }
        public Line l3 { set; get; }

        //三角形定义方式1
        public Triangle NewTriangle(Point pp1, Point pp2, Point pp3)
        {
            Triangle t = new Triangle();

            Point p = new Point();
            if (pp1.num > pp2.num)
            {
                p = pp2; pp2 = pp1; pp1 = p;
            }
            if (pp2.num > pp3.num)
            {
                p = pp3; pp3 = pp2; pp2 = p;
            }
            if (pp1.num > pp2.num)
            {
                p = pp2; pp2 = pp1; pp1 = p;
            }

            t.p1 = pp1; t.p2 = pp2; t.p3 = pp3;
            t.Name = pp1.Name + pp2.Name + pp3.Name;
            Line l;
            l = new Line(); l = l.Newline(pp1, pp2); t.l1 = l;
            l = new Line(); l = l.Newline(pp2, pp3); t.l2 = l;
            l = new Line(); l = l.Newline(pp1, pp3); t.l3 = l;

            return t;
        }

        //三角形定义方式2
        public Triangle NewTriangle(Line l, Point p)
        {
            Triangle t = new Triangle();
            if (p.num < l.p1.num)
            {
                t.p1 = p; t.p2 = l.p1; t.p3 = l.p2;
            }
            if (l.p1.num < p.num && l.p2.num > p.num)
            {
                t.p1 = l.p1; t.p2 = p; t.p3 = l.p2;
            }
            if (p.num > l.p2.num)
            {
                t.p1 = l.p1; t.p2 = l.p2; t.p3 = p;
            }
            t.Name = t.p1.Name + t.p2.Name + t.p3.Name;
            Line ll;
            ll = new Line(); ll = ll.Newline(t.p1, t.p2); t.l1 = ll;
            ll = new Line(); ll = ll.Newline(t.p2, t.p3); t.l2 = ll;
            ll = new Line(); ll = ll.Newline(t.p1, t.p3); t.l3 = ll;

            return t;
        }

    }
}
