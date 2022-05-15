using LDY.IPU.CSharp.Fundamentals.Class10.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Models {
    // [Serializable]
    [Custom("LDY1", DeclaredBy = "dsds")]
    [Custom("LDY2", DeclaredAt = "12.10.2020")]
    public class LogRecord {
        public LogRecord() {
        }

        public LogRecord(string password) {
            Password = password;
        }

        //[JsonIgnore]
        public LogRecord NestedLogRecord { get; set; }

        //[JsonIgnore]
        public List<LogRecord> NestedLogRecords { get; set; }

        //[JsonIgnore]
        public string Password { get; set; }

        //[JsonIgnore]
        public DateTime CreatedAt { get; }

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
