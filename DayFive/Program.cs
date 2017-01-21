using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

/**
 * 
 * --- Day 5: How About a Nice Game of Chess? ---

You are faced with a security door designed by Easter Bunny engineers that seem to have acquired most of their security knowledge by watching hacking movies.

The eight-character password for the door is generated one character at a time by finding the MD5 hash of some Door ID (your puzzle input) and an increasing integer index (starting with 0).
A hash indicates the next character in the password if its hexadecimal representation starts with five zeroes. If it does, the sixth character in the hash is the next character of the password.

For example, if the Door ID is abc:

The first index which produces a hash that starts with five zeroes is 3231929, which we find by hashing abc3231929; the sixth character of the hash, and thus the first character of the password, is 1.
5017308 produces the next interesting hash, which starts with 000008f82..., so the second character of the password is 8.
The third time a hash starts with five zeroes is for abc5278568, discovering the character f.
In this example, after continuing this search a total of eight times, the password is 18f47a30.

Given the actual Door ID, what is the password?

Your puzzle input is ojvtpuvg.

--- Part Two ---

As the door slides open, you are presented with a second door that uses a slightly more inspired security mechanism. Clearly unimpressed by the last version (in what movie is the password decrypted in order?!), the Easter Bunny engineers have worked out a better solution.

Instead of simply filling in the password from left to right, the hash now also indicates the position within the password to fill. You still look for hashes that begin with five zeroes; however, now, the sixth character represents the position (0-7), and the seventh character is the character to put in that position.

A hash result of 000001f means that f is the second character in the password. Use only the first result for each position, and ignore invalid positions.

For example, if the Door ID is abc:

The first interesting hash is from abc3231929, which produces 0000015...; so, 5 goes in position 1: _5______.
In the previous method, 5017308 produced an interesting hash; however, it is ignored, because it specifies an invalid position (8).
The second interesting hash is at index 5357525, which produces 000004e...; so, e goes in position 4: _5__e___.
You almost choke on your popcorn as the final character falls into place, producing the password 05ace8e3.

Given the actual Door ID and this new method, what is the password? Be extra proud of your solution if it uses a cinematic "decrypting" animation.

Your puzzle input is still ojvtpuvg.

     * **/

namespace DayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> foundHashes;
            string input = "ojvtpuvg";

            foundHashes = findHashes(input);

            string firstPassword = solvePartOne(foundHashes);
            System.Console.WriteLine("The first password for {0} is {1}", input, firstPassword);

            string secondPassword = solvePartTwo(input);
            System.Console.WriteLine("The second password for {0} is {1}", input, secondPassword);    
        }


        private static List<string> findHashes(string input)
        {
            int index = 0;
            int numberOfHashesToFind = 8;
            int foundHashCount = 0;
            List<String> hashList = new List<string>();

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            Byte[] inputBytes;
            Byte[] hash;

            while (foundHashCount < numberOfHashesToFind)
            {
                inputBytes = System.Text.Encoding.ASCII.GetBytes(input + index.ToString());
                hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder(hash.Length * 2);
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                if (sb.ToString().StartsWith("00000"))
                {
                    hashList.Add(sb.ToString());
                    foundHashCount++;
                }

                index++;
            }
            return (hashList);

        }

        private static string solvePartOne(List<string> hashes)
        {
            string password = "";
            char[] chars = new char[8];

            // eight is the specified limit above
            for(int i = 0; i < hashes.Count && i < 8; i++)
            {
                password += hashes.ElementAt(i).Substring(5, 1);
            }

            return (password);
        }        

        private static string solvePartTwo(string input)
       {
           string password = "";
           
           int index = 0;
           int charIndex;

           System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

           Byte[] inputBytes;
           Byte[] hash;
           char[] passwordChars = new char[] { '-', '-', '-', '-', '-', '-', '-', '-'};

            while (isThereStillCharsLeftToFind(passwordChars))
           {
               inputBytes = System.Text.Encoding.ASCII.GetBytes(input + index.ToString());
               hash = md5.ComputeHash(inputBytes);

               StringBuilder sb = new StringBuilder(hash.Length * 2);
               for (int i = 0; i < hash.Length; i++)
               {
                   sb.Append(hash[i].ToString("x2"));
               }

               if (sb.ToString().StartsWith("00000"))
               {
                    String hashString = sb.ToString();
                    string sub1 = hashString.Substring(5, 1);
                    string sub2 = hashString.Substring(6, 1);
                    System.Console.Write("Hash found at {0} - ", index); 

                    //Check if we got a correct index
                    if(int.TryParse(sub1, out charIndex) && charIndex < 8)
                    {

                        //only set it the first time we find a vlue for it.
                        if (passwordChars[charIndex] == '-')
                        {
                            passwordChars[charIndex] = char.Parse(sub2);
                            System.Console.WriteLine("Char {0} inserted at position {1}", sub2, charIndex);
                            System.Console.WriteLine("The current password is {0}", new string(passwordChars));
                        }
                        else
                        {
                            System.Console.WriteLine("Position {0} is alrady filled", charIndex);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Faulty position: {0}", sub1);
                    }

                }

               index++;
           }

            password = new string(passwordChars);

            return (password);
       }

        private static bool isThereStillCharsLeftToFind(Dictionary<int, char> passwordChars)
        {
            return(passwordChars.ContainsValue('-'));
        }

        private static bool isThereStillCharsLeftToFind(char[] passwordChars)
        {
            bool status = false;

            for (int i = 0; i < passwordChars.Length; i++)
            {
                if(passwordChars[i] == '-')
                {
                    status = true;
                }
            }

            return (status);
        }
    }
}
