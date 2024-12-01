
using System;

//Console.WriteLine("Hello, World!");
//Console.ReadLine();


// State input parameters
// Create a grid with lists
// Implement algorithms, do em all!


class MyProgram
{ 
    static void Main()
    {
        int x = 5;
        double[,] matrix = MatrixGenerator(x);
        PrintMatrix(matrix);
        Console.WriteLine(" ");
        double reward_NN = Nearest_Neighbour_Algorithm(matrix);
        Console.WriteLine(reward_NN);
        Console.WriteLine("");
        double reward_FI = Farthest_Insertion_Algorithm(matrix);
        Console.WriteLine(reward_FI);
        
        Console.ReadLine(); 
    }


    static double[,] MatrixGenerator(int x)
    {
        double[,] matrix = new double[x,x];
        Random rand = new Random(2);

        for (int i = 0; i < x; i++)
        {
            for (int j=0; j < x; j++)
            {
                matrix[i,j] = (i==j) ? 0: rand.NextDouble();
            }
            //Console.WriteLine();
        }
        return matrix;
    }


    static void PrintMatrix(double[,] matrix)
    {
        int x = matrix.GetLength(0);
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Console.Write($"{matrix[i, j]:F2} ");
            }
            Console.WriteLine();
        }
    }
    static double Nearest_Neighbour_Algorithm(double[,] matrix)
    {

        int n_cities = matrix.GetLength(0);   // Determine n locations

        List<int> visited = new List<int>();  // Creating list for visited location
        List<int> unvisited = new List<int>();   // -||- Same for unvisited locations
        

        // Filling in start values
        for (int num = 1; num < n_cities; num++)
        {
            unvisited.Add(num);
        }
        visited.Add(0);
        int start_city = 0;
        int new_city = 0;
        double reward = 0.00;


        // Running a do while loop to detect lowest distances. 
        do
        {
            double city_distance = double.PositiveInfinity;

            for (int i = 0; i < unvisited.Count(); i++)
                if (matrix[start_city, unvisited[i]] != 0 && matrix[start_city, unvisited[i]] < city_distance)
                {
                    new_city = i;
                    city_distance = matrix[start_city, unvisited[i]];
                }

            reward += city_distance;
            start_city = unvisited[new_city];


            visited.Add(unvisited[new_city]);
            unvisited.RemoveAt(new_city);
        }
        while (visited.Count() < n_cities);
        reward += matrix[visited[visited.Count() - 1], 0];

        // Printing out the tour
        foreach (double num in visited)
        {
            Console.WriteLine(num);
        }
        return reward;
    }



    static double Farthest_Insertion_Algorithm(double[,] matrix)
    {

        int n_cities = matrix.GetLength(0);   // Determine n locations

        List<int> visited = new List<int>();  // Creating list for visited location
        List<int> unvisited = new List<int>();   // -||- Same for unvisited locations
        List<int> experimental = new List<int>();   // -||- Same for unvisited locations


        // Filling in start values
        for (int num = 1; num < n_cities; num++)
        {
            unvisited.Add(num);
        }
        visited.Add(0);
        int departure_city = 0;
        int arrival_city = 0;
        double reward = 0.00;


        // Running a do while loop to detect lowest distances. 
        do
        {
            double city_distance = 0;
            
            for (int i = 0; i < visited.Count() ;i++)
            {
                for (int j = 0; j  < unvisited.Count() ; i++)
                {
                    if (matrix[visited[i], unvisited[j]] > city_distance)
                    {
                        departure_city = i;
                        arrival_city = j;
                        
                    }
                }
            }
            if (visited.Count() == 1)
            {
                visited.Add(unvisited[arrival_city]);
                unvisited.RemoveAt(arrival_city);
                reward += matrix[visited[departure_city], unvisited[arrival_city]];
            }
            else
            {
                experimental = visited;
                for (int i = 0; i < visited.Count()-1; i++)
                {
                    experimental.Insert((int)(0.5+1)*2, unvisited[departure_city]);
                    // run all expeiemntal
                    // Save tour if it's short.
                }
            }sss
            

        }
        while (visited.Count() < n_cities);
        reward += matrix[visited[visited.Count() - 1], 0];

        // Printing out the tour
        foreach (double num in visited)
        {
            Console.WriteLine(num);
        }
        return reward;
    }
}
