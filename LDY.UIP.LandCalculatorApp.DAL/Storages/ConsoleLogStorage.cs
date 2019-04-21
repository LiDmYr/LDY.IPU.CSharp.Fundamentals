using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;

namespace LDY.UIP.LandCalculatorApp.DAL.Storages {
    public class ConsoleLogStorage : ILogStorage {
        public void PrintMessage(string message) {
            Console.WriteLine($"ConsoleLogStorage: {message}");
        }
    }
}
