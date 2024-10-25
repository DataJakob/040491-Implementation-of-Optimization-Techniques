using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace third


/* I use internal for things i want to access inside this project.
Furthermore, I use public if I want to access it outside the project.

The code block below is called a method, and can be viewed as a function.
<Access specificer> <Return Type> <Method Name> (Parameter List) {
    Method Body
}

Void is used for things that does output a variable.

Mehtods comes are built inside a function.

Methods should start with uppercase letters
*/
{
    internal class Program
    {
        ///<summary>
        /// Find the highest value of two integers
        ///</summary>
        ///<return></returns>
        static void PrintProgramStarted()
        {
            Console.WriteLine("---Hello world!---");
        }

        class Point
        {
            internal double X { get; set; }
            internal double Y { get; set; }
        }

        static void PrintThePoint()
        {
            Point p1 = new Point();
            p1.X = 5.5;
            p1.Y = 4.2;
            Console.WriteLine($"\nPrint this X:{p1.X} and Y{p1.Y}");
        }


        static int Maximum(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        static void Main(string[] args)
        {
            PrintProgramStarted();
            Console.WriteLine($"Maximum of 2 and 5 is {Maximum(2, 5)}");
            PrintThePoint();
            Console.ReadLine();
        }
    }
}
