using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class Device {
        public readonly int Id;

        private static int IdCounter = 0;

        public Generator GeneratorParent { get; set; }

        public Device Parent { get; set; }

        public Device Child { get; private set; }

        public int ConsumptionPower { get; private set; } = 270;

        public Device() {
            Id = ++IdCounter;
        }

        public void PlugDevice(Device child) {
            if (Child != null) {
                Console.WriteLine($"{Id} : Already has Child");
                return;
            }
            if (GetLeftPower() < GetConsumptionedPowerWithChilds()) {
                Console.WriteLine($"{Id} : Not enough Electricity to plug : {child.Id}");
                return;
            }
            Child = child;
            Child.Parent = this;
            Console.WriteLine($"{Child.Id} is Connected to {Id}");
        }

        public void UnPlugChildDevice() {
            Child = null;
        }

        public int GetLeftPower() {
            if (GeneratorParent == null && Parent == null) {
                return 0;
            }
            int parentEnergyLeft = GeneratorParent != null ? GeneratorParent.ProducedPower : Parent.GetLeftPower();
            int leftPower = parentEnergyLeft - ConsumptionPower;
            Console.WriteLine($"leftPower {Id} = {leftPower}");
            return leftPower;
        }

        public int GetConsumptionedPowerWithChilds() {
            return Child == null? ConsumptionPower : ConsumptionPower + Child.GetConsumptionedPowerWithChilds();
        }

    }
}
