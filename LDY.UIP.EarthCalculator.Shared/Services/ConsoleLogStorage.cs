using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.EarthCalculator.Shared.Interfaces;

namespace LDY.UIP.EarthCalculator.Shared.Services {
    public class ConsoleLogStorage : ILogStorage {
        public void PrintMessage(string message) {
            Console.WriteLine($"ConsoleLogStorage: {message}");
        }
    }
}
