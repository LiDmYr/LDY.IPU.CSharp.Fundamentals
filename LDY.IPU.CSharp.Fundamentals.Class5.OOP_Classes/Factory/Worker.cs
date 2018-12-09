using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    public class Worker {
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public Worker(string name,int capacity) {
            this.Name = name;
            this.Capacity = capacity;
        }   
    }
}
