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

                if (true) {
                    // 1_0) Interface_General_Definition
                    List<IMovable> movables = new List<IMovable>() {
                        new AirPlan(),
                        new Swimmer(),
                        new SkyDiver(),
                        new Duck(),
                        new Car(),
                        new Train()
                    };

                    int[] speeds = movables.Select(m => m.MaxSpeed).ToArray();

                    int[] speeds2 = new int[movables.Count];
                    for (int i = 0; i < movables.Count; i++) {
                        speeds2[i] = movables[i].MaxSpeed;
                    }

                    int minSpeed = speeds.Min();
                    int maxSpeed = speeds.Max();

                    IMovable minSpeedInstance = movables.FirstOrDefault(m => m.MaxSpeed == minSpeed);
                    ShowType(minSpeedInstance);
                    IMovable customSpeedInstance = movables.FirstOrDefault(m => m.MaxSpeed == 12345);
                    ShowType(customSpeedInstance);
                    IMovable maxSpeedInstance = movables.FirstOrDefault(m => m.MaxSpeed == maxSpeed);
                    ShowType(maxSpeedInstance);

                    List<IFlyable> flyables = new List<IFlyable>() {
                        new AirPlan(),
                        new Swimmer(),
                        new SkyDiver(),
                        new Duck()
                    };

                    foreach (var flyable in flyables) {
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

        private static void ShowType(IMovable instance) {
            string resText = instance != null ? instance.GetType().Name : "instance => null";
            Console.WriteLine($"Found: {resText}");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName() {
            StackFrame sf = new StackTrace().GetFrame(1);
            return sf.GetMethod().Name;
        }
    }

    #region 0) Keyword Enum
    public enum Day {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
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

    #region 1) Interface_General_Definition 
    public class AirPlan : IFlyable, IMovable {
        public int MaxSpeed => 1000;

        public void Fly() {
            Console.WriteLine("AirPlan flies");
        }
    }
    public class Swimmer : IFlyable, ISwimable {
        public int MaxSpeed => 2;

        public void Fly() {
            Console.WriteLine("Swimmer flies");
        }

        public void Swim() {
            Console.WriteLine("Swimmer swims");
        }
    }
    public class SkyDiver : IFlyable, IMovable {
        public int MaxSpeed => 20;

        public void Fly() {
            Console.WriteLine("SkyDiver flies");
        }
    }
    public class Duck : IFlyable, IMovable, ISwimable {
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

    public interface IFlyable : IMovable {
        void Fly();
    }
    public interface IMovable {
        int MaxSpeed { get; }
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

}