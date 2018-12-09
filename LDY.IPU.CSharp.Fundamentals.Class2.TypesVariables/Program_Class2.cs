using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class2.TypesVariables {
    class Program_Class2 {
        static void Main(string[] args) {
            #region Variables
            if (false) {
                Console.WriteLine(" --------- Variables");
                int firstLocalVariable; // declaration
                //firstLocalVariable = 10; // assignment. first assignment calls initialization
                int secondLocalVariable = 10; // declaration + initialization 
            }
            #endregion

            #region Types
            if (false) {
                ///// Types
                System.Console.WriteLine(" --------- Types");
                /// Value Types
                Console.WriteLine("Value Types");
                byte byteVariable = 127;
                Console.WriteLine("byteVariable = " + byteVariable);

                short shortVariable = 32676;
                Console.WriteLine("shortVariable = " + shortVariable);

                int intVariable = 2147483647;
                Console.WriteLine("intVariable = " + intVariable);

                long longVariable = 9223372036854775807;
                Console.WriteLine("longVariable = " + longVariable);

                float floatVariable = 1003.555555555555555555555555555555555555555f;
                Console.WriteLine("floatVariable = " + floatVariable);

                double doubleVariable = 1003.555555555555555555555555555555555555555d;
                double doubleVariableWithoutPrefix = 1003.555555555555555555555555555555555555555;
                Console.WriteLine("doubleVariable = " + doubleVariable);
                Console.WriteLine("doubleVariableWithoutPrefix = " + doubleVariableWithoutPrefix);

                decimal decimalVariable = 1003.555555555555555555555555555555555555555m;
                Console.WriteLine("decimalVariable = " + decimalVariable);

                char charVariable = 'h';
                Console.WriteLine("charVariable = " + charVariable);

                bool boolVariable = false; // true
                Console.WriteLine("boolVariable = " + boolVariable);

                /// Reference Types
                Console.WriteLine("Reference Types");
                string stringVariable = "name";
                Console.WriteLine("stringVariable = " + stringVariable);

                int[] arrayVariable = new int[] { 1, 2, 3 };
                Console.WriteLine("arrayVariable = " + arrayVariable);

                object objectVariable = new object();
                Console.WriteLine("objectVariable = " + objectVariable);
            }
            #endregion

            #region Scope
            ///// Scope
            /// - method
            /// - block
            /// - class
            /// 
            #endregion

            #region Constants
            if (false) {
                Console.WriteLine(" --------- Constants");
                const int firstConstant = 10;
                // 1) initialization is required; 2) it's possible to change value; 
            }
            #endregion

            #region Arithmetic operations
            if (false) {
                Console.WriteLine(" --------- Arithmetic operations");
                var additionResult = 10 + 10;
                Console.WriteLine("additionResult = " + additionResult);

                var subtractionResult = 10 - 10;
                Console.WriteLine("subtractionResult = " + subtractionResult);

                var multiplicationResult = 10 * 10;
                Console.WriteLine("multiplicationResult = " + multiplicationResult);

                var divisionResult = 10 / 10;
                Console.WriteLine("divisionResult = " + divisionResult);
            }
            #endregion

            #region Increment/Decrement
            if (false) {
                Console.WriteLine(" --------- Increment/Decrement");
                int incrementPost = 10;
                int decrementPost = 10;
                Console.WriteLine("incrementPost = " + incrementPost++);
                Console.WriteLine("decrementPost = " + decrementPost--);
                Console.WriteLine("incrementPost = " + incrementPost);
                Console.WriteLine("decrementPost = " + decrementPost);
                int incrementPre = 10;
                int decrementPre = 10;
                Console.WriteLine("incrementPre = " + ++incrementPre);
                Console.WriteLine("decrementPre = " + --decrementPre);
            }
            #endregion

            #region Class Math
            if (false) {
                Console.WriteLine(" --------- Class Math");
                double MathAbs_12point4 = Math.Abs(-12.4);
                Console.WriteLine("MathAbs_12point4 = " + MathAbs_12point4);

                double MathCeiling2point34 = Math.Ceiling(2.34);
                Console.WriteLine("MathCeiling2point34 = " + MathCeiling2point34);

                double MathFloor2point56 = Math.Floor(2.56);
                Console.WriteLine("MathFloor2point56 = " + MathFloor2point56);

                double MathRound20point56 = Math.Round(20.56);
                Console.WriteLine("MathRound20point56 = " + MathRound20point56);

                double MathRound20point46 = Math.Round(20.46);
                Console.WriteLine("MathRound20point46 = " + MathRound20point46);

                double MathRound20point567_2sighns = Math.Round(20.567, 2);
                Console.WriteLine("MathRound20point567_2sighns = " + MathRound20point567_2sighns);

                double MathRound20point463_1sighn = Math.Round(20.463, 1);
                Console.WriteLine("MathRound20point463_1sighn = " + MathRound20point463_1sighn);

                double MathSqrt16 = Math.Sqrt(16);
                Console.WriteLine("MathSqrt16 = " + MathSqrt16);

                double MathTruncate16point89 = Math.Truncate(16.89);
                Console.WriteLine("MathTruncate16point89 = " + MathTruncate16point89);
            }
            #endregion

            #region Equality Operators and Less\Greater than
            if (false) {
                Console.WriteLine(" --------- Equality Operators and Less\\Greater than");
                bool comparisonResult1 = 2 < 10;
                Console.WriteLine("2 < 10 : " + comparisonResult1);

                var comparisonResult2 = 2 <= 10;
                Console.WriteLine("2 <= 10 : " + comparisonResult2);

                var comparisonResult3 = 2 == 10;
                Console.WriteLine("2 == 10 : " + comparisonResult3);

                var comparisonResult4 = 2 != 10;
                Console.WriteLine("2 != 10 : " + comparisonResult4);

                var comparisonResult5 = 2 > 10;
                Console.WriteLine("2 > 10 : " + comparisonResult5);

                var comparisonResult6 = 2 >= 10;
                Console.WriteLine("2 >= 10 : " + comparisonResult6);
            }
            #endregion

            #region Logic operations
            if (false) {
                Console.WriteLine(" --------- Logic operations");
                bool logicalAND_true_true = true && true;
                Console.WriteLine("logicalAND_true_true = " + logicalAND_true_true);

                var logicalAND_true_false = true && false;
                Console.WriteLine("logicalAND_true_false = " + logicalAND_true_false);

                var logicalAND_false_true = false && true;
                Console.WriteLine("logicalAND_false_true = " + logicalAND_false_true);

                var logicalAND_false_false = false && false;
                Console.WriteLine("logicalAND_false_false = " + logicalAND_false_false);

                var logicalOR_true_true = true || true;
                Console.WriteLine("logicalOR_true_true = " + logicalOR_true_true);

                var logicalOR_true_false = true || false;
                Console.WriteLine("logicalOR_true_false = " + logicalOR_true_false);

                var logicalOR_false_true = false || true;
                Console.WriteLine("logicalOR_false_true = " + logicalOR_false_true);

                var logicalOR_false_false = false || false;
                Console.WriteLine("logicalOR_false_false = " + logicalOR_false_false);
            }
            #endregion

            #region Conditional operators
            if (false) {
                Console.WriteLine(" --------- Conditional operators");
                // if {...} else {...}
                int ifElseFirstValue = 10;
                Console.WriteLine("START: ifElseFirstValue = " + ifElseFirstValue);

                if (ifElseFirstValue > 5) {
                    Console.WriteLine("ifElseFirstValue > 5");
                } else {
                    Console.WriteLine("ifElseFirstValue <= 5");
                }

                int ifElseSecondValue = 49;
                Console.WriteLine("START: ifElseSecondValue = " + ifElseSecondValue);
                if (ifElseSecondValue > 50) {
                    Console.WriteLine("ifElseSecondValue > 50");
                    if (ifElseSecondValue > 75) {
                        Console.WriteLine("ifElseSecondValue > 75");
                    } else {
                        Console.WriteLine("ifElseFirstValue <= 50");
                    }
                } else {
                    Console.WriteLine("ifElseSecondValue <= 50");
                    if (ifElseSecondValue > 25) {
                        Console.WriteLine("ifElseSecondValue > 25");
                    } else {
                        Console.WriteLine("ifElseFirstValue <= 25");
                    }
                }
                // switch
                string color = "green";
                switch (color) {
                    case "blue": {
                            Console.WriteLine("I like " + color + " color");
                            break;
                        }
                    case "green": {
                            Console.WriteLine("I love " + color + " color");
                            break;
                        }
                    case "yellow": {
                            Console.WriteLine(color + "is not bad color");
                            break;
                        }
                    default: {
                            Console.WriteLine("I don't know " + color + " color");
                            break;
                        }
                }

                // ternary operator
                int age = 16;
                // result = 'condition' ? 'true case' : 'false case';
                int beerVolumeInMl = (age > 21) ? 500 : 0;

                Console.WriteLine("beer volume is allowed with " + age + "years is " + beerVolumeInMl);
            }
            #endregion

            #region Casting and Type Conversions
            if (false) {
                Console.WriteLine(" --------- Casting and Type Conversions");
                // widening - implicit conversion
                byte byteVariableWidening = 4;
                int intVariableWidening = byteVariableWidening + 70;
                Console.WriteLine("intVariableWidening = " + intVariableWidening);

                // narrowing - explicit conversion
                int intVariableNarrowing = 257;
                byte byteVariableNarrowing = (byte)(intVariableNarrowing);
                Console.WriteLine("byteVariableNarrowing = " + byteVariableNarrowing);

                // Convert - for implementation interface IConvertable
                try {
                    int m = Convert.ToInt32("abc");
                } catch (FormatException e) {
                    Console.WriteLine("int m = Convert.ToInt32('abc');");
                    Console.WriteLine(e.Message);
                }
                // Parse
                try {
                    int m = Int32.Parse("abc");
                } catch (FormatException e) {
                    Console.WriteLine("int m = Int32.Parse('abc');");
                    Console.WriteLine(e.Message);
                }
                //TryParse
                int tryParseValid;
                bool tryParseBool = int.TryParse("abc", out tryParseValid);
                if (tryParseBool) {
                    Console.WriteLine("string '-105' was converted to int = " + tryParseValid);
                }

                int tryParseInvalid;
                if (int.TryParse("abc", out tryParseInvalid)) {
                    Console.WriteLine("string 'abc' was converted to int = " + tryParseInvalid);
                } else {
                    Console.WriteLine("string 'abc' wasn't converted to int");
                }
            }
            #endregion

            int[] numbers = new int[4];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[0] = 2;

            foreach (int item in numbers) {
                Console.WriteLine(item);
            }
            int arrraCount = numbers.Length;
            for (int i = arrraCount - 1; i >= 0; i--) {
                numbers[i] = i * 10;
            }
            //for (int i = 0; i < length; i++) { }

            Console.ReadLine();
        }
    }
}

