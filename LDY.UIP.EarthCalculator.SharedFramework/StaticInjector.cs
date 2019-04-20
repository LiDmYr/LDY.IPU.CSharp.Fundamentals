using System;
using System.Collections.Generic;
using System.Text;
using LDY.UIP.EarthCalculator.Shared.Interfaces;
using LDY.UIP.EarthCalculator.Shared.Services;

namespace LDY.UIP.EarthCalculator.Shared {
    public static class StaticInjector {
        public static ILogger Logger { get; } = new Logger();
    }
}
