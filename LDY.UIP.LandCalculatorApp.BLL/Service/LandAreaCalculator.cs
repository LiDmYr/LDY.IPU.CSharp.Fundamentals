using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.LandCalculatorApp.Shared;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;

namespace LDY.UIP.LandCalculatorApp.BLL.Services {
    public class LandAreaCalculator : ILandAreaCalculator {
        public int CalculateLandArea(List<Point> points) {
            StaticInjector.Logger.Info("result = 0");
            return 0;
        }
    }
}
