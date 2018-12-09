using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    public class Item {
        public string Name { get; private set; }
        public bool IsCompleted {
            get {
                return this.CompletedCapacity >= this.WholeCapacity;
            }
        }
        public int WholeCapacity { get; set; } 
        public int CompletedCapacity { get; private set; }

        public Item(string name, int wholeCapacity) {
            this.Name = name;
            this.WholeCapacity = wholeCapacity;
        }

        public void ChangeProgress(int capacity) {
            this.CompletedCapacity += capacity;
        }

        internal void ChangeProgress(object capacity) {
            throw new NotImplementedException();
        }
    }
}
