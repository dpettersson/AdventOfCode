using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * --- Day 6: Signals and Noise ---

Something is jamming your communications with Santa. Fortunately, your signal is only partially jammed, and protocol in situations like this is to switch to a simple repetition code to get the message through.

In this model, the same message is sent repeatedly. You've recorded the repeating message signal (your puzzle input), but the data seems quite corrupted - almost too badly to recover. Almost.

All you need to do is figure out which character is most frequent for each position. For example, suppose you had recorded the following messages:

eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar
The most common character in the first column is e; in the second, a; in the third, s, and so on. Combining these characters returns the error-corrected message, easter.

Given the recording in your puzzle input, what is the error-corrected version of the message being sent?


    --- Part Two ---

Of course, that would be the message - if you hadn't agreed to use a modified repetition code instead.

In this modified code, the sender instead transmits what looks like random data, but for each character, the character they actually want to send is slightly less likely than the others. Even after signal-jamming noise, you can look at the letter distributions in each column and choose the least common letter to reconstruct the original message.

In the above example, the least common character in the first column is a; in the second, d, and so on. Repeating this process for the remaining characters produces the original message, advent.

Given the recording in your puzzle input and this new decoding methodology, what is the original message that Santa is trying to send?

Although it hasn't changed, you can still get your puzzle input.


    **/
namespace DaySix
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<String> lines = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Daniel\documents\visual studio 2015\Projects\AdventOfCode2016\DaySix\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();

            string firstMessage = solvePartOne(lines);
            System.Console.WriteLine("THe first message is: {0}", firstMessage);

            string secondMessage = solvePartTwo(lines);
            System.Console.WriteLine("THe first message is: {0}", secondMessage);

        }

        private static string solvePartTwo(List<string> lines)
        {
            string message = "";

            // This is bad. But the input has constant length :)
            Dictionary<string, int>[] charCounters = new Dictionary<string, int>[lines[0].Length];
            for (int i = 0; i < lines[0].Length; i++)
            {
                charCounters[i] = new Dictionary<string, int>();
            }

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    string charToAdd = line.Substring(i, 1);

                    if (charCounters[i].ContainsKey(charToAdd))
                    {
                        charCounters[i][charToAdd]++;
                    }
                    else
                    {
                        charCounters[i].Add(charToAdd, 1);
                    }
                }
            }

            for (int i = 0; i < charCounters.Length; i++)
            {
                Dictionary<string, int> currentDict = charCounters[i];

                var sortedDict = from entry in currentDict orderby entry.Value ascending select entry;
                message += sortedDict.First().Key.ToString();
            }

            return (message);
        }

        private static string solvePartOne(List<string> lines)
        {
            string message = "";

            // This is bad. But the input has constant length :)
            Dictionary<string, int>[] charCounters = new Dictionary<string, int>[lines[0].Length];
            for(int i = 0; i < lines[0].Length; i++)
            {
                charCounters[i] = new Dictionary<string, int>();
            }

            foreach (string line in lines)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    string charToAdd = line.Substring(i, 1);

                    if(charCounters[i].ContainsKey(charToAdd))
                    {
                        charCounters[i][charToAdd]++;
                    }
                    else
                    {
                        charCounters[i].Add(charToAdd, 1);
                    }
                }
            }

            for(int i = 0; i < charCounters.Length; i++)
            {
                Dictionary<string, int> currentDict = charCounters[i];

                var sortedDict = from entry in currentDict orderby entry.Value descending select entry;
                message += sortedDict.First().Key.ToString();
            }

            return (message);
        }
    }
}
