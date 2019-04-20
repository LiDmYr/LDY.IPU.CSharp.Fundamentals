using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.UIP.EarthCalculator.Shared.Interfaces;

namespace LDY.UIP.EarthCalculator.Shared.Services {
    public class Logger : ILogger {
        public List<ILogStorage> LogStorages = new List<ILogStorage>();

        private int _logLevel = (int)Level.info;

        public int LogLevel {
            get {
                return (int)_logLevel;
            }
            set {
                if (value > 5 && value < 1) {
                    return;
                }
                this._logLevel = value;
            }
        }


        private void PrintMessage(string messageType, string message, int currentLogLevel) {
            if (this.LogLevel > currentLogLevel) {
                return;
            }

            foreach (ILogStorage logStorage in LogStorages) {
                logStorage.PrintMessage($"{DateTime.Now}: {messageType}: {message}");
            }
        }

        public void Debug(string message) {
            PrintMessage("DEBUG", message, (int)Level.debug);
        }

        public void Error(string message) {
            PrintMessage("Error", message, (int)Level.error);
        }

        public void Fatal(string message) {
            PrintMessage("Fatal", message, (int)Level.fatal);
        }

        public void Info(string message) {
            PrintMessage("Info", message, (int)Level.info);
        }

        public void Warn(string message) {
            PrintMessage("Warn", message, (int)Level.warning);
        }
    }

    public enum Level {
        info = 1,
        debug = 2,
        warning = 3,
        error = 4,
        fatal = 5
    }
}
