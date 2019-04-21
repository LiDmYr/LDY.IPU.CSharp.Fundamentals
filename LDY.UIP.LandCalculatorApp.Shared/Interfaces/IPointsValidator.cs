using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.LandCalculatorApp.Shared.Models;

namespace LDY.UIP.LandCalculatorApp.Shared.Interfaces {
    public interface IPointsValidator {
        PointsValidationResult GetValidationResult(List<Point> points);
    }
}
