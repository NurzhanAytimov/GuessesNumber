using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessesNumbers
{
    internal class Game
    {
        private readonly int min = 1;
        private readonly int max = 100;
        private readonly int maxTries = 5;

        Players players;

        public Game(int min = 1 , int max = 100, int maxTries = 5)
        {
            this.min = min;
            this.max = max;
            this.maxTries = maxTries;
        }

        //метод для старта
        // и выбор кто будет угадывать
        public void StartGame()
        {
            Console.WriteLine("Who will guess?");
            Console.WriteLine("1.if Human, enter '1'");
            Console.WriteLine("2.if Computer, enter '2'");

            int guessPlayer = int.Parse(Console.ReadLine());

            if (guessPlayer == 1)
                HumanPlayer();

            else
                ComputerPlayer();
        }
        //компьютер загадывает число
        public void HumanPlayer()
        {
            Random random = new Random();
            int number = random.Next(min, max);

            int guess = 0;
            int tries = 0;
            Console.WriteLine("Enter guess: ");

            while (guess != number && tries < maxTries) 
            {
               
                try
                {
                    guess = int.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Please enter a number!");

                }
                   
                
                if(guess > max && guess < min) 
                {
                    Console.WriteLine("Enter a number 1-100 !");
                }

                else if(guess == number)
                {
                    Console.WriteLine("You winner!");
                }

                else if (guess < number)
                {
                    Console.WriteLine("The number is greates!");

                }
                else if (guess > number)
                {
                    Console.WriteLine("The number is less!");

                }
                tries++;

                if(tries == maxTries)
                {
                    Console.WriteLine("You lose!");
                }
               
                
            }
        }

        //компьютер пытается угадать число
        public void ComputerPlayer()
        {
            Console.WriteLine("Guess a number from 1 to 100!");
            Console.WriteLine("Enter number: ");

            int guess = 0;
            while(guess == 0)
            {
                try
                {
                    int parsNumber = int.Parse(Console.ReadLine());
                    if (parsNumber >= this.min && parsNumber <= this.max)
                        guess = parsNumber;
                    else
                    {
                        Console.WriteLine("Guess number a 1-100");
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Guess number a 1-100!");
                }

                int lastGuess = 0;
                int tries = 0;
                int min = this.min;
                int max = this.max;

                while(lastGuess != guess && tries < this.max)
                {
                    lastGuess = (max + min) / 2;
                    Console.WriteLine($"You guessed this number {lastGuess} ?");
                    Console.WriteLine("1.If yes, enter '1'");
                    Console.WriteLine("2.If you number greater, enter '2'");
                    Console.WriteLine("3.If yout number less, enter '3'");

                    int result = int.Parse(Console.ReadLine());

                    if(result == 1)
                    {
                        Console.WriteLine("Computer winner!");
                    }
                    else if(result == 2)
                    {
                        min = lastGuess;
                    }
                    else
                    {
                        max = lastGuess;
                    }
                    tries++;

                    if(tries == maxTries)
                    {
                        Console.WriteLine("Human Winner!");
                        break;
                    };
                    

                }

              
                
               
            }
        }


    }
}
