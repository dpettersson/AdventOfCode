#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <vector>
#include <iterator>

using std::ifstream;
using std::cout;
using std::endl;
using std::string;
using std::getline;
using std::map;
using std::pair;
using std::vector;

using std::iterator;

void dayOnePartOne()
{
   int currentFrequency = 0;
   ifstream inputFile;
   string line;

   inputFile.open("input.txt");

   while (getline(inputFile, line))
   {
      int currentLine = stoi(line, nullptr, 10);
      currentFrequency += currentLine;
   }

   cout << "The lastFrequency is " << currentFrequency << endl;
}


void dayOnePartTwo()
{
   int currentFrequency = 0;
   ifstream inputFile;
   string line;
   map<int, bool> frequences;
   vector<int> frequencyChangeVector;
 
   inputFile.open("input.txt");

   while (getline(inputFile, line))
   {
      int currentLine = stoi(line, nullptr, 10);
      frequencyChangeVector.insert(frequencyChangeVector.end(), currentLine);
   }

   bool duplicateFrequencyFound = false;
   vector<int>::iterator frequencyIterator = frequencyChangeVector.begin();

   while (!duplicateFrequencyFound)
   {
      currentFrequency += *frequencyIterator;

      if (frequences.find(currentFrequency) != frequences.end())
      {
         duplicateFrequencyFound = true;
      }
      else
      {
         frequences.insert( pair<int, bool>(currentFrequency, false));
      }

      if (frequencyIterator == frequencyChangeVector.end() - 1)
      {
         frequencyIterator = frequencyChangeVector.begin();
      }
      else
      {
         frequencyIterator++;
      }
   }

   cout << "Duplicate  frequence found: " << currentFrequency << endl;
}


int main()
{
   dayOnePartOne();
   dayOnePartTwo();

   return 0;
}
