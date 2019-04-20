using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.EarthCalculator.Shared.Interfaces;

namespace LDY.UIP.EarthCalculator.DAL.Storages {
    public class ConsoleLogStorage : ILogStorage {
        public void PrintMessage(string message) {
            Console.WriteLine($"ConsoleLogStorage: {message}");
        }
    }
}
