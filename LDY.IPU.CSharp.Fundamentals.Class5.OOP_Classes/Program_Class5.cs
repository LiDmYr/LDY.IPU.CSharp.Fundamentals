using System;
using System.Collections;
using System.Collections.Generic;
// using System.Linq;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes {
    internal class Program_Class5 {
        private static void aMain(string[] args) {
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
            if (true) {
                int StaticClassStaticIntBefore = StaticClass.StaticInt;
                StaticClass.StaticInt = 10;
                StaticClass.StaticMethod();

                //var personNotStaticClass1 = new PersonNotStaticClass();
                //var personNotStaticClass2 = new PersonNotStaticClass("Name");
                //var personNotStaticClass3 = new PersonNotStaticClass();
                //int personsCount = PersonNotStaticClass.PersonsCount;

                PersonNotStaticClass instance1 = PersonNotStaticClass.GetInstance("1");
                PersonNotStaticClass instance2 = PersonNotStaticClass.GetInstance("2");
                var name = instance2.Name;
            }

            // 4) ListCollectionUsing
            if (true) {
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

            // 5) Inheritance
            //var human = new Human() { Name = "Ivan" };
            //human.Show();
            //human = new Worker { Name = "Olena", Salary = 2000 };
            //human.Show();
        }
    }

    #region 1) Default values + Null
    public class PersonDefaultValueNull {
        public PersonDefaultValueNull PersonDefaultValueNull_Instance { get; set; }

        public int[] IntArrayProperty { get; set; }

        public int IntProperty { get; set; }

        public bool BoolProperty { get; set; }

        public float FloatProperty { get; set; }

        public PersonDefaultValueNull() {

        }

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
        public static int StaticInt;

        public static void StaticMethod() {
            StaticInt++;
        }
    }

    public class PersonNotStaticClass {
        //public static int PersonsCount { get; private set; }
        private static PersonNotStaticClass Instance;
        public string Name { get; private set; }

        private PersonNotStaticClass(string name) {
            this.Name = name;
            // PersonsCount++;
        }
        #region MyRegion
        //private PersonNotStaticClass(string name) : this() {
        //    this.Name = name;
        //}

        //public int GetPersonsCount() {
        //    return PersonsCount;
        //} 
        #endregion
        // Singleton
        public static PersonNotStaticClass GetInstance(string name) {
            // ctor - private;
            if (Instance == null) {
                Instance = new PersonNotStaticClass(name);
            }
            return Instance;
        }
        //Array sort;
    }
    #endregion

    #region 5) Inheritance
    internal class Human {
        public string Name { get; private set; }

        public Human() {

        }
        public Human(string v) {
            this.Name = v;
        }

        public virtual void Show() { Console.WriteLine($"Name = {this.Name}"); }
    }

    internal class Worker : Human {
        public int Salary { get; set; }

        public override void Show() {
            base.Show();
            Console.WriteLine($"Salary = {this.Salary}");
        }
    }
    #endregion



}