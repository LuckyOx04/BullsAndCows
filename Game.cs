using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Game
    {
        Random r = new Random();
        private int numberOfCows = 0;
        private int numberOfBulls = 0;
        private string number;

        int[] generatedNum;
        int[] guessedNum;

        public Game()
        {
            generatedNum = new int[4];
            guessedNum = new int[4];

            for(int i = 0; i < generatedNum.Length; i++)
            {
                int temp;
                do
                {
                    temp = r.Next(1, 10);
                }
                while (generatedNum.Contains(temp));
                generatedNum[i] = temp;
            }

            Console.WriteLine("A four digit number is generatd. Try and guess it!");
            //PrintGeneratedNum(); Uncomment this if you want to see the generated number (for testing purposes).
            Action();
        }

        //prints the generated number
        void PrintGeneratedNum()
        {
            foreach(int num in generatedNum)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }

        //Asks for a number and prints result from the guess
        //untill the number is guessed.
        void Action()
        {
            while (numberOfBulls != 4)
            {
                numberOfBulls = 0;
                numberOfCows = 0;
                Console.WriteLine("Enter a fout digit number: ");
                number = Console.ReadLine();
                NumStringToSequence();
                CompareSequences();
                Console.WriteLine($"{numberOfBulls} bulls and {numberOfCows} cows.");
            }
            Console.WriteLine("You guessed the number!");
        }

        //takes global string and maps it to global int array.
        //After this check if numbers in the array are non-repeating.
        void NumStringToSequence()
        {
            for (int i = 0; i < 4; i++)
            {
                guessedNum[i] = int.Parse(number[i].ToString());
            }
            if (guessedNum.Distinct().Count() != guessedNum.Length)
            {
                throw new InvalidCastException("Guessed sequence has repeating numbers!");
            }
        }

        //Compares the two global arrays and increments bulls and cows accordingly.
        void CompareSequences()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (generatedNum[i].Equals(guessedNum[j]))
                    {
                        if (j == i)
                        {
                            numberOfBulls++;
                        }
                        else
                        {
                            numberOfCows++;
                        }
                    }
                }
            }
        }
    }
}
