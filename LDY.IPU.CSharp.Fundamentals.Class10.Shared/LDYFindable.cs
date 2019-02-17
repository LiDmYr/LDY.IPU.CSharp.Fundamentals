using LDY.IPU.CSharp.Fundamentals.Class10.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Shared {
    public class LDYFindableA : IFindable {
        public string Name => "LDYFindableA";

        public int Number { get; }

        public LDYFindableA(int number) {
            Number = number;
        }

        public void SaySomething() {
            Console.WriteLine("SaySomething - LDYFindableA");
        }
    }

    public class LDYFindableB : IFindable {
        public string Name => "LDYFindableB";

        public int Number { get; }

        public LDYFindableB(int number) {
            Number = number;
        }

        public void SaySomething() {
            Console.WriteLine("SaySomething - LDYFindableA");
        }
    }

    public class LDYFindableC : IFindable {
        public string Name => "LDYFindableC";

        public int Number { get; }

        public LDYFindableC(int number) {
            Number = number;
        }

        public void SaySomething() {
            Console.WriteLine("SaySomething - LDYFindableA");
        }
    }
}
