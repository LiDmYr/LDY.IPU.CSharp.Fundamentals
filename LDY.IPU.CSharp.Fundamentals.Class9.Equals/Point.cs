using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public struct Point {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public static Point operator +(Point p1, Point p2) {
            return new Point(p1.X + p2.Y, p1.X + p2.Y);
        }

        public static Point operator -(Point p1, Point p2) {
            return new Point(p1.X - p2.Y, p1.X - p2.Y);
        }
    }
}
