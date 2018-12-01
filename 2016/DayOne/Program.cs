using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/****
 * --- Day 1: No Time for a Taxicab ---

Santa's sleigh uses a very high-precision clock to guide its movements, and the clock's oscillator is regulated by stars. Unfortunately, the stars have been stolen... by the Easter Bunny. To save Christmas, Santa needs you to retrieve all fifty stars by December 25th.
Collect stars by solving puzzles. Two puzzles will be made available on each day in the advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!
You're airdropped near Easter Bunny Headquarters in a city somewhere. "Near", unfortunately, is as close as you can get - the instructions on the Easter Bunny Recruiting Document the Elves intercepted start here, and nobody had time to work them out further.
The Document indicates that you should start at the given coordinates (where you just landed) and face North. Then, follow the provided sequence: either turn left (L) or right (R) 90 degrees, then walk forward the given number of blocks, ending at a new intersection.
There's no time to follow such ridiculous instructions on foot, though, so you take a moment and work out the destination. Given that you can only walk on the street grid of the city, how far is the shortest path to the destination?

For example:

Following R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away.
R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away.
R5, L5, R5, R3 leaves you 12 blocks away.
How many blocks away is Easter Bunny HQ?

Your puzzle answer was 234.

--- Part Two ---

Then, you notice the instructions continue on the back of the Recruiting Document. Easter Bunny HQ is actually at the first location you visit twice.
For example, if your instructions are R8, R4, R4, R8, the first location you visit twice is 4 blocks away, due East.
How many blocks away is the first location you visit twice?

**/


namespace AdventOfCode2016
{
    class DayOne
    {
        enum directions { North, East, South, West };
        static List<String> visited_locations = new List<String>();
        static int firstRevistedLocationX = 0;
        static int firstRevistedLocationY = 0;
        static Boolean firstRevisitedLocationFound = false;


        static void Main(string[] args)
        {
            visited_locations.Add("0,0");
            directions currentDirecton = directions.North;
            int xPosition = 0;
            int yPosition = 0;
            string text = System.IO.File.ReadAllText(@"c:\users\daniel\documents\visual studio 2015\Projects\AdventOfCode2016\AdventOfCode2016\DayOne.txt");
            String[] legs = text.Split(' ');

            foreach (String currentLeg in legs)
            {
                String turnTo = currentLeg.Substring(0, 1);
                String leg = currentLeg.Replace(',', ' ');
                int blocksToWalk = int.Parse(leg.Substring(1, leg.Length - 1));

                switch (turnTo)
                {
                    case "L":
                        if (currentDirecton == directions.North)
                        {
                            currentDirecton = directions.West;
                        }
                        else if (currentDirecton == directions.West)
                        {
                            currentDirecton = directions.South;
                        }
                        else if (currentDirecton == directions.South)
                        {
                            currentDirecton = directions.East;
                        }
                        else
                        {
                            currentDirecton = directions.North;
                        }
                        break;
                    case "R":
                        if (currentDirecton == directions.North)
                        {
                            currentDirecton = directions.East;
                        }
                        else if (currentDirecton == directions.East)
                        {
                            currentDirecton = directions.South;
                        }
                        else if (currentDirecton == directions.South)
                        {
                            currentDirecton = directions.West;
                        }
                        else
                        {
                            currentDirecton = directions.North;
                        }
                        break;
                    default:
                        break;
                }

                switch (currentDirecton)
                {
                    case directions.North:
                        for (int i = 0; i < blocksToWalk; i++)
                        {
                            updateVisitedLocationsList(xPosition, yPosition + i + 1);
                        }

                        yPosition += blocksToWalk;
                        
                        break;
                    case directions.East:
                        for (int i = 0; i < blocksToWalk; i++)
                        {
                            updateVisitedLocationsList(xPosition + i + 1, yPosition);
                        }

                        xPosition += blocksToWalk;

                        break;
                    case directions.South:
                        for (int i = 0; i < blocksToWalk; i++)
                        {
                            updateVisitedLocationsList(xPosition, yPosition - i - 1);
                        }

                        yPosition -= blocksToWalk;

                        break;
                    case directions.West:
                        for (int i = 0; i < blocksToWalk; i++)
                        {
                            updateVisitedLocationsList(xPosition - i - 1, yPosition);
                        }

                        xPosition -= blocksToWalk;
                        break;
                }   
            }

            System.Console.WriteLine("The last coordinate is x:{0} y:{1}, which gives ut the distance: {2}", xPosition, yPosition, System.Math.Abs(xPosition) + System.Math.Abs(yPosition));

            if (firstRevisitedLocationFound)
            {
                System.Console.WriteLine("The first revisited location was: {0},{1}. It happened after {2} steps at a distance of {3}", firstRevistedLocationX, firstRevistedLocationY, visited_locations.Count, System.Math.Abs(firstRevistedLocationX) + System.Math.Abs(firstRevistedLocationY));
            }
            else
            {
                System.Console.WriteLine("No locations were revisited during the trip");
            }
        }

        private static void updateVisitedLocationsList(int xPosition, int yPosition)
        {
            if(firstRevisitedLocationFound)
            {
                return;
            }

            string currentLocationAsString = xPosition.ToString() + "," + yPosition.ToString();

            if (visited_locations.Contains(currentLocationAsString))
            {
                firstRevisitedLocationFound = true;
                firstRevistedLocationX = xPosition;
                firstRevistedLocationY = yPosition;
            }

            visited_locations.Add(currentLocationAsString);
        }
    }
}
