using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.UIP.LandCalculatorApp.Shared.Models {
    public class PointsValidationResult {
        public bool ArePointsValid { get;  }

        public string Message { get; }

        public List<PointsMistakes> Mistakes { get; }
    }

    public enum PointsMistakes {
        NotEnoughUniquePoints = 2,
        CrossedShape = 4,
        NotClosedShape = 8,
    }
}
