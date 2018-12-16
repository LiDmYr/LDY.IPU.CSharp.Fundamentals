using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.UIP.CSharpFundamentals.RouteFinder {
    class Program {
        private static void Main(string[] args) {
            int[][] map = new int[][] {
                new int[] { 0, 0, -1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, -1, 0 },
                new int[] { -1, -1, 0, -1, -1, -1 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, -1, -1, -1, -1, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            };
            int[][] routeOnMap = GetRouteOnMap(map);
            Console.ReadLine();
        }

        private static int[][] GetRouteOnMap(int[][] map) {
            int[] startPoint = new int[] { 0, 0 };
            int[] finishPoint = new int[] { 5, 5 };

            AssignStartPoint(map, startPoint);

            return CreateRouteRecursively(true, map, startPoint, startPoint, finishPoint, 1);
        }

        private static void AssignStartPoint(int[][] map, int[] startPoint) {
            int startPointX = startPoint[0];
            int startPointY = startPoint[1];

            map[startPointX][startPointY] = 1;
        }

        private static int[][] CreateRouteRecursively(bool isRootCall, int[][] map, int[] currentPoint, int[] startPoint, int[] finishPoint, int iteration) {
            PrintMap(map, iteration);

            bool isFinishReached = false;
            string[] directions = new string[] { "Right", "Left", "Up", "Down" };

            foreach (string directionName in directions) {
                int[] suggestedPoint = GetSuggestedPoint(map, currentPoint, directionName);
                bool isDirectionAllowed = IsPointAllowedToMove(map, suggestedPoint, startPoint);
                if (isDirectionAllowed && !isFinishReached) {
                    MarkPointAsReached(map, suggestedPoint);
                    CreateRouteRecursively(false, map, suggestedPoint, startPoint, finishPoint, ++iteration);
                }

                isFinishReached = IsFinishReached(map, finishPoint);

                if (isFinishReached) {
                    break;
                }
            }

            if (isFinishReached) {
                if (isRootCall) {
                    Console.WriteLine("Finally, we reached the goal!!!!");
                }
                return map;

            } else {
                if (isRootCall) {
                    throw new Exception("Please modify the algorithm because a deadlock happened");
                }
                Console.WriteLine($"!!!! [{currentPoint[0]},{currentPoint[1]}] It's a wrong way, let's go back and try to find new one");
                return null;
            }
        }

        private static bool IsFinishReached(int[][] map, int[] finishPoint) {
            int pointY = finishPoint[0];
            int pointX = finishPoint[1];
            return map[pointY][pointX] == 1;
        }

        private static void MarkPointAsReached(int[][] map, int[] reachedPoint) {
            int pointY = reachedPoint[0];
            int pointX = reachedPoint[1];
            map[pointY][pointX] = 1;
        }

        private static int[] GetSuggestedPoint(int[][] map, int[] currentPoint, string direction) {
            int[] suggestedPoint = new int[] { currentPoint[0], currentPoint[1] };
            switch (direction) {
                case "Right":
                    suggestedPoint[1]++;
                    break;
                case "Left":
                    suggestedPoint[1]--;
                    break;
                case "Up":
                    suggestedPoint[0]++;
                    break;
                case "Down":
                    suggestedPoint[0]--;
                    break;
                default:
                    suggestedPoint[0] = int.MaxValue;
                    suggestedPoint[1] = int.MaxValue;
                    break;
            }

            return suggestedPoint;
        }

        private static bool IsPointAllowedToMove(int[][] map, int[] suggestedPoint, int[] startPoint) {
            int pointY = suggestedPoint[0];
            int pointX = suggestedPoint[1];
            bool isSuggestedEqualStartPoint = suggestedPoint[0] == startPoint[0] && suggestedPoint[1] == startPoint[1];
            bool isPointOutOfRange = pointY < 0 || pointY >= map.Length || pointX < 0 || pointX >= map[pointY].Length;
            if (isSuggestedEqualStartPoint || isPointOutOfRange) {
                return false;
            }
            int pointvalue = map[pointY][pointX];
            return pointvalue != -1 && pointvalue != 1;
        }

        private static void PrintMap(int[][] map, int iteration) {
            Console.WriteLine($"{iteration}# MAP:");
            foreach (int[] XaxisMap in map) {
                string xLine = "";
                foreach (int XaxisMapPoint in XaxisMap) {
                    string pointToString = XaxisMapPoint.ToString();
                    string pointToStringModified = pointToString.Length == 1 ? "0" + pointToString : pointToString;
                    xLine += pointToStringModified + " ";
                }
                Console.WriteLine(xLine);
            }
        }
    }
}
