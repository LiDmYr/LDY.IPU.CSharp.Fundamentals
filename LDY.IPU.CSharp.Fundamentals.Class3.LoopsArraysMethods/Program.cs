using System;
using System.Text;

namespace LDY.IPU.CSharp.Fundamentals.Class3.LoopsArraysMethods {
    public class Program {
        internal static void Main(string[] args) {
            #region Arrays
            if (false) {
                Console.WriteLine(" --------- arrays");
                int[] firstNumberArray0 = new int[0];
                int[] firstNumberArray = new int[4] { 1, 2, 3, 5};
                int[] secondNumberarray = new int[] { 1, 2, 3, 5 };
                int[] thirdNumberarray = new[] { 1, 2, 3, 5 };
                int[] fourthNumberarray = { 1, 2, 3, 5 };
                int[] fifthNumberArray = new int[4];
                fifthNumberArray[0] = 1;
                fifthNumberArray[1] = 2;
                fifthNumberArray[2] = 3;
                fifthNumberArray[3] = 5;

                Console.WriteLine(fifthNumberArray[3]);  // 5
                // Console.WriteLine(fifthNumberArray[5]);  // IndexOutOfRangeException

                int[,] firstMultiDimensionalArray;
                int[,] secondMultiDimensionalArray = new int[2, 3];
                int[,] thirdMultiDimensionalArray = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
                int[,] fourthMultiDimensionalArray = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
                int[,] fifthMultiDimensionalArray = new[,] { { 0, 1, 2 }, { 3, 4, 5 } };
                int[,] sixthMultiDimensionalArray = { { 0, 1, 2 }, { 3, 4, 5 } };

                var element = sixthMultiDimensionalArray[1, 1];

                int[][] jaggedArray = new int[][]
                {
                    new int[] { 1, 3, 5, 7, 9 },
                    new int[] { 10, 2, 4, 6 },
                    new int[] { 11, 22 },
                    new int[] { 11, 22 },
                    new int[] { 11, 22 }
                };
                var elementjaggedArray = jaggedArray[3];

                var array1 = new int[] { 1, 3, 5, 7, 9, 11 };
                var array2 = new int[] { 2, 4, 6 };
                int[][] jaggedArray2 = new int[][] {
                    array1,
                    array2
                };
            }
            #endregion

            #region Loops
            if (false) {
                Console.WriteLine(" --------- Loops");
                //for
                Console.WriteLine("for");
                int[][] jaggedArray = new int[][]
                {
                    new int[] {1,3,5,7,9},
                    new int[] {0,2,4,6},
                    new int[] {11,22}
                };
                //for ([инициализация счетчика]; [условие]; [изменение счетчика]) { 
                //   действия
                //}
                for (int i = 0; i < jaggedArray.Length; i++) {
                    for (int j = 0; j < jaggedArray[i].Length; j++) {
                        Console.WriteLine($"[{i},{j}] = {jaggedArray[i][j]}");
                    }
                }

                //foreach
                Console.WriteLine("foreach");
                int iteratorForeach = 0;
                int arrayIndex = 0;
                foreach (int[] innerArray in jaggedArray) {
                    arrayIndex++;
                    int elementIndex = 0;
                    foreach (int itemArray in innerArray) {
                        elementIndex++;
                        Console.WriteLine($"[{arrayIndex},{elementIndex}] = {itemArray}");
                    }
                }

                //continue
                foreach (int number in new int[] { 1, 3, 7, 10 }) {
                    if (number > 7) {
                        continue;
                    }
                    Console.WriteLine("number" + number);
                }

                //while
                Console.WriteLine("while");
                string dataFromService = "data-sha512-key-dasjdha.kjasdAS:LJFOIUJDFJASDiho;sn_dasdgUadgauislgd";
                // string dataFromService = string.Empty;
                int iterationWhile = 0;
                while (dataFromService.Length < 50) {
                    Console.WriteLine("iteration " + iterationWhile++ + " getting data");
                    dataFromService += "askdHJLIA:Y@IHLWDN>ASDH-dahsdlasd";
                }

                //do...while
                Console.WriteLine("do...while");
                string exitWordDoWhile = "stop";
                string inputWordDoWhile = string.Empty;
                int iterationDoWhile = 0;
                do {
                    Console.WriteLine("iteration " + iterationDoWhile++ + " Write something");
                    inputWordDoWhile = Console.ReadLine();
                    Console.WriteLine("your word is " + inputWordDoWhile);
                    if (exitWordDoWhile == inputWordDoWhile) {
                        Console.WriteLine(" => Good bye");
                    }

                } while (exitWordDoWhile != inputWordDoWhile);

            }
            #endregion

            #region Methods
            if (false) {
                Console.WriteLine(" --------- Methods");
                //void method
                SayHello();

                // return 
                string gottenHello = GetHello();
                Console.WriteLine("gottenHello = " + gottenHello);

                // pass argument
                string gottenHelloWithName = GetHelloWithName("Ivan");
                Console.WriteLine("gottenHelloWithName = " + gottenHelloWithName);

                // overload - the same name with different count of arguments
                string gottenHelloWithNames = GetHelloWithName("Ivan", "Mark");
                Console.WriteLine("gottenHelloWithNames = " + gottenHelloWithNames);

                // get recursive hello
                string gottenHellorecursive = GetHelloRecursive("Ivan");
                Console.WriteLine("gottenHellorecursive = " + gottenHellorecursive);

                // Increment number recursively
                IncrementNumberRecursively(1);

                //write all arguments
                WriteAllWhatYouGot("aaa", "bbb", "ccc", "ddd");

                // write array
                string[] arrayToWrite = new string[] { "aaa", "bbb", "ccc", "ddd" };
                WriteStringArray(arrayToWrite);

                //QuickSortArray Array recursively
                QuickSortArray();
            }
            #endregion

            #region Strings + StringBuilder
            if (false) {
                Console.WriteLine(" --------- Strings + StringBuilder");

                StringBuilder stringBuilder = new StringBuilder("Name: ");
                Console.WriteLine("Length: {0}", stringBuilder.Length);
                Console.WriteLine("Capacity: {0}", stringBuilder.Capacity);

                stringBuilder.Append(" tutorial");
                Console.WriteLine("Length: {0}", stringBuilder.Length);
                Console.WriteLine("Capacity: {0}", stringBuilder.Capacity);

                stringBuilder.Append(" C#");
                Console.WriteLine("Length: {0}", stringBuilder.Length);
                Console.WriteLine("Capacity: {0}", stringBuilder.Capacity);

                StringBuilder stringBuilder2 = new StringBuilder("Hi dear friend");
                stringBuilder2.Append("!");
                stringBuilder2.Insert(stringBuilder2.Length, "Enjoy the world ");
                Console.WriteLine(stringBuilder2);

                stringBuilder2.Replace("world", "silence!");
                Console.WriteLine(stringBuilder2);

                stringBuilder2.Remove(3, 5);
                Console.WriteLine(stringBuilder2);

                string resultString = stringBuilder2.ToString();
                Console.WriteLine(resultString);
            };
            #endregion

            Console.ReadLine();
        }

        #region MethodsImplementation
        private static void SayHello() {
            Console.WriteLine("Hello World");
        }

        private static string GetHello() {
            return "Hello Mark";
        }

        private static string GetHelloWithName(string name) {
            return "Hello " + name;
        }

        private static string GetHelloWithName(string nameOne, string nameTwo) {
            return "Hello " + nameOne + "+" + nameTwo;
        }

        private static string GetHelloRecursive(string name) {
            if (name.Length < 20) {
                name += GetHelloRecursive(name + " " + name);
            }
            return " Hello " + name;
        }

        private static int IncrementNumberRecursively(int number) {
            Console.WriteLine("start recursion =" + number);
            if (number == 5) {
                return number;
            }
            // number = DoSomething(++number);
            IncrementNumberRecursively(++number);
            Console.WriteLine("return recursion =" + number);
            return number;
        }

        public static void WriteAllWhatYouGot(params string[] something) {
            Console.WriteLine("WriteAllWhatYouGot");
            for (int i = 0; i < something.Length; i++) {
                Console.WriteLine(something[i]);
            }
        }

        public static void WriteStringArray(string[] arrayToWrite) {
            Console.WriteLine("WriteStringArray");
            foreach (var item in arrayToWrite) {
                Console.WriteLine(item);
            }
        }

        #region QuickSortArray
        private static void QuickSortArray() {
            var randomizer = new Random();
            for (int i = 0; i < 100; i++) {
                Console.WriteLine($"------------i = {i}");
                int[] randomArray = CreateRandomArray(randomizer);
                PrintArray("Array BeforeSort", randomArray);
                int[] sortedArray = SortArrayRecursively(randomArray);
                PrintArray("Array AfterSort", sortedArray);
            }
        }

        private static void PrintArray(string preText, int[] randomArray) {
            foreach (var item in randomArray) {
                preText += " " + item;
            }
            Console.WriteLine(preText);
        }

        private static int[] CreateRandomArray(Random randomizer) {
            int arrayLength = randomizer.Next(10, 20);
            var randomArray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++) {
                randomArray[i] = randomizer.Next(0, 100);
            }
            return randomArray;
        }

        private static int[] SortArrayRecursively(int[] arrayToSort) {
            if (arrayToSort.Length > 1) {
                int middleElementIndex = arrayToSort.Length / 2 - 1;
                int middleElementValue = arrayToSort[middleElementIndex];

                int[] dividedArray = new int[arrayToSort.Length];
                int minAssignedIndex = 0;
                int maxAssignedIndex = arrayToSort.Length - 1;

                int currentForeachIndex = 0;
                foreach (var item in arrayToSort) {
                    if (currentForeachIndex != middleElementIndex) {
                        if (middleElementValue > item) {
                            dividedArray[minAssignedIndex] = item;
                            minAssignedIndex++;
                        } else {
                            dividedArray[maxAssignedIndex] = item;
                            maxAssignedIndex--;
                        }
                    }
                    currentForeachIndex++;
                }
                int positionMiddleElementAfterSorting = minAssignedIndex;
                dividedArray[positionMiddleElementAfterSorting] = middleElementValue;

                int[] unsortedFirstPart = GetArrayByStartAndEndIndexes(dividedArray, 0, positionMiddleElementAfterSorting);
                int[] sortedFirstPart = SortArrayRecursively(unsortedFirstPart); // RECURSIVE
                int[] unsortedSecondPart = GetArrayByStartAndEndIndexes(dividedArray, positionMiddleElementAfterSorting + 1, dividedArray.Length - 1);
                int[] sortedSecondPart = SortArrayRecursively(unsortedSecondPart); // RECURSIVE

                arrayToSort = MergeArrays(sortedFirstPart, sortedSecondPart);
            }
            return arrayToSort;
        }

        private static int[] GetArrayByStartAndEndIndexes(int[] tempArray, int startIndex, int endIndex) {
            int[] cutArray = new int[endIndex - startIndex + 1];
            int cutArrayEmptyIndex = 0;
            for (int i = startIndex; i <= endIndex; i++) {
                cutArray[cutArrayEmptyIndex] = tempArray[i];
                cutArrayEmptyIndex++;
            }
            return cutArray;
        }

        private static int[] MergeArrays(int[] sortedFirstPart, int[] sortedSecondPart) {
            int[] mergedArray = new int[sortedFirstPart.Length + sortedSecondPart.Length];
            int mergedArrayEmptyIndex = 0;
            foreach (var item in sortedFirstPart) {
                mergedArray[mergedArrayEmptyIndex] = item;
                mergedArrayEmptyIndex++;
            }
            foreach (var item in sortedSecondPart) {
                mergedArray[mergedArrayEmptyIndex] = item;
                mergedArrayEmptyIndex++;
            }
            return mergedArray;
        }
        #endregion

        #endregion

    }
}









