using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class Generator {
        public Device Child { get; private set; }

        public int ProducedPower { get; private set; } = 1000;

        internal void PlugDevice(Device child) {
            if (Child != null) {
                Console.WriteLine($"Generator Already has Child");
                return;
            }
            if (ProducedPower < child.GetConsumptionedPowerWithChilds()) {
                Console.WriteLine($"Not enough Electricity to plug : {child.Id}");
                return;
            }
            Child = child;
            child.GeneratorParent = this;
        }

        public void UnPlugChildDevice() {
            if (Child == null) { return; }
            Child.GeneratorParent = null;
            Child = null;
        }
    }
}
