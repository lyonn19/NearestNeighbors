using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestNeighbors
{
    class Program
    {
        static void Main(string[] args)
        {
            //int totalRestaurants = 3;
            //int[,] allLocations = new int[,] {
            //    {1,-3},
            //    {1, 2},
            //    {3, 4}
            //};
            //int numRestaurant = 3;

            int totalRestaurants = 6;
            int[,] allLocations = new int[,] {
                {3,6},
                {2,4},
                {5,3},
                {2,7},
                {1,8},
                {7,9}
            };
            int numRestaurant = 3;

            var result = NearestVegetarianRestaurant(totalRestaurants, allLocations, numRestaurant);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(result[i][j] + " ");

                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        public static List<List<int>> NearestVegetarianRestaurant(int totalRestaurants, int[,] allLocations, int numRestaurants)
        {
            // WRITE YOUR CODE HERE
            var nearestRest = new List<List<int>>();
            var distanceList = new List<List<int>>();

            int bound0 = allLocations.GetUpperBound(0);
            int bound1 = allLocations.GetUpperBound(1);

            for (int i = 0; i <= bound0; i++)
            {
                for (int j = 0; j < bound1; j++)
                {
                    int[,] point = new int[,] { { allLocations[i, j], allLocations[i, j + 1] } };
                    distanceList.Add(new List<int>
                    {
                        i, Convert.ToInt32(Distance(point)),
                    });
                }
            }

            var sorted = distanceList.OrderBy(r => r[1]).ToList();
            for (int i = 0; i <= bound0; i++)
            {
                nearestRest.Add(new List<int>
                {
                    allLocations[sorted[i][0], 0], allLocations[sorted[i][0], 1]
                });
            }

            return nearestRest.Take(numRestaurants).ToList();
        }
        
        // METHOD SIGNATURE ENDS
        private static double Distance(int[,] vegPoint)
        {
            return Math.Sqrt(Math.Pow(vegPoint[0, 0], 2) + Math.Pow(vegPoint[0, 1], 2));
        }

    }
}
