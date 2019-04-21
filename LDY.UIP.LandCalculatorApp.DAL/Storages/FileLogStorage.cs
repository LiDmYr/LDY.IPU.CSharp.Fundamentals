using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;

namespace LDY.UIP.LandCalculatorApp.DAL.Storages {
    public class FileLogStorage : ILogStorage {
        public void PrintMessage(string message) {
            Console.WriteLine($"FileLogStorage: {message}");
        }
    }
}
