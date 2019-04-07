using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public abstract class ElectricDevice {
        private static int IdCounter;

        public readonly int Id;

        public abstract int AvailablePower { get; }

        public bool IsConnectedChildDevice {
            get {
                return ChildDevice != null;
            }
        }

        public ConsumerDevice ChildDevice { get; protected set; }

        static ElectricDevice() {
            var r = new Random();
            IdCounter = r.Next(0, 100);
        }

        public ElectricDevice() {
            Id = ++IdCounter;
        }

        public void PlugChildDevice(ConsumerDevice device) {
            if (IsConnectedChildDevice || AvailablePower < device.ConsumptionPower) {
                return;
            }

            ChildDevice = device;
            ChildDevice.ParentDevice = this;
        }

        public void UnPlugChildDevice() {
            if (!IsConnectedChildDevice) { return; }

            ChildDevice.UnPlugChildDevice();

            ChildDevice.ParentDevice = null;
            this.ChildDevice = null;
        }

        public void ShowConnectedDevices(int numberInQueue = 1) {
            Console.WriteLine($"{this} is {numberInQueue} in network");

            if (!IsConnectedChildDevice) { return; }

            ChildDevice.ShowConnectedDevices(++numberInQueue);
        }

        public override string ToString() {
            return this.Id.ToString();
        }
    }
}

