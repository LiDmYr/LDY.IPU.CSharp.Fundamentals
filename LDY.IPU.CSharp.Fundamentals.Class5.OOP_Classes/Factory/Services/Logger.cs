using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Model;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Services {
    public class Logger {
        public int Level { get; private set; } // set 1 2 3
        private FileHandler FileHandler;

        public Logger(int level, FileHandler fileHandler) {
            this.Level = level;
            this.FileHandler = fileHandler;
        }

        // 1
        public void LogInfo(string message) {
            if (this.Level <= 1) {
                var log = new Log(message, this.Level, DateTime.Now);
                this.FileHandler.SaveToFile(log);
            }
        }
         //2
        public void LogWarning(string message) {
            if (this.Level <= 2) {
                var log = new Log(message, this.Level, DateTime.Now);
                this.FileHandler.SaveToFile(log);
            }
        }
         //3
        public void LogError(string message) {
            if (this.Level <= 3) {
                var log = new Log(message, this.Level, DateTime.Now);
                this.FileHandler.SaveToFile(log);
            }
        }

    }
}
