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

                var personNotStaticClass1 = new PersonNotStaticClass();
                var personNotStaticClass2 = new PersonNotStaticClass("Name");
                var personNotStaticClass3 = new PersonNotStaticClass();

                int personsCount = PersonNotStaticClass.PersonsCount;
                int PersonsCount1 = personNotStaticClass1.GetPersonsCount();
                int PersonsCount2 = personNotStaticClass2.GetPersonsCount();
                int PersonsCount3 = personNotStaticClass3.GetPersonsCount();
            }

            // 4) Singleton
            if (false) {
                PersonSingleton instance1 = PersonSingleton.GetInstance("1");
                PersonSingleton instance2 = PersonSingleton.GetInstance("2");
                var name = instance2.Name;
            }

            // 5) ListCollectionUsing
            if (false) {
                List<Human> persons = new List<Human>();
                Human person = new Human("1");
                Human person2 = new Human("1");
                List<Human> subPersons = new List<Human>();
                //subPersons = new List<Human>() {
                //    new Human("2"),
                //    new Human("3"),
                //    new Human("2"),
                //    new Human("3"),
                //    new Human("2"),
                //    new Human("3"),
                //    new Human("2"),
                //    new Human("3")
                //};
                for (int i = 0; i < 3; i++) {
                    subPersons.Add(new Human(i.ToString()));
                }

                for (int i = 0; i < 40; i++) {
                    subPersons.Add(new Human(i.ToString()));
                }

                persons.Sort();

                persons.Add(person);
                //persons.AddRange(subPersons);
                persons.Remove(null);
                int length = persons.Count;
            }

            // 5) Inheritance Begin
            if (false) {
                var human = new Human("Ivan");
                human.ShowSpecificInfo();
                human.ShowAllInfo();
                var worker = new Worker(2000, "Olena");
                worker.ShowSpecificInfo();
                worker.ShowAllInfo();
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

        public PersonNotStaticClass() {
            Name = "DefaultValue";
        }

        public PersonNotStaticClass(string name) : this() {
            this.Name = name;
        }

        public int GetPersonsCount() {
            // return this.PersonsCount;
            return PersonsCount;
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

    #region 6) Inheritance Begin
    internal class Human {
        public string Name { get; private set; }

        public Human(string name) {
            this.Name = name;
        }

        public virtual void ShowSpecificInfo() {
            Console.WriteLine($"Name = {this.Name}");
        }

        public virtual void ShowAllInfo() {
            Console.WriteLine($"Name = {this.Name}");
        }
    }

    internal class Worker : Human {
        public int Salary { get; private set; }

        public Worker(int salary, string name) : base(name) {
            Salary = salary;
        }

        public override void ShowSpecificInfo() {
            base.ShowSpecificInfo();
            Console.WriteLine($"Salary = {this.Salary}");
        }

        public override void ShowAllInfo() {
            Console.WriteLine($"Name = {this.Name}, Salary = {this.Salary}");
        }
    }
    #endregion
}