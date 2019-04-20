using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.EarthCalculator.Shared.Services;

namespace LDY.UIP.EarthCalculator.UIConsole {
    class Program {
        static void Main(string[] args) {
            Logger log = new Logger();
            log.LogStorages.Add(new FileLogStorage());
            log.LogStorages.Add(new ConsoleLogStorage());

            log.Info("test");
        }
    }
}
