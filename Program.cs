using System;
using System.Linq;

namespace MasterMind
{
    class Program
    {
        private int totalChances = 10;
        static void Main(string[] args)
        {
            Program p = new Program();
            var randomValue = p.RandomNumGenerator(); 
            p.Display(randomValue);
            p.StartGame(randomValue);
            Console.WriteLine("\nGame over");
            Console.WriteLine("\nGame answer is");
            p.Display(randomValue);
            Console.ReadLine();
        }

        public void StartGame(int[] RandomValue)
        {
            string gameStartValue;
            while (totalChances > 0)
            {
                Console.WriteLine("Do you want to start the game? Yes (y) or No (n): ");
                gameStartValue = Console.ReadLine();
                var wantCountLower = gameStartValue?.ToLower();
                if (wantCountLower == "y")
                {
                    Console.WriteLine("You got " + totalChances + " chances");
                    MasterMind(RandomValue);
                    totalChances--;
                }
                else if (wantCountLower == "n")
                {
                    Console.WriteLine("\nYou are forfeited from game");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }
        }

        public int[] RandomNumGenerator()
        {
            int[] randomvalue = new int[4];
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                randomvalue[i] = random.Next(1, 6);
            }
            return randomvalue;
        }

        public void MasterMind(int[] randomvalue)
        {
            int userInputCount = 0;
            int[] userValues = new int[4];
            Console.WriteLine("Enter the number between 1 to 6 and press enter");
            while (userInputCount < 4)
            {
                var value = Console.ReadLine();
                if (int.TryParse(value, out userValues[userInputCount]))
                {
                    userInputCount++;
                }
                else
                {
                    Console.WriteLine("Please enter numbers only");
                }
                if (userInputCount == 4)
                {
                    string[] resultValue = new string[5];
                    for (int z = 0; z < userValues.Length; z++)
                    {
                        resultValue[z] = userValues[z].ToString();
                    }
                    Display(SequenceChecker(userValues, randomvalue, resultValue));
                }
                else
                {
                    Console.WriteLine("Enter the number and press enter");
                }
            }
        }

        public string[] SequenceChecker(int[] inputsequence, int[] randomvalue, string[] resultvalue)
        {
            for (int i = 0; i < randomvalue.Length; i++)
            {
                for (int y = 0; y < inputsequence.Length; y++)
                {
                    if (randomvalue[i] == inputsequence[y])
                    {
                        resultvalue[y] = inputsequence[y] == randomvalue[y]? resultvalue[y] = "+" + inputsequence[y]: resultvalue[y] = "-" + inputsequence[y];
                    }
                }
            }
            FinalResult(inputsequence, randomvalue, resultvalue);
            return resultvalue;
        }

        public void FinalResult(int[] inputsequence, int[] randomvalue, string[] resultvalue)
        {
            if (inputsequence.SequenceEqual(randomvalue))
            {
                Console.WriteLine("\nYou won the game");
                Display(resultvalue);
                Console.ReadLine();
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine("\nYou lost the round");
            }
        }
        private void Display(int[] randomvalue)
        {
            foreach (var item in randomvalue)
            {
                Console.Write(item);
            }
            Console.Write("\n");
        }

        public void Display(string[] result)
        {
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.Write("\n");
        }
    }
}
