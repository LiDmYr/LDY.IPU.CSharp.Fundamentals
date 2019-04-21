using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.LandCalculatorApp.BLL.Services;
using LDY.UIP.LandCalculatorApp.Shared.Interfaces;

namespace LDY.UIP.LandCalculatorApp.UIConsole {
    public class UIConsoleInteractor {
        private ILandAreaCalculator LandAreaCalculator;

        public UIConsoleInteractor(ILandAreaCalculator landAreaCalculator) {
            LandAreaCalculator = landAreaCalculator;
        }

        internal void Start() {
            List<Point> points = GetPoints();

            int landArea = LandAreaCalculator.CalculateLandArea(points);

            Console.WriteLine($"Result = {landArea}");
        }

        private List<Point> GetPoints() {
            return null;
        }
    }
}
