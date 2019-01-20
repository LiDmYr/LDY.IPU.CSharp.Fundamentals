using System;
using System.Collections;
using System.Collections.Generic;
// using System.Linq;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes {
    internal class Program {
        private static void Main(string[] args) {
            // 1) Default values + Null
            if (false) {
                var personDefaultValueNull = new PersonDefaultValueNull();
                personDefaultValueNull.ShowPropertiesValues();
            }

            // 2) Class in separated file.cs
            if (false) {
                //PersonSeparatedFile personSeparatedFile = new PersonSeparatedFile();
            }

            // 3) Static Class
            if (false) {
                int StaticClassStaticIntBefore = StaticClass.StaticFlag;
                StaticClass.StaticFlag = 10;
                StaticClass.IncrementStaticFlagViaMethod();

                var personNotStaticClass1 = new PersonNotStaticClass("1");
                var personNotStaticClass2 = new PersonNotStaticClass("Name");
                var personNotStaticClass3 = new PersonNotStaticClass("2");

                int personsCount = PersonNotStaticClass.PersonsCount;
                int PersonsCount1 = personNotStaticClass1.GetPersonsCount();
                int PersonsCount2 = personNotStaticClass2.GetPersonsCount();
                int PersonsCount3 = personNotStaticClass3.GetPersonsCount();
                int personsCountStatic = PersonNotStaticClass.GetPersonsCountStatic();
            }

            // 4) Singleton
            if (false) {
                PersonSingleton instance1 = PersonSingleton.GetInstance("1");
                PersonSingleton instance2 = PersonSingleton.GetInstance("2");
                var name = instance2.Name;
            }

            // 5) ListCollectionUsing
            if (false) {
                List<Human> persons1 = new List<Human>();
                for (int i = 0; i < 3; i++) {
                    persons1.Add(new Human("Name_list1_" + i));
                }
                List<Human> persons2 = new List<Human>();
                for (int i = 0; i < 40; i++) {
                    persons2.Add(new Human("Name_list2_" + i.ToString()));
                }

                var human = new Human("Added by hand");
                persons1.Add(human);

                persons1.AddRange(persons2);
                persons1.Remove(human);

                int length = persons1.Count;
            }
        }
    }

    #region 1) Default values + Null
    public class PersonDefaultValueNull {
        public PersonDefaultValueNull PersonDefaultValueNull_Instance { get; set; }

        public int[] IntArrayProperty { get; set; }

        public int IntProperty { get; set; }

        public bool BoolProperty { get; set; }

        public float FloatProperty { get; set; }

        public void ShowPropertiesValues() {
            //Console.WriteLine($"PersonDefaultValueNull_Instance={this.PersonDefaultValueNull_Instance.ToString()}");
            Console.WriteLine("this.PersonDefaultValueNull_Instance = " + this.PersonDefaultValueNull_Instance);
            Console.WriteLine("this.IntArrayProperty = " + this.IntArrayProperty);
            Console.WriteLine("this.IntProperty = " + this.IntProperty);
            Console.WriteLine("this.BoolProperty = " + this.BoolProperty);
            Console.WriteLine("this.FloatProperty = " + this.FloatProperty);
        }
    }
    #endregion

    #region 2) Class in separated file.cs
    // Separated.
    #endregion

    #region 3) StaticClass
    public static class StaticClass {
        public static int StaticFlag;

        public static void IncrementStaticFlagViaMethod() {
            StaticFlag++;
        }
    }

    public class PersonNotStaticClass {
        public static int PersonsCount { get; private set; }

        public string Name { get; private set; }

        public PersonNotStaticClass(string name) {
            this.Name = name;
            PersonsCount++;
        }

        public int GetPersonsCount() {
            return PersonsCount;
        }

        public static int GetPersonsCountStatic() {
            return PersonsCount;
        }


        public static string GetNameStatic(PersonNotStaticClass person) {
            return person.Name;
        }
    }
    #endregion

    #region 4) Singleton
    public class PersonSingleton {
        private static PersonSingleton Instance;

        public string Name { get; private set; }

        private PersonSingleton(string name) {
            this.Name = name;
        }

        public static PersonSingleton GetInstance(string name) {
            if (Instance == null) {
                Instance = new PersonSingleton(name);
            }
            return Instance;
        }
    }
    #endregion

    #region 5) ListCollectionUsing
    internal class Human {
        public string Name { get; private set; }

        public Human(string name) {
            this.Name = name;
        }

        public virtual void ShowSpecificToCurrentTypeInfo() {
            Console.WriteLine($"ShowSpecificInfo: Name = {this.Name}");
        }

        public virtual void ShowAllInfo() {
            Console.WriteLine($"ShowAllInfo: Name = {this.Name}");
        }
    }
    #endregion

}