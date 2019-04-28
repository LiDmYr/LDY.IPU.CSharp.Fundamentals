using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class9.Equals {
    public abstract class Worker {
        public Guid IdentificationNumber { get; set; }

        public string Name { get; set; }

        public override string ToString() {
            return $"Name={Name},IdentificationNumber={IdentificationNumber}";
        }
    }

    public class WorkerWithoutOverridenEquals : Worker {

    }

    public class WorkerWithOverridenEquals : Worker {
        public override bool Equals(object obj) {
            var workerObj = obj as WorkerWithOverridenEquals;
            if (workerObj == null) {
                return false;
            }
            return workerObj.IdentificationNumber == this.IdentificationNumber;
        }

        public static WorkerWithOverridenEquals operator +(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return new WorkerWithOverridenEquals() { Name = worker1.Name + worker2.Name };
        }

        public static WorkerWithOverridenEquals operator -(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return new WorkerWithOverridenEquals() { Name = worker1.Name.Replace(worker2.Name, "") };
        }

        public static bool operator >(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return worker1.Name.Length > worker2.Name.Length;
        }

        public static bool operator <(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return worker1.Name.Length < worker2.Name.Length;
        }

        public static bool operator >=(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return worker1.Name.Length >= worker2.Name.Length;
        }

        public static bool operator <=(WorkerWithOverridenEquals worker1, WorkerWithOverridenEquals worker2) {
            return worker1.Name.Length <= worker2.Name.Length;
        }

        public static bool operator true(WorkerWithOverridenEquals worker) {
            return !string.IsNullOrWhiteSpace(worker.Name);
        }

        public static bool operator false(WorkerWithOverridenEquals worker) {
            return string.IsNullOrWhiteSpace(worker.Name);
        }

    }
}
