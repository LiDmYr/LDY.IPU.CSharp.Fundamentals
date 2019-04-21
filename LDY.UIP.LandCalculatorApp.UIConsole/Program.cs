using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.LandCalculatorApp.BLL.Services;
using LDY.UIP.LandCalculatorApp.DAL.Storages;
using LDY.UIP.LandCalculatorApp.Shared;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;
using LDY.UIP.LandCalculatorApp.Shared.Services;

namespace LDY.UIP.LandCalculatorApp.UIConsole {
    class Program {
        static void Main(string[] args) {
            InitializeStorages();

            StaticInjector.Logger.Info("Program is started");

            new UIConsoleInteractor(new LandAreaCalculator()).Start();
        }

        private static void InitializeStorages() {
            StaticInjector.Logger.LogStorages.Add(new ConsoleLogStorage());
            StaticInjector.Logger.LogStorages.Add(new FileLogStorage());
        }

    }
}
