using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.EarthCalculator.Shared.Interfaces;

namespace LDY.UIP.EarthCalculator.Shared.Services {
    public class FileLogStorage : ILogStorage {
        public void PrintMessage(string message) {
            Console.WriteLine($"FileLogStorage: {message}");
        }
    }
}
