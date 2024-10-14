using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second
{
    // Exercise 2a
    internal class exercise_2a
    {
        //static void Main(string[] args)
        // Make an array and print the results
        static void Display()
        {
            char[] letters = { 'a', 'b', 'c','d','e' };
            List<char> letterList = new List<char> { 'a', 'b', 'c', 'd', 'e' };
            string input =  Console.ReadLine();
            int.TryParse(input, out int option);
            Console.WriteLine(letterList[option]);
            Console.ReadLine(); 
        }
    }
    //*************************************************
    
    internal class exercise_2b
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert points of the exercise:");
            int pointsExercise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert points of the exam:");
            int pointsExam = Convert.ToInt32(Console.ReadLine());
            double grading = (pointsExercise + pointsExam) / 2;
            if (pointsExercise < 0 || pointsExercise < 0)
            {
                Console.WriteLine("You have entered negative values.\n" +
                    "That is not allowed!");
            }
            else if (pointsExercise > 50 && pointsExam > 50)
            {
                Console.WriteLine($"Course passed with {grading}%");
            }
            else
            {
                Console.WriteLine("Course not passed, you suck!");
            }
            Console.ReadLine();
        }
    }




    //*************************************************
    // Example exercise 2
    internal class example_2
    {
        //static void Main(string[] args) 
        static void  Display()
        {   
            Console.WriteLine("hei");
            int[,] matrix = new int[5, 5];
            Random rnd = new Random();
            for (int i = 0; i <matrix.GetLength(0);i++)
                for (int j = 0; j <matrix.GetLength(1);j++)
                    matrix[i,j] = rnd.Next(0, 100);
            int minValue = FindMinimum(matrix);

            //Console.WriteLine(minValue);

            foreach (var doubleValue in DoubleMatrix(matrix))
            {
                Console.WriteLine($"{doubleValue}");
            }

            Console.ReadLine();
        }

        // Function to find minimum number in the matrix
        static int FindMinimum(int[,] matrix) 
        {
            int minimum = matrix[0,0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0;j < cols; j++)
                {
                    if (matrix[i, j] < minimum)
                    {
                        minimum = matrix[i, j];
                    }
                }
            }
            return minimum;

        }
        // Function to double all numbers in the matrix
        static IEnumerable<int> DoubleMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= 2;
                    yield return matrix[i, j];

                }
            }
        }
    }
}