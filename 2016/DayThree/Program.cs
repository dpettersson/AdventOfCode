using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * Now that you can think clearly, you move deeper into the labyrinth of hallways and office furniture that makes up this part of Easter Bunny HQ. This must be a graphic design department; the walls are covered in specifications for triangles.

Or are they?
The design document gives the side lengths of each triangle it describes, but... 5 10 25? Some of these aren't triangles. You can't help but mark the impossible ones.
In a valid triangle, the sum of any two sides must be larger than the remaining side. For example, the "triangle" given above is impossible, because 5 + 10 is not larger than 25.
In your puzzle input, how many of the listed triangles are possible?

--- Part Two ---

Now that you've helpfully marked up their design documents, it occurs to you that triangles are specified in groups of three vertically. Each set of three numbers in a column specifies a triangle. Rows are unrelated.

For example, given the following specification, numbers with the same hundreds digit would be part of the same triangle:

101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603
In your puzzle input, and instead reading by columns, how many of the listed triangles are possible?


 * **/
namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int correctTriangleRowCount = 0;
            int correctTriangleColumnCount = 0;
            List<String> lines = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\users\daniel\documents\visual studio 2015\Projects\AdventOfCode2016\DayThree\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();

            correctTriangleRowCount = solvePartOne(lines);
            correctTriangleColumnCount = solvePartTwo(lines);

            System.Console.WriteLine("The number of correct triangles (rows) is: {0}", correctTriangleRowCount);
            System.Console.WriteLine("The number of correct triangles (columns) is: {0}", correctTriangleColumnCount);
        }

        private static int solvePartOne(List<string> lines)
        {
            int correctTriangleCount = 0;
            List<string> sides = new List<string>();

            foreach (string line in lines)
            {
                sides.Clear();
                sides.AddRange(line.Split(' ').ToList());
                sides.RemoveAll(s => string.IsNullOrWhiteSpace(s));

                int side1 = int.Parse(sides[0]);
                int side2 = int.Parse(sides[1]);
                int side3 = int.Parse(sides[2]);

                if (side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2)
                {
                    correctTriangleCount++;
                }
            }

            return (correctTriangleCount);
        }


        private static int solvePartTwo(List<string> lines)
        {
            int correctTriangleCount = 0;
            
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();

            List<string> tmp = new List<string>();

            foreach (string line in lines)
            {
                tmp.Clear();
                tmp.AddRange(line.Split(' ').ToList());
                tmp.RemoveAll(s => string.IsNullOrWhiteSpace(s));

                column1.Add(tmp[0]);
                column2.Add(tmp[1]);
                column3.Add(tmp[2]);
            }

            correctTriangleCount += countCorrectTriangles(column1);
            correctTriangleCount += countCorrectTriangles(column2);
            correctTriangleCount += countCorrectTriangles(column3);
           
            return (correctTriangleCount);
        }


        private static int countCorrectTriangles(List<string> data)
        {
            int correctTriangleCount = 0;

            for (int index = 0; index < data.Count; index += 3)
            {
                int side1 = int.Parse(data[index]);
                int side2 = int.Parse(data[index + 1]);
                int side3 = int.Parse(data[index + 2]);

                if (side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2)
                {
                    correctTriangleCount++;
                }
            }

            return (correctTriangleCount);
        }

    }
}
