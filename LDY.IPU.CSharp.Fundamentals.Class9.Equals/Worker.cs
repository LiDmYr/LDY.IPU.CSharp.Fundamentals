using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public class Worker {
        public string Name { get; set; }

        public void getMemebers() {
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public static Worker operator +(Worker worker1, Worker worker2) {
            return new Worker() { Name = worker1.Name + worker2.Name };
        }

        public static Worker operator -(Worker worker1, Worker worker2) {
            return new Worker() { Name = worker1.Name.Replace(worker2.Name, "")};
        }

        public static bool operator >(Worker worker1, Worker worker2) {
            return worker1.Name.Length > worker2.Name.Length;
        }

        public static bool operator <(Worker worker1, Worker worker2) {
            return worker1.Name.Length < worker2.Name.Length;
        }

        public static bool operator >=(Worker worker1, Worker worker2) {
            return worker1.Name.Length >= worker2.Name.Length;
        }

        public static bool operator <=(Worker worker1, Worker worker2) {
            return worker1.Name.Length <= worker2.Name.Length;
        }
    }
}
