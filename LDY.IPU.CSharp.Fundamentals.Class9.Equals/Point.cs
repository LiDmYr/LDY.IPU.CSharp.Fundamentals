using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public struct PointWithoutOverridenEquals {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PointWithoutOverridenEquals(int x, int y, int id) {
            Id = id;
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"Id={Id},X={X},Y={Y}";
        }
    }

    public struct PointWithOverridenEquals {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PointWithOverridenEquals(int x, int y, int id) {
            Id = id;
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            if (!(obj is PointWithOverridenEquals)) {
                return false;
            }
            var pointObj = (PointWithOverridenEquals)obj;
            return pointObj.X == this.X && pointObj.Y == this.Y;
        }

        public static PointWithOverridenEquals operator +(PointWithOverridenEquals p1, PointWithOverridenEquals p2) {
            return new PointWithOverridenEquals(p1.X + p2.Y, p1.X + p2.Y, p1.Id + p2.Id);
        }

        public static PointWithOverridenEquals operator -(PointWithOverridenEquals p1, PointWithOverridenEquals p2) {
            return new PointWithOverridenEquals(p1.X - p2.Y, p1.X - p2.Y, p1.Id - p2.Id);
        }

        public override string ToString() {
            return $"Id={Id},X={X},Y={Y}";
        }
    }
}
