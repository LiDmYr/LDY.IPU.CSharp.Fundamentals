// #define var1
#define var2

using LDY.IPU.CSharp.Fundamentals.Class10.Attributes;
using LDY.IPU.CSharp.Fundamentals.Class10.Interfaces;
using LDY.IPU.CSharp.Fundamentals.Class10.Models;
using LDY.IPU.CSharp.Fundamentals.Class10.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LDY.IPU.CSharp.Fundamentals.Class10.Shared;

namespace LDY.IPU.CSharp.Fundamentals.Class10 {
    public class Program {
        public static void Main(string[] args) {

            List<int> ints = new List<int> { 1, 2, 3, 5, 6, 9 };

            IEnumerable<int> selected = ints.Where(i => i > 3);

            ints.Add(100);

            foreach (var item in selected) {
                Console.WriteLine(item);
            }


            // 1 Attributes
            if (false) {
                var logRecord = new LogRecord();

                ReflectIt(logRecord);
                ReflectIt(new System.Drawing.Point());
            }

            // 2 Serialization
            if (false) {
                var logRecord = new LogRecord("a");
                var logRecord2 = new LogRecord("b");
                var logRecord3 = new LogRecord("c");
                var logRecord4 = new LogRecord("d");

                logRecord.NestedLogRecord = logRecord2;
                logRecord.NestedLogRecords = new List<LogRecord>() {
                    logRecord3,
                    logRecord4
                };

                //////////////////////////////
                string res1 = JsonConvert.SerializeObject(logRecord);
                string res2 = JsonConvert.SerializeObject(logRecord2);

                LogRecord lr = JsonConvert.DeserializeObject<LogRecord>(res1);
                LogRecord lr2 = JsonConvert.DeserializeObject<LogRecord>(res2);
                //////////////////////////////


                //////////////////////////////
                string listRecords =
                    JsonConvert.SerializeObject(logRecord.NestedLogRecords);
                List<LogRecord> listRecordDeserialized = 
                    JsonConvert.DeserializeObject<List<LogRecord>>(listRecords);
                //////////////////////////////

                //////////////////////////////
                IJSONSerializer js = new JSONSerializer();
                string _serializedRecords = js.Serialize(logRecord.NestedLogRecords);
                List<LogRecord> _records = js.Deserialize<List<LogRecord>>(_serializedRecords);
                //////////////////////////////


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
            if (true) {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("--------------------------------------");

                    string path = @"C:\Users\workspace\source\repos\LDY.IPU.CSharp.Fundamentals\Libraries";
                    string[] allFileEntries = Directory.GetFiles(path);
                    string[] fileEntries = Directory.GetFiles(path, "*.dll");
                    
                    List<IFindable> interfaces = new List<IFindable>();

                    foreach (var file in fileEntries) {
                        Assembly assembly = Assembly.LoadFrom(file);
                        Type[] types = assembly.GetExportedTypes();

                        foreach (Type type in types) {
                            TypeInfo typeInfo = (TypeInfo)type;

                            IEnumerable<Type> implementedInterfaces = typeInfo.ImplementedInterfaces;

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
                                    instance = (IFindable)Activator.CreateInstance(type, 10);
                                    interfaces.Add(instance);
                                } catch (Exception e) {
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

        private static void ReflectIt(object obj) {
            // РeфлEксия
            //Type type = typeof(LogRecord);
            Type typeByGetType = obj.GetType();

            Console.WriteLine(typeByGetType.BaseType.ToString());

            // Attributes for class
            object[] customAttributesWithoutInheritChain = typeByGetType.GetCustomAttributes(false);
            PrintAllAttributes("class", customAttributesWithoutInheritChain.Cast<Attribute>());

            // Attributes for method
            MethodInfo methodInfo = typeByGetType.GetMethod("DoSomething");
            IEnumerable<Attribute> customMethodAttributes = methodInfo.GetCustomAttributes();
            PrintAllAttributes("method", customMethodAttributes);

            //var result = methodInfo.Invoke(obj, null);
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