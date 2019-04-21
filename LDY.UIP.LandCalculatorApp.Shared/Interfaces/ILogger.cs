using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.UIP.LandCalculatorApp.Shared.Interfaces {
    public interface ILogger {
        List<ILogStorage> LogStorages { get; }

        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Debug(string message);
        void Fatal(string message);
    }
}
