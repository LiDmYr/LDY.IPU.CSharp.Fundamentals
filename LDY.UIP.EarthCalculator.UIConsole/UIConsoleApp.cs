using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.EarthCalculator.BLL.Services;
using LDY.UIP.EarthCalculator.Shared.Interfaces;

namespace LDY.UIP.EarthCalculator.UIConsole {
    public class UIConsoleApp {
        private ILandAreaCalculator landAreaCalculator;

        public UIConsoleApp(ILandAreaCalculator landAreaCalculator) {
            this.landAreaCalculator = landAreaCalculator;
        }

        public void Start() {
            List<Point> points = GetPoints();
            int res = landAreaCalculator.CalculateLandArea(points);
            Console.WriteLine(res);
        }

        private List<Point> GetPoints() {
            return null;
        }
    }
}
