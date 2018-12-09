using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Model;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Services {
    public class FileHandler {
        public void SaveToFile(Log log) {
            Console.WriteLine(log.Message + log.Level + log.Now);
            // DBContext...
        }
    }
}
