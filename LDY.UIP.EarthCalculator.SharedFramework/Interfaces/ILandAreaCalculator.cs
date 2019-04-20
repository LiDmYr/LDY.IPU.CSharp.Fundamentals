using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LDY.UIP.EarthCalculator.Shared.Interfaces {
    public interface ILandAreaCalculator {
        int CalculateLandArea(List<Point> points);
    }
}
