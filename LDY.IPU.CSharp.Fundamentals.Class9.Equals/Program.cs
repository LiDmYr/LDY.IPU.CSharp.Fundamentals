using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public class Program {
        static void Main(string[] args) {
            var worker1 = new Worker() { Name = "Ivan" };
            var worker2 = new Worker() { Name = "Serg" };
            var point_0_0_first = new Point(0, 0);
            var point_0_0_second = new Point(0, 0);
            var point_1_1 = new Point(1, 1);

            var result = object.Equals(worker1, point_0_0_first);
            var results = object.Equals(worker1, worker2);

            // 1) Object.Equals
            if (true) {
                // 1.1) ReferenceEquals 

                // 1.1.1) ReferenceType

                // 1.1.2) ValueType

                // 1.2) public virtual bool Equals(object obj)

                // 1.2.1) ReferenceType
                bool isEqual_Ref_Equals = worker1.Equals(worker2);
                // 1.2.2) ValueType
                bool isEqual_Value_Equals = point_0_0_first.Equals(point_0_0_second);
                bool isEqual_Value_Equals2 = point_0_0_first.Equals(point_1_1);
                
                // 1.3) public static bool Equals(object objA, object objB)
                // 1.3.1) ReferenceType
                // 1.3.2) ValueType

                // 1.4) public static bool operator == (Foo left, Foo right)
                // 1.4.1) ReferenceType
                // 1.4.2) ValueType
            }
            //2 Override operations
            if (true) {
                Point minusPoint = point_0_0_first - point_1_1;

                Point plusPoint = point_0_0_first + point_1_1;
                // TODO: Show Point

                Worker workerPlus = worker1 - worker2;

                Worker minusWorker = worker2 + worker1;
            }
        }
    }




}
