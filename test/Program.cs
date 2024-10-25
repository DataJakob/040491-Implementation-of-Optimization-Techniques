using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


// Create a 4by4 matrix, with random integers, varying from 1 to 10
// Perform TSP
// Print result

namespace NNA
{
    public class Vector2D
    {
        // Initialize matrix and random
        private double[,] matrix;
        private Random random = new Random();
        public Vector2D()
        {
            matrix = new double[4, 4];
        }

        // FIll the matrix
        internal void FillMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = random.Next(1, 11);
                    }
                }
            }
        }


        static int N_possibilities(double[,] matrix) // input_type input_name
        {
            int poss = 1;
            for (int i = 1; i < 4; i++)
            {
                poss *= i;
            }
            return poss;
        }

        internal void algorithm()
        {
            int[] visited = {1};
            int[] unvisited = { 2, 3, 4 };
            List<int> unvisitedList = new List<int>(unvisited);


            int start_city = double.PositiveInfinity;
            int time = double.PositiveInfinity;

            int favorable_dest = 0;
            int favorable_time = 0;
            int x = 0;

            do
            {
                int length = unvisited.Length;
                for (int i = 0; i < length; i++)
                {
                    if (matrix[start_city, unvisited[i]] <= favorable_time)
                    {
                        favorable_dest = unvisited[i];
                        favorable_time = matrix[start_city, unvisited[i]];
                    }
                }
                start_city = favorable_dest;
                time += favorable_time;
                unvisited.RemoveAt(favorable_dest);
                x += 1;
            } while (x == 3);


        }




        // Print the matrix
        internal void PrintMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Vector2D vector = new Vector2D();   // Initialize the new matrix
            vector.FillMatrix();
            vector.PrintMatrix();
            Console.WriteLine(vector.matrix[0, 2]);
            //vector.algorithm();
            //int possibilities = N_possibilities(vector.matrix);
            //Console.WriteLine(possibilities);
            Console.ReadLine();
        }
    }

}
