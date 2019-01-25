using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class ElectricWorker {
        internal void DoWork() {
            // CREATE
            Generator generator = new Generator();

            List<Device> devices = new List<Device>() {
                new Device(),
                new Device(),
                new Device(),
                new Device(),
                new Device(),
            };

            // PLUG 1
            //plug first to generator
            generator.PlugDevice(devices[0]);
            for (int i = 0; i < devices.Count; i++) {
                if (i >= devices.Count - 1) {
                    break;
                }
                devices[i].PlugDevice(devices[i + 1]);
            }
            // ASK
            int consumptionedPowerWithChilds0 = devices[0].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds1 = devices[1].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds2 = devices[2].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds3 = devices[3].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds4 = devices[4].GetConsumptionedPowerWithChilds();

            // UNPLUG
            generator.UnPlugChildDevice();
            foreach (var item in devices) {
                item.UnPlugChildDevice();
            }
        }
    }
}
