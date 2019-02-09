using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public class Program {
        static void Main(string[] args) {
            var workerIdentNumber = new Guid();

            var workerWithoutOverridenEquals_1 = new WorkerWithoutOverridenEquals() {
                Name = "Ivan",
                IdentificationNumber = workerIdentNumber
            };
            var workerWithoutOverridenEquals_2 = new WorkerWithoutOverridenEquals() {
                Name = "Ivan",
                IdentificationNumber = workerIdentNumber
            };

            var workerWithOverridenEquals_1 = new WorkerWithOverridenEquals() {
                Name = "Max",
                IdentificationNumber = workerIdentNumber
            };
            var workerWithOverridenEquals_2 = new WorkerWithOverridenEquals() {
                Name = "Max",
                IdentificationNumber = workerIdentNumber
            };

            var pointWithoutOverridenEquals_0_0_1 = new PointWithoutOverridenEquals(0, 0, 1);
            var pointWithoutOverridenEquals_0_0_2 = new PointWithoutOverridenEquals(0, 0, 2);
            var pointWithOverridenEquals_0_0_1 = new PointWithOverridenEquals(0, 0, 1);
            var pointWithOverridenEquals_0_0_2 = new PointWithOverridenEquals(0, 0, 2);

            string string_base = "string";
            string string1_1 = "string1";
            string string1_2 = "string1";
            string string2 = "string2";

            // 1) Object.Equals
            if (true) {
                // 1.1) ReferenceEquals 
                if (true) {
                    // 1.1.1) ReferenceType
                    bool isReferenceEquals_ReferenceType_WithoutOverriden_1_2 =
                        Object.ReferenceEquals(workerWithoutOverridenEquals_1, workerWithoutOverridenEquals_2);
                    bool isReferenceEquals_ReferenceType_WithOverriden_1_2 =
                        Object.ReferenceEquals(workerWithOverridenEquals_1, workerWithOverridenEquals_2);
                    bool isReferenceEquals_ReferenceType_1_1 =
                        Object.ReferenceEquals(workerWithOverridenEquals_1, workerWithOverridenEquals_1);
                    // 1.1.2) ValueType
                    bool isReferenceEquals_ValueType_1_2 =
                        Object.ReferenceEquals(pointWithoutOverridenEquals_0_0_1, pointWithoutOverridenEquals_0_0_2);
                    bool isReferenceEquals_ValueType_1_1 =
                        Object.ReferenceEquals(pointWithoutOverridenEquals_0_0_1, pointWithoutOverridenEquals_0_0_1);
                    // HW boxing/Unboxing
                    // 1.1.3) String
                    bool isReferenceEquals_String_1_2 = object.ReferenceEquals(string1_1, string2);
                    bool isReferenceEquals_String_1_1_vs_1_1 = object.ReferenceEquals(string1_1, string1_1);
                    bool isReferenceEquals_String_1_1_vs_1_2 = object.ReferenceEquals(string1_1, string1_2);
                    bool isReferenceEquals_String_1_1_vs_modified = object.ReferenceEquals(string1_1, "string" + "1");
                    bool isReferenceEquals_String_1_1_vs_modified_base = object.ReferenceEquals(string1_1, string_base + "1");
                }

                // 1.2) public virtual bool Equals(object obj)
                if (true) {
                    // 1.2.1) ReferenceType
                    bool isEquals_ReferenceType_WithoutOverriden_1_2 =
                        workerWithoutOverridenEquals_1.Equals(workerWithoutOverridenEquals_2);
                    bool isEquals_ReferenceType_WithOverriden_1_2 =
                        workerWithOverridenEquals_1.Equals(workerWithOverridenEquals_2);
                    bool isEquals_ReferenceType_1_1 =
                        workerWithOverridenEquals_1.Equals(workerWithOverridenEquals_1);
                    // 1.2.2) ValueType
                    bool isEquals_ValueType_WithoutOverriden_1_2 =
                        pointWithoutOverridenEquals_0_0_1.Equals(pointWithoutOverridenEquals_0_0_2);
                    bool isEquals_ValueType_WithoutOverriden_1_1 =
                        pointWithoutOverridenEquals_0_0_1.Equals(new PointWithoutOverridenEquals(0, 0, 1));

                    bool isEquals_ValueType_WithOverriden_1_2 =
                        pointWithOverridenEquals_0_0_1.Equals(pointWithOverridenEquals_0_0_2);
                    bool isEquals_ValueType_WithOverriden_1_1 =
                        pointWithOverridenEquals_0_0_1.Equals(new PointWithoutOverridenEquals(0, 0, 1));
                    // 1.2.3) String
                    bool isReferenceEquals_String_1_2 = string1_1.Equals(string2);
                    bool isReferenceEquals_String_1_1_vs_1_1 = string1_1.Equals(string1_1);
                    bool isReferenceEquals_String_1_1_vs_1_2 = string1_1.Equals(string1_2);
                    bool isReferenceEquals_String_1_1_vs_modified = string1_1.Equals("string" + "1");
                    bool isReferenceEquals_String_1_1_vs_modified_base = string1_1.Equals(string_base + "1");
                }

                // 1.3) public static bool Equals(object objA, object objB)
                if (true) {
                    // HW - try at home
                }
                // 1.4) public static bool operator == (Foo left, Foo right)
                if (true) {
                    // HW - try at home 
                }
            }
            //2 Override operations
            if (true) {
                PointWithOverridenEquals minusPoint = new PointWithOverridenEquals(5, 5, 0) - new PointWithOverridenEquals(3, 3, 1);

                PointWithOverridenEquals plusPoint = new PointWithOverridenEquals(5, 5, 0) + new PointWithOverridenEquals(3, 3, 1);
                // TODO: Show Point

                WorkerWithOverridenEquals workerPlus = workerWithOverridenEquals_1 - workerWithOverridenEquals_2;

                WorkerWithOverridenEquals minusWorker = workerWithOverridenEquals_1 + workerWithOverridenEquals_2;

                bool isBigger = new WorkerWithOverridenEquals() { Name= "1" } > new WorkerWithOverridenEquals() { Name = "12" };

                bool isLess = new WorkerWithOverridenEquals() { Name = "1" } < new WorkerWithOverridenEquals() { Name = "12" };
            }
        }
    }
}
