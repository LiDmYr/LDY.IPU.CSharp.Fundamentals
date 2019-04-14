using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class8.OOP {
    class Program {
        static void Main(string[] args) {
            // struct vs class
            if (true) {
                int[] pointsNumber = new int[] {
                    100,      // 100
                    10000,    // 10 000
                    1000000,  // 1 000 000
                    100000000 // 100 000 000
                };

                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < 4; i++) {
                    sw.Start();
                    CreateAndKillObjects(pointsNumber[i]);
                    sw.Stop();

                    PrintElapsedTime(i, sw);
                }

                // STRUCT                                            // CLASS
                // GC.GetTotalMemory(false) = 29'988             VS  29'988
                // iteration #0 execution time is00:00:00.00     VS  00:00:00.00  
                // GC.GetTotalMemory(false) = 78'204             VS  202'020
                // iteration #1 execution time is00:00:00.00     VS  00:00:00.00
                // GC.GetTotalMemory(false) = 4'078'236          VS  16'037'680
                // iteration #2 execution time is00:00:00.02     VS  00:00:00.05
                // GC.GetTotalMemory(false) = 400'030'420        VS  1'600'038'068
                // iteration #3 execution time is00:00:01.97     VS  00:00:12.32

                GC.Collect();
            }
        }

        private static void PrintElapsedTime(int iteration, Stopwatch sw) {
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"iteration #{iteration} execution time is: " + elapsedTime);
        }

        private static void CreateAndKillObjects(int pointsCount) {
            MyPoint[] points = new MyPoint[pointsCount];
            for (int i = 0; i < pointsCount; i++) {
                points[i] = new MyPoint(10);
                if (i == pointsCount - 1) {
                    var a = GC.GetTotalMemory(false);
                }
            }
            Console.WriteLine($"GC.GetTotalMemory(false) = {GC.GetTotalMemory(false).ToString()}");
        }
    }

    public class MyPoint {
        //public class MyPoint {
        //public struct MyPoint {
        public int X { get; set; }

        public MyPoint(int x) {
            X = x;
        }
    }
}
