using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/**
 * --- Day 4: Security Through Obscurity ---

Finally, you come across an information kiosk with a list of rooms. Of course, the list is encrypted and full of decoy data, but the instructions to decode the list are barely hidden nearby. Better remove the decoy data first.

Each room consists of an encrypted name (lowercase letters separated by dashes) followed by a dash, a sector ID, and a checksum in square brackets.

A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order, with ties broken by alphabetization. For example:

aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
not-a-real-room-404[oarel] is a real room.
totally-real-room-200[decoy] is not.
Of the real rooms from the list above, the sum of their sector IDs is 1514.

What is the sum of the sector IDs of the real rooms?

    ***/


namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            List<String> data = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\users\daniel\documents\visual studio 2015\Projects\AdventOfCode2016\DayFour\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                data.Add(line);
            }

            file.Close();

        }


        private static int solvePartOne(List<string> data)
        {
            int correctLinesCount = 0;
            string pattern = @"([\w+-]+)(\d+)\[(\w+)\]";

            Regex r = new Regex(pattern);
            Match m;

            foreach(string line in data)
            {
                m = r.Match(line);

                if (m.Success)
                {

                }
            }

            return (correctLinesCount);
        }


        //private static int solvePartTwo(List<string> lines)


    }
}
