//#define var1
#define var2

using LDY.IPU.CSharp.Fundamentals.Class10.Attributes;
using LDY.IPU.CSharp.Fundamentals.Class10.Interfaces;
using LDY.IPU.CSharp.Fundamentals.Class10.Models;
using LDY.IPU.CSharp.Fundamentals.Class10.Services;
using LDY.IPU.CSharp.Fundamentals.Class10.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class10 {
    public class Program {
        public static void Main(string[] args) {
            // 1 Attributes
            if (false) {
                var logRecord = new LogRecord();

                // РeфлEксия
                Type type = typeof(LogRecord);
                Type typeByGetType = logRecord.GetType();

                // Attributes for class
                object[] customAttributesWithoutInheritChain = type.GetCustomAttributes(false);
                PrintAllAttributes("class", customAttributesWithoutInheritChain.Cast<Attribute>());

                // Attributes for method
                MethodInfo methodInfo = type.GetMethod("DoSomething");
                IEnumerable<Attribute> customMethodAttributes = methodInfo.GetCustomAttributes();
                PrintAllAttributes("method", customMethodAttributes);
            }

            // 2 Serialization
            if (false) {
                var serializer = new JSONSerializer();

                // One LogRecord
                var logRecordToSerialize = new LogRecord() { Message = "M1", Password = "***1" };
                logRecordToSerialize.NestedLogRecord = new LogRecord() { Message = "M2", Password = "***2" };
                // USE FOR EXAMPLE LATER logRecordToSerialize.NestedLogRecords = logRecords;
                string serializedLogRecord = serializer.Serialize(logRecordToSerialize);
                ///// BELOW CODE IS SOMEWHERE AWAY FROM PREVIOUS CODE
                var deserializedLogRecord = serializer.Deserialize<LogRecord>(serializedLogRecord);
                bool isEqual = logRecordToSerialize.Equals(deserializedLogRecord);

                //List LogRecord
                var logRecords = new List<LogRecord>() {
                    new LogRecord() { Message = "M1", Password = "***1"},
                    new LogRecord() { Message = "M2", Password = "***2"},
                    new LogRecord() { Message = "M3", Password = "***3"},
                    new LogRecord() { Message = "M4", Password = "***4"},
                };
                string serializedListLogRecord = serializer.Serialize(logRecords);
                var deserializedListLogRecord = serializer.Deserialize<List<LogRecord>>(serializedListLogRecord);
            }

            //3 Assemblies
            if (false) {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("--------------------------------------");

                    string path = @"C:\Users\workspace\source\repos\LDY.IPU.CSharp.Fundamentals\Libraries";
                    string[] fileEntries = Directory.GetFiles(path, "*.dll");

                    List<IFindable> interfaces = new List<IFindable>();

                    foreach (var file in fileEntries) {
                        Assembly assembly = Assembly.LoadFrom(file);
                        Type[] types = assembly.GetExportedTypes();

                        foreach (TypeInfo type in types) {
                            IEnumerable<Type> implementedInterfaces = type.ImplementedInterfaces;

                            bool isImplementedRequiredInterface = false;
                            foreach (Type implementedInterface in implementedInterfaces) {
                                if (implementedInterface.FullName == typeof(IFindable).FullName) {
                                    isImplementedRequiredInterface = true;
                                    break;
                                }
                            }

                            if (isImplementedRequiredInterface) {
                                IFindable instance;
                                try {
                                    instance = (IFindable)Activator.CreateInstance(type);
                                    interfaces.Add(instance);
                                } catch (Exception) {
                                    //
                                }
                            }
                        }
                    }

                    foreach (var interfaceInstance in interfaces) {
                        interfaceInstance.SaySomething();
                    }

                    Thread.Sleep(5000);
                }
            }

            // 4 Directives
            if (false) {
                WriteSomethingRule1();
                WriteSomethingRule2();
                DebugMethod();
                ReleaseMethod();
            }
            Console.ReadLine();
        }

        #region ASSEMBLIES
        private static void PrintAllAttributes(string target, IEnumerable<Attribute> customAttributesWithoutInheritChain) {
            Console.WriteLine($"---------------- TARGET={target}");

            foreach (Attribute attribute in customAttributesWithoutInheritChain) {
                Console.WriteLine($"TypeId={attribute.TypeId}");

                if (attribute is CustomAttribute) {
                    var customAttribute = (CustomAttribute)attribute;

                    customAttribute.ExecuteAttributeMagic();

                    Console.WriteLine($"At={customAttribute.DeclaredAt}; By={customAttribute.DeclaredBy}");
                }
            }
            Console.WriteLine($"\n");
        } 

        #endregion

        #region DIRECTIVES

#if var1
        public static void WriteSomethingRule1() {
            Console.WriteLine("var1");
        }
#elif var2
        public static void WriteSomethingRule1(){
            Console.WriteLine ("var2");
        }
#endif

#if DEBUG
        public static void WriteSomethingRule2() {
            Console.WriteLine("WriteSomethingRule2: DEBUG"); 
        }
#elif RELEASE
        public static void WriteSomethingRule2() {
            Console.WriteLine("WriteSomethingRule2: RELEASE");
        }
#endif

        [Conditional("DEBUG")]
        static void DebugMethod() {
            Console.WriteLine("DebugMethod: DEBUG");
        }

        [Conditional("RELEASE")]
        static void ReleaseMethod() {
            Console.WriteLine("ReleaseMethod: RELEASE");
        } 
        #endregion
    }
}