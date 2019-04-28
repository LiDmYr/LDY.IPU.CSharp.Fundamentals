using System;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public class Program {
        static void Main(string[] args) {
            // predefine data for examples
            var workerIdentNumber = Guid.NewGuid();

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

            // String is ref or value?
            ModifyString(string_base);

            // 1) Object.Equals
            if (false) {
                // 1.1) ReferenceEquals 
                if (false) {
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
                    {
                        var res1 = 1.Equals(1); // 1 == 1
                        object obj1 = (object)1; //boxing
                        int intValue = (int)obj1; //unboxing
                        var res2 = 1.Equals(obj1);
                        var boolEquility = false.Equals(false);
                    }

                    // 1.1.3) String
                    bool isReferenceEquals_String_1_2 = 
                        object.ReferenceEquals(string1_1, string2);
                    bool isReferenceEquals_String_1_1_vs_1_1 = 
                        object.ReferenceEquals(string1_1, string1_1);
                    bool isReferenceEquals_String_1_1_vs_1_2 = 
                        object.ReferenceEquals(string1_1, string1_2);
                    bool isReferenceEquals_String_1_1_vs_modified = 
                        object.ReferenceEquals(string1_1, "string" + "1");
                    bool isReferenceEquals_String_1_1_vs_modified_base = 
                        object.ReferenceEquals(string1_1, string_base + "1");
                }

                // 1.2) public virtual bool Equals(object obj)
                if (false) {
                    // 1.2.1) ReferenceType
                    bool isVirtualEquals_ReferenceType_WithoutOverriden_1_2 =
                        workerWithoutOverridenEquals_1.Equals(workerWithoutOverridenEquals_2);
                    bool isVirtualEquals_ReferenceType_WithOverriden_1_2 =
                        workerWithOverridenEquals_1.Equals(workerWithOverridenEquals_2);
                    bool isVirtualEquals_ReferenceType_1_1 =
                        workerWithOverridenEquals_1.Equals(workerWithOverridenEquals_1);
                    
                    // 1.2.2) ValueType
                    bool isVirtualEquals_ValueType_WithoutOverriden_1_2 =
                        pointWithoutOverridenEquals_0_0_1.Equals(pointWithoutOverridenEquals_0_0_2);
                    bool isVirtualEquals_ValueType_WithoutOverriden_1_1 =
                        pointWithoutOverridenEquals_0_0_1.Equals(new PointWithoutOverridenEquals(0, 0, 1));

                    bool isVirtualEquals_ValueType_WithOverriden_1_2 =
                        pointWithOverridenEquals_0_0_1.Equals(pointWithOverridenEquals_0_0_2);
                    bool isVirtualEquals_ValueType_WithOverriden_1_1 =
                        pointWithOverridenEquals_0_0_1.Equals(new PointWithoutOverridenEquals(0, 0, 1));

                    // 1.2.3) String
                    bool isVirtualEquals_String_1_2 = string1_1.Equals(string2); 
                    bool isVirtualEquals_String_1_1_vs_1_1 = string1_1.Equals(string1_1);
                    bool isVirtualEquals_String_1_1_vs_1_2 = string1_1.Equals(string1_2); 
                    bool isVirtualEquals_String_1_1_vs_modified = string1_1.Equals("string" + "1"); 
                    bool isVirtualEquals_String_1_1_vs_modified_base = string1_1.Equals(string_base + "1"); 
                }

                // 1.3) public static bool Equals(object objA, object objB)
                if (false) {
                    // HW - try at home
                }
                // 1.4) public static bool operator == (Foo left, Foo right)
                if (false) {
                    // HW - try at home 
                }
            }
            //2 Override operations
            if (false) {
                PointWithOverridenEquals minusPoint =
                    new PointWithOverridenEquals(5, 5, 0) - new PointWithOverridenEquals(3, 3, 1);

                PointWithOverridenEquals plusPoint = 
                    new PointWithOverridenEquals(5, 5, 0) + new PointWithOverridenEquals(3, 3, 1);
                // TODO: Show Point

                WorkerWithOverridenEquals workerPlus = workerWithOverridenEquals_1 - workerWithOverridenEquals_2;

                if (workerPlus) {
                    { }
                }

                WorkerWithOverridenEquals minusWorker = workerWithOverridenEquals_1 + workerWithOverridenEquals_2;

                bool isBigger = new WorkerWithOverridenEquals() { Name= "1" } > new WorkerWithOverridenEquals() { Name = "12" };

                bool isLess = new WorkerWithOverridenEquals() { Name = "1" } < new WorkerWithOverridenEquals() { Name = "12" };
            }

            // 3  Ref + Out
            if (false) {
                PersonRefOut PersonRefOut1 = new PersonRefOut();
                PersonRefOut PersonRefOut2 = new PersonRefOut();
                PersonRefOut.SetNewProperties(PersonRefOut1, ref PersonRefOut2);
                PersonRefOut.SetNewProperties(PersonRefOut1, ref PersonRefOut2);

                PersonRefOut PersonRefOut3 = new PersonRefOut();
                PersonRefOut PersonRefOut4 = new PersonRefOut();
                PersonRefOut.SetNewReference(PersonRefOut3, ref PersonRefOut4);
                PersonRefOut.SetNewReference(PersonRefOut3, ref PersonRefOut4);

                PersonRefOut PersonRefOut5 = new PersonRefOut();
                int randomAgeOutput;
                PersonRefOut.SetNewRandomAge(PersonRefOut5, out randomAgeOutput);
                PersonRefOut.SetNewAge(PersonRefOut5, ref randomAgeOutput);
            }

        }

        private static void ModifyString(string string_base) {
            string_base = null;
        }
    }

    #region 3) Ref + Out
    public class PersonRefOut {
        public string Name { get; set; }

        public int Age { get; set; }

        private static Random Random = new Random();

        public static void SetNewProperties(PersonRefOut Person, ref PersonRefOut RefPerson) {
            Person.Age = 100;
            Person.Name = "NEW";
            RefPerson.Age = 100;
            RefPerson.Name = "NEW";
        }

        public static void SetNewReference(PersonRefOut Person, ref PersonRefOut RefPerson) {
            Person = new PersonRefOut() { Age = 100, Name = "NEW" };
            RefPerson = new PersonRefOut() { Age = 100, Name = "NEW" };
        }

        //static
        public static void SetNewRandomAge(PersonRefOut Person, out int randomAge) {
            randomAge = Random.Next(20, 50);
            Person.Age = randomAge;
        }

        public static void SetNewAge(PersonRefOut Person, ref int age) {
            age = 10;
            Person.Age = age;
        }
    }
    #endregion
}
