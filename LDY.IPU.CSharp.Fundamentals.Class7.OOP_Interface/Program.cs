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
                Days currentDay = Days.Sunday;
                Console.WriteLine(currentDay.ToString());
                Console.WriteLine((int)currentDay);
            }

            // 1) Interfaces 
            if (true) {
                if (true) {
                    // Task with different models
                    // 1_0) Interface_General_Definition

                    IMovable movable = (IMovable)(IFlyable)new AirPlan();
                    // IMovable movable = (IMovable)new Car();
                    if (movable is AirPlan airPlan) {
                        Console.WriteLine(airPlan.Model);
                    }

                    Console.WriteLine(movable.GetType().Name);

                    List<IMovable> movables = new List<IMovable>() {
                        (IMovable) new AirPlan(),
                        (IMovable) new Swimmer(),
                        new SkyDiver(),
                        new Duck(),
                        new Car(),
                        new Train()
                    };

                    int[] speeds = new int[movables.Count];
                    for (int i = 0; i < movables.Count; i++) {
                        speeds[i] = movables[i].MaxSpeed;
                    }

                    int minSpeed = speeds.Min();
                    int maxSpeed = speeds.Max();

                    List<IFlyable> flyables = new List<IFlyable>() {
                        new AirPlan(),
                        new SkyDiver(),
                        new Duck()
                    };

                    foreach (IFlyable flyable in flyables) {
                        flyable.Fly();
                    }

                    List<ISwimable> swimables = new List<ISwimable>() {
                        new Swimmer(),
                        new Duck(),
                    };

                    foreach (var swimable in swimables) {
                        swimable.Swim();
                    }
                }

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
                        (IOrdersProvider)new Entrepreneur(),
                        (IOrdersProvider)new Country()
                    };

                    foreach (var orderProvider in ordersProvider) {
                        orderProvider.IsAvailableOrders();
                        orderProvider.GetOrders();
                    }
                }
            }

            // 2) Struct - HOMEWORK

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

        private static void ShowType(IMovable instance) {
            string resText = instance != null ? instance.GetType().Name : "instance => null";
            Console.WriteLine($"Found: {resText}");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodName() {
            var st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            string res = sf.GetMethod().Name;
            return res;
        }
    }

    #region 0) Keyword Enum
    public enum Days {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    enum MyValue : byte {
        First = 2,
        Second = 4,
        Third = 8,
        Fourrh = 16
    }


    public enum Qualification {
        Beginner,
        Middle,
        Master
    }
    #endregion

    #region 1) Interface_General_Definition 
    // public class MyClass implements IMovable
    // public class MyClass extends BaseClass
    public class AirPlan : IFlyable {
        public string Model { get; set; }

        // public int MaxSpeed => 1000;
        public int MaxSpeed {
            get {
                return 1000;
            }
        }

        public void Fly() {
            Console.WriteLine("AirPlan flies");
        }
    }
    public class Swimmer : ISwimable {
        public int MaxSpeed => 2;

        public void Swim() {
            Console.WriteLine("Swimmer swims");
        }
    }
    public class SkyDiver : IFlyable { // IMovable
        public int MaxSpeed => 20;

        public void Fly() {
            Console.WriteLine("SkyDiver flies");
        }
    }
    public class Duck : IFlyable, ISwimable {
        public int MaxSpeed => 40;

        public void Fly() {
            Console.WriteLine("Duck flies");
        }

        public void Swim() {
            Console.WriteLine("Duck swims");
        }
    }
    public class Car : IMovable {
        public int MaxSpeed => 400;
    }
    public class Train : IMovable {
        public int MaxSpeed => 200;
    }

    public interface IMovable {
        int MaxSpeed { get; }
    }

    public interface IFlyable : IMovable {
        void Fly();
    }

    public interface ISwimable : IMovable {
        void Swim();
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

    public class Entrepreneur : IOrdersProvider {
        public string Name { get; set; } = "Pupkin";

        public IEnumerable<Order> GetOrders() { // Order[] ... List<Order>
            Console.WriteLine($"{GetType().Name}: {Program.GetMethodName()}");
            return new List<Order>();
        }

        public bool IsAvailableOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetMethodName()}");
            return true;
        }
    }

    public class Country : IOrdersProvider {
        public IEnumerable<Order> GetOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetMethodName()}");
            return new Order[0];
        }

        public bool IsAvailableOrders() {
            Console.WriteLine($"{GetType().Name}: {Program.GetMethodName()}");
            return false;
        }
    }

    public interface IOrdersProvider {
        bool IsAvailableOrders();
        IEnumerable<Order> GetOrders();
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

    #region 2) Struct
    public struct CustomPoint {
        public int X { get; set; }
        // public int X { get; set; } = 10; // not allowed

        public int Y { get; set; }

        // not allowed
        //public CustomPoint() {
        //}

        public CustomPoint(int x, int y) {
            X = x;
            Y = y;
        }
    }
    #endregion
}