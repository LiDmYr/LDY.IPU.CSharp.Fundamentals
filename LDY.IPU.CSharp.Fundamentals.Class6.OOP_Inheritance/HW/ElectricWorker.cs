using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class ElectricWorker {
        internal void DoWork() {
            // Initialize devices
            Generator generator = new Generator(1000);
            List<ConsumerDevice> devices = new List<ConsumerDevice>() {
                new ConsumerDevice(300),
                new ConsumerDevice(300),
                new ConsumerDevice(300),
                new ConsumerDevice(200),
                new ConsumerDevice(200),
            };

            // PLUG devices
            generator.PlugChildDevice(devices[0]);
            for (int i = 0; i < devices.Count; i++) {
                if (i >= devices.Count - 1) {
                    break;
                }
                devices[i].PlugChildDevice(devices[i + 1]);
            }

            //SHOW devices
            generator.ShowConnectedDevices();

            // ASK
            int consumptionedPowerWithChilds0 = devices[0].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds1 = devices[1].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds2 = devices[2].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds3 = devices[3].GetConsumptionedPowerWithChilds();
            int consumptionedPowerWithChilds4 = devices[4].GetConsumptionedPowerWithChilds();

            devices[0].UnPlugChildDevice();

            //SHOW devices after unplug
            Console.WriteLine("Devices After Unplug");
            generator.ShowConnectedDevices();

            // UNPLUG all devices
            generator.UnPlugChildDevice();
            foreach (var item in devices) {
                item.UnPlugChildDevice();
            }
        }
    }
}
