using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;
using LDY.UIP.LandCalculatorApp.Shared.Services;

namespace LDY.UIP.LandCalculatorApp.Shared {
    public static class StaticInjector {
        public static ILogger Logger { get; } = new Logger();
    }
}
