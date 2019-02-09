using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class7.OOP_Interface {
    public class Program {
        public static void Main(string[] args) {
            // 0) Keyword Enum
            if (false) {
                Day currentDay = Day.Sunday; 
            }

            // 1) Interfaces 
            if (true) {
                var humans = new List<Human>() {
                    new Worker(Qualification.Beginner, "Serg"),
                    new Accounter("Motrya")
                };

                if (true) {
                    // 1_1) IComparable
                    humans.Add(new Accounter("Egor"));
                    humans.Add(new Worker(Qualification.Middle, "Ivan"));
                    humans.Add(new Accounter("Sasha"));
                    humans.Add(new Worker(Qualification.Middle, "Avatar"));
                    humans.Sort();
                }

                if (true) {
                    // IOrderProviders
                    List<IOrdersProvider> ordersProvider = new List<IOrdersProvider> {
                        (IOrdersProvider)new PrivateEntrepreneur(),
                        (IOrdersProvider)new Country()
                    };

                    foreach (var orderProvider in ordersProvider) {
                        orderProvider.IsAvailableOrders();
                        orderProvider.GetOrders();
                    }
                }
            }

            // 4) Struct - HOMEWORK

            // *) Logger Example (using Interface, Pattern Strategy, like a DependencyInjection )
            // show this example with Test task
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

        private static void DoSomething(Func<object, bool> p) {

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName() {
            var st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
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
        Beginner,
        Middle,
        Master          
    }
    #endregion

    #region 1) Interface_IComparable
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

    #region 1) Interface_anotherPurposes
    public class Unit { }

    public class Order {
        public List<Unit> Units { get; set; }
    }
       
    public class PrivateEntrepreneur : IOrdersProvider {
        public string Name { get; set; } = "PrivateEntrepreneur";

        public IEnumerable<Order> GetOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetCurrentMethodName()}");
            return new List<Order>();
        }

        public bool IsAvailableOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetCurrentMethodName()}");
            return true;
        }
    }

    public class Country : IOrdersProvider {
        public IEnumerable<Order> GetOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetCurrentMethodName()}");
            return new Order[0];
        }

        public bool IsAvailableOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetCurrentMethodName()}");
            return false;
        }
    }

    public interface IOrdersProvider {
        bool IsAvailableOrders();
        IEnumerable<Order> GetOrders() ;
    }

    #endregion

    #region *) Logger
    public class Logger : ILogger {
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
            Console.WriteLine(this.GetType().Name + "_" + message);
        }
    }

    public class DBWriter : IWriter {
        public void Write(string message) {
            Console.WriteLine(this.GetType().Name + "_" + message);
        }
    }
    #endregion

}






