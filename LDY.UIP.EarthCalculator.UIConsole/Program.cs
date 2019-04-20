using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.EarthCalculator.BLL.Services;
using LDY.UIP.EarthCalculator.DAL.Storages;
using LDY.UIP.EarthCalculator.Shared;
using LDY.UIP.EarthCalculator.Shared.Services;

namespace LDY.UIP.EarthCalculator.UIConsole {
    class Program {
        static void Main(string[] args) {
            LandAreaCalculator lac = new LandAreaCalculator();
            Console.WriteLine(lac.CalculateLandArea(null));
   

            StaticInjector.Logger.AddLogStorage(new FileLogStorage());
            StaticInjector.Logger.AddLogStorage(new ConsoleLogStorage());

            StaticInjector.Logger.Info("test");
        }
    }
}
