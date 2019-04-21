using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.UIP.LandCalculatorApp.Shared.Interfaces {
    public interface ILandAreaCalculator {
        int CalculateLandArea(List<Point> points);
    }
}
