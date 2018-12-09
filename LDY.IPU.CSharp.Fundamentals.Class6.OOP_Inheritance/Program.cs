using System;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance {
    public class Program {
        private static void Main(string[] args) {
            // 1) Inheritance
            if (true) {
                Human human1 = new Human("Ivan");
                Worker humanSecond = new Worker("Olena", 2000);

                Introduce(human1, humanSecond);

            }

            // 2) Override object ToString()
            var human2 = new Human("Ivan");
            string humanString = human2.ToString();
            string text1 = 1.ToString();
            string text2 = new double[]{ }.ToString();
            false.ToString();

            // 3) Sealed
            // +

            // 4) Access to Private members of a base class
            // +

            // 5) Constructor calling sequeance - 1 example
            // +

            // 6) Virtual / override
            // +

            // 7) Abstract class + members
            // +
        }

        internal static void Introduce(Human h1, Human h2) {
            h1.Introduce();
            h2.Introduce();
        }

    }

    #region 1) Inheritance + 2)
    internal class Human {

        public string Name { get; private set; }

        public Human(string name) {
            this.Name = name;
        }

        public virtual void Introduce() {
            Console.WriteLine($"My Name is {this.Name}");
        }
    }

    internal class Worker : Human {
        public int Salary { get; private set; }

        public Worker(string name, int salary) : base(name) {
            this.Salary = salary;
        }

        public override void Introduce() {
            // base.Introduce();
            Console.WriteLine($"My Salary is {this.Salary} USD");
        }
    }
    #endregion
}
