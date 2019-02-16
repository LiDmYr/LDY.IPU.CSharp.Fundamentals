using LDY.IPU.CSharp.Fundamentals.Class10.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Models {
    [Serializable]
    [Custom("LDY1", DeclaredAt = "12.10.2020")]
    [Custom("LDY2", DeclaredAt = "12.10.2020")]
    public class LogRecord {
        [JsonIgnore]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Message { get; set; }

        public LogLevel LogLevel { get; set; }

        [Custom("LDY3", DeclaredAt = "10.01.2019")]
        public void DoSomething() {
            Console.WriteLine("===> LogRecord.DoSomething()");
        }
    }

    public enum LogLevel {
        Debug = 10,
        Info = 20,
        Warn = 30,
        Error = 40,
    }
}
