using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class ConsumerDevice : ElectricDevice {
        public override int AvailablePower {
            get {
                return HasParentDevice ? ParentDevice.AvailablePower - this.ConsumptionPower : 0;
            }
        }

        public bool HasParentDevice {
            get {
                return ParentDevice != null;
            }
        }

        public ElectricDevice ParentDevice { get; set; }

        public int ConsumptionPower { get; }

        public ConsumerDevice(int consumptionPower) {
            ConsumptionPower = consumptionPower;
        }

        internal int GetConsumptionedPowerWithChilds() {
            return IsConnectedChildDevice ?
                ConsumptionPower + ChildDevice.GetConsumptionedPowerWithChilds() :
                ConsumptionPower;
        }

        public override string ToString() {
            return $"device Id#{base.ToString()}";
        }
    }
}
