using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.EarthCalculator.BLL.Services;
using LDY.UIP.EarthCalculator.DAL.Storages;
using LDY.UIP.EarthCalculator.Shared;
using LDY.UIP.EarthCalculator.Shared.Interfaces;
using LDY.UIP.EarthCalculator.Shared.Services;

namespace LDY.UIP.EarthCalculator.UIConsole {
    public class Program {
        public static void Main(string[] args) {
            StaticInjector.Logger.AddLogStorage(new FileLogStorage());
            StaticInjector.Logger.AddLogStorage(new ConsoleLogStorage());
            StaticInjector.Logger.Info("Program is started");

            ILandAreaCalculator lac = new LandAreaCalculator();
            new UIConsoleApp(lac).Start();

            // Full description
            //UIConsoleApp uc = new UIConsoleApp(lac);
            //uc.Start();
        }
    }
}
