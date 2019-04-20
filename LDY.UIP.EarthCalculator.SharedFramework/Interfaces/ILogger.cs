using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.UIP.EarthCalculator.Shared.Interfaces {
    public interface ILogger {
        void AddLogStorage(ILogStorage logStorage);
        void RemoveLogStorage(ILogStorage logStorage);
        List<ILogStorage> GetCurrentLogStorages();

        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Debug(string message);
        void Fatal(string message);
    }
}
