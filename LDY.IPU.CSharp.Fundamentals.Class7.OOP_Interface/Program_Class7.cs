using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class7.OOP_Interface {
    public class Program_Class7 {
        public static void Main(string[] args) {
            // 0) Keyword Enum
            if (true) {
                Day currentDay = Day.Sunday; 
            }

            // 1) UpCasting vs DownCasting
            if (true) {
                Worker worker = new Worker(Qualification.Beginner, "Serg");
                Accounter accounter = new Accounter("Motrya");
                Human humanWorker = (Human)worker;
                // Human humanWorker = worker;
                Human humanAccounter = (Human)accounter;
                // Human humanAccounter = accounter;

                var humans = new List<Human>() {
                    humanWorker,
                    humanAccounter
                };

                Worker workerRecognized = (Worker) humans[0];
                // Worker workerRecognized = (Worker)humans[1];
                Accounter accounterRecognized = (Accounter)humans[1];

                // 2) Operator is , as 
                if (false) {
                    if (humans[0] is Worker) {
                        Worker workerRecognizedSafelyIs = (Worker) humans[0];
                    }

                    Worker workerRecognizedSafelyAs = humans[0] as Worker; // human is Engineer ? (Engineer)human : (Engineer)null
                    if (workerRecognizedSafelyAs != null) {
                        Qualification qualification = workerRecognizedSafelyAs.Qualification;
                    }
                }

                // 3) Interface
                if (false) {
                    // ILogger (write logs at the same time to several sources) + IOrderProvider (PrivatePerson, Country, CommercialCompany) - Factory
                    humans.Add(new Worker(Qualification.Middle, "Ivan"));
                    humans.Add(new Accounter("Sasha"));

                    humans.Sort();
                    // IDataProvider
                }
            }

            // 4) Struct - HOMEWORK

            // 5) Logger Example (using Interface, Pattern Strategy, like a DependencyInjection )
            if (true) {
                List<IWriter> writers = new List<IWriter>() {
                    new ConsoleWriter(),
                    new DBWriter(),
                    new ConsoleWriter()
                };

                Logger logger = new Logger(writers);

                logger.Info("Too many request");

                logger.Info("Free space is not avavilble");
            }
        }
    }

    #region 0) Keyword Enum
    public enum Day {
        Monday = 1,
        Tuesday = 2,
        Wednesday= 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    public enum Qualification {
        Beginner = 10,
        Middle = 20,
        Master = 30          
    }
    #endregion

    #region 1) UpCasting vs DownCasting
    //public abstract class Human {
    //    public string Name { get; private set; }

    //    public Human(string name) {
    //        this.Name = name;
    //    }
    //}

    //public class Worker : Human {
    //    public Qualification Qualification { get; set; }

    //    public Worker(Qualification qualification, string name) : base(name) {
    //        this.Qualification = qualification;
    //    }
    //}

    //public class Accounter : Human {
    //    public Accounter(string name) : base(name) { }
    //}
    #endregion

    #region 3) Interface
    public abstract class Alive {

    }

    public abstract class Human : Alive, IComparable {
        public string Name { get; private set; }

        public Human(string name) {
            this.Name = name;
        }

        public int CompareTo(object obj) {
            var human = obj as Human;
            if (human == null) { return 1; }
            return this.Name.CompareTo(human.Name);
        }

        public override string ToString() {
            return this.Name;
        }

        public int GetOrders() {
            return 0;
        }
    }

    public class Worker : Human {
        public Qualification Qualification { get; set; }

        public Worker(Qualification qualification, string name) : base(name) {
            this.Qualification = qualification;
        }
    }

    public class Accounter : Human {
        public Accounter(string name) : base(name) { }
    }
    #endregion

    #region 5) Logger
    class Logger : ILogger {
        public List<IWriter> Writers { get; set; }

        public Logger(List<IWriter> writers) {
            this.Writers = writers;
        }
        public void Info(string message) {
            foreach (IWriter writer in this.Writers) {
                writer.Write(message + DateTime.Now);
            }
        }
    }
    public interface ILogger {
        void Info(string message);
    }
    public interface IWriter {
        void Write(string message);
    }

    public class ConsoleWriter : IWriter {
        public void Write(string message) {
            Console.WriteLine(this.GetType() + "_" + message);
        }
    }

    public class DBWriter : IWriter {
        public void Write(string message) {
            Console.WriteLine(this.GetType() + "_" + message);
        }
    }
    #endregion
}






