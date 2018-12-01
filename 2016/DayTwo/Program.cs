using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * You arrive at Easter Bunny Headquarters under cover of darkness. However, you left in such a rush that you forgot to use the bathroom! Fancy office buildings like this one usually have keypad locks on their bathrooms, so you search the front desk for the code.

"In order to improve security," the document you find says, "bathroom codes will no longer be written down. Instead, please memorize and follow the procedure below to access the bathrooms."

The document goes on to explain that each button to be pressed can be found by starting on the previous button and moving to adjacent buttons on the keypad: U moves up, D moves down, L moves left, and R moves right. Each line of instructions corresponds to one button, starting at the previous button (or, for the first line, the "5" button); press whatever button you're on at the end of each line. If a move doesn't lead to a button, ignore it.

You can't hold it much longer, so you decide to figure out the code as you walk to the bathroom. You picture a keypad like this:

1 2 3
4 5 6
7 8 9
Suppose your instructions are:

ULL
RRDDD
LURDL
UUUUD
You start at "5" and move up (to "2"), left (to "1"), and left (you can't, and stay on "1"), so the first button is 1.
Starting from the previous button ("1"), you move right twice (to "3") and then down three times (stopping at "9" after two moves and ignoring the third), ending up with 9.
Continuing from "9", you move left, up, right, down, and left, ending with 8.
Finally, you move up four times (stopping at "2"), then down once, ending with 5.
So, in this example, the bathroom code is 1985.

Your puzzle input is the instructions from the document you found at the front desk. What is the bathroom code?

--- Part Two ---

You finally arrive at the bathroom (it's a several minute walk from the lobby so visitors can behold the many fancy conference rooms and water coolers on this floor) and go to punch in the code. Much to your bladder's dismay, the keypad is not at all like you imagined it. Instead, you are confronted with the result of hundreds of man-hours of bathroom-keypad-design meetings:

    1
  2 3 4
5 6 7 8 9
  A B C
    D
You still start at "5" and stop when you're at an edge, but given the same instructions as above, the outcome is very different:

You start at "5" and don't move at all (up and left are both edges), ending at 5.
Continuing from "5", you move right twice and down three times (through "6", "7", "B", "D", "D"), ending at D.
Then, from "D", you move five more times (through "D", "B", "C", "C", "B"), ending at B.
Finally, after five more moves, you end at 3.
So, given the actual keypad layout, the code would be 5DB3.

Using the same instructions in your puzzle input, what is the correct bathroom code?
**/
namespace DayTwo
{
    class Program
    {
        static int startNumber = 5;

        static void Main(string[] args)
        {
            string line;
            List<String> lines = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\users\daniel\documents\visual studio 2015\Projects\AdventOfCode2016\DayTwo\DayTwo.txt");
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();

            string firstCode = solveFirstCode(lines);
            string secondCode = solveSecondCode(lines);

            System.Console.WriteLine("The first code is: {0} and the second is: {1}", firstCode, secondCode);
        }


        enum KeypadValues {ONE = 1, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, A, B, C, D};

        static string solveSecondCode(List<string> lines)
        {
            string code = "";
           int currentNumber = startNumber;

            /**
             *      1
                  2 3 4
                5 6 7 8 9
                  A B C
                    D
            */
            /*List<string> keypad = new List<char>();
            keypad.Add("  1  ");
            keypad.Add(" 234 ");
            keypad.Add("56789");
            keypad.Add(" ABC ");
            keypad.Add("  D  ");
            */

            List<string> availableMoves = new List<string>();
            availableMoves.Add(""); // removes the need for -1 to access the correct element.
            availableMoves.Add("D"); // 1
            availableMoves.Add("RD"); // 2
            availableMoves.Add("RLDU"); // 3
            availableMoves.Add("LD"); // 4
            availableMoves.Add("R"); // 5
            availableMoves.Add("RLDU"); // 6
            availableMoves.Add("RLDU"); // 7
            availableMoves.Add("RLDU"); // 8
            availableMoves.Add("L"); // 9
            availableMoves.Add("RU"); // A
            availableMoves.Add("RLDU"); // B
            availableMoves.Add("LU"); // C
            availableMoves.Add("U"); // D

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    string direction = line.Substring(i, 1);

                    if (availableMoves[currentNumber].Contains(direction))
                    {

                        int moveLength = 1;

                        switch(direction)
                        {
                            case "L":
                                currentNumber  = currentNumber - moveLength;
                                break;
                            case "R":
                                currentNumber = currentNumber + moveLength;
                                break;
                            case "U":
                                /**
                                 *      1
                                      2 3 4
                                    5 6 7 8 9
                                      A B C
                                        D
                                */
                                switch (currentNumber)
                                {
                                    case 3:
                                        moveLength = -2;
                                        break;
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 10:
                                    case 11:
                                    case 12:
                                        moveLength = -4;
                                        break;
                                    case 13:
                                        moveLength = -2;
                                        break;
                                }

                                currentNumber = currentNumber + moveLength;

                                break;
                            case "D":

                                /**
                                 *      1
                                      2 3 4
                                    5 6 7 8 9
                                      A B C
                                        D
                                */
                                switch (currentNumber)
                                {
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 6:
                                    case 7:
                                    case 8:
                                        moveLength = 4;
                                        break;
                                    case 11:
                                        moveLength = 2;
                                        break;
                                }

                                currentNumber = currentNumber + moveLength;
                                break;
                        }
                    }
                }

                string keyToAdd;

                if(currentNumber > 9)
                {
                    keyToAdd = ((KeypadValues)currentNumber).ToString();
                }
                else
                {
                    keyToAdd = currentNumber.ToString();
                }


                code += keyToAdd.ToString();
            }

            return (code);
        }

        static string solveFirstCode(List<string> lines)
        {
            string code = "";
            int currentNumber = startNumber;

            foreach (string line in lines)         
            {
                for (int i = 0; i < line.Length; i++)
                {
                    string direction = line.Substring(i, 1);

                    switch (direction)
                    {
                        case "U":
                            if (currentNumber - 3 > 0)
                            {
                                currentNumber -= 3;
                            }
                            break;
                        case "D":
                            if (currentNumber + 3 < 10)
                            {
                                currentNumber += 3;
                            }
                            break;
                        case "L":
                            if ((currentNumber - 1) % 3 != 0)
                            {
                                currentNumber -= 1;
                            }
                            break;
                        case "R":
                            if (currentNumber % 3 != 0)
                            {
                                currentNumber += 1;
                            }
                            break;
                    }
                }

                code += currentNumber.ToString();
            }

            return (code);
        }
    }
}
