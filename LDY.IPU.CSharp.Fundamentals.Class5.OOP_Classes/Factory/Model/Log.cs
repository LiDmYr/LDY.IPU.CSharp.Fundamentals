using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Model {
    public class Log {
        public string Message; // set private
        public int Level;
        public DateTime Now;

        public Log(string message, int level, DateTime now) {
            this.Message = message;
            this.Level = level;
            this.Now = now;
        }
    }
}
