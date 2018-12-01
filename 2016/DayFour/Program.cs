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


--- Part Two ---

With all the decoy data out of the way, it's time to decrypt this list and get moving.

The room names are encrypted by a state-of-the-art shift cipher, which is nearly unbreakable without the right software. However, the information kiosk designers at Easter Bunny HQ were not expecting to deal with a master cryptographer like yourself.

To decrypt a room name, rotate each letter forward through the alphabet a number of times equal to the room's sector ID. A becomes B, B becomes C, Z becomes A, and so on. Dashes become spaces.

For example, the real name for qzmt-zixmtkozy-ivhz-343 is very encrypted name.

What is the sector ID of the room where North Pole objects are stored?


    ***/
namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int sectorIdSum = 0;
            int NorthPoleSectorId = 0;

            List<String> data = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Daniel\documents\visual studio 2015\Projects\AdventOfCode2016\DayFour\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                data.Add(line);
            }

            file.Close();

            sectorIdSum = solvePartOne(data);
            NorthPoleSectorId = solvePartTwo(data);

            System.Console.WriteLine("The sum of the sector ID's is: {0}", sectorIdSum);
            System.Console.WriteLine("The sectorId of the sector containing \"north pole objects\" is: {0}", NorthPoleSectorId);


        }


        private static int solvePartOne(List<string> data)
        {
            int sectorIdSum = 0;
            string pattern = @"([\w+-]+)(\d{3})\[(\w+)\]";

            Regex r = new Regex(pattern);
            Match m;

            foreach (string line in data)
            {
                m = r.Match(line);

                if (m.Success)
                {
                    string roomName = m.Groups[1].ToString();
                    int sectorID = int.Parse(m.Groups[2].ToString());
                    string checksum = m.Groups[3].ToString();
                    Dictionary<char, int> letters = new Dictionary<char, int>();
                    Boolean status = true;

                    //Lets remove the "-"
                    roomName = new string(roomName.Where(x => !"-".Contains(x)).ToArray());

                    ///Count the letters
                    for(int i = 0; i < roomName.Length; i++)
                    {
                        char c = roomName[i];

                        if (letters.ContainsKey(c))
                        {
                            letters[c] = letters[c] + 1;
                        }
                        else
                        {
                            letters[c] = 1;
                        }
                    }

                    IOrderedEnumerable<KeyValuePair<char, int>> lettersSortedByOccurenses = letters
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);
                    
                    for (int i = 0; i < checksum.Length; i++)
                    {
                        if (lettersSortedByOccurenses.ElementAt(i).Key != checksum[i])
                        {
                            status = false;
                        }
                    }

                    if(status)
                    {
                        sectorIdSum += sectorID;
                    }
                }
            }

            return (sectorIdSum);
        }


        private static int solvePartTwo(List<string> data)
        {
            int sectorId = 0;

            string stringToFind = "northpole object";  // Written as "North pole objects" in the description.
            string acceptedLetters = "abcdefghijklmnopqrstuvwxyz";
            string pattern = @"([\w+-]+)-(\d{3})\[(\w+)\]";
            string decodedString = "";

            int stepsToRotate = 0;

            Regex r = new Regex(pattern);
            Match m;

            foreach (string line in data)
            {
                if(sectorId != 0)
                {
                    break;
                }

                decodedString = "";

                m = r.Match(line);
                
                if (m.Success)
                {
                    string roomName = m.Groups[1].ToString();
                    int sectorID = int.Parse(m.Groups[2].ToString());

                    stepsToRotate = sectorID % acceptedLetters.Length;
                    
                    for(int i = 0; i < roomName.Length; i++)
                    {
                        char currentLetter = roomName.ElementAt(i);

                        if (currentLetter.Equals('-'))
                        {
                            decodedString += " ";
                        }
                        else
                        {
                            int indexOfChar = (acceptedLetters.IndexOf(currentLetter) + stepsToRotate) % acceptedLetters.Length;                     
                            decodedString += acceptedLetters[indexOfChar];
                        }
                    }

                    if (decodedString.StartsWith(stringToFind))
                    {
                        sectorId = sectorID;
                    }
                }
            }

            return (sectorId);
        }
    }
}
