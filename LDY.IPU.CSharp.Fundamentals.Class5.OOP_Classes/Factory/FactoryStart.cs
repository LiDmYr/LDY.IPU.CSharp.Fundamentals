using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Services;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    class FactoryStart {
        private static void Main(string[] args) {
            var w1 = new Worker("w1", 5);
            var w2 = new Worker("w2", 20);
            var workers = new Worker[] { w1, w2 };

            var items = new Item[] { new Item("Item1", 100) };
            var order = new Order(items, "firstOrder");
            var orders = new Order[] { order };
            Logger logger = new Logger(1, new FileHandler());
            Factory factory = new Factory(workers, orders, logger);
            for (int i = 0; i < 30; i++) {
                Console.WriteLine("WorkingDay" + i);
                factory.StartWorkingDay();
            }
        }
    }
}
