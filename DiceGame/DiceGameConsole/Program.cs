using DiceGame;
using System;

 namespace DiceGameConsole
{
    class Program
    {
        private static Game game;

        static void Main(string[] args)
        {
            Boolean setDiceSize = false;
            Boolean GameOver = false;

            Console.WriteLine("Please enter the number of sides you want for your dice: ");
            string input = Console.ReadLine();
            HandleConsoleMessages messageHandler = new HandleConsoleMessages();
            setDiceSize = messageHandler.InputWasCorrect(input);

            while (setDiceSize == false)
            {
                Console.WriteLine("You have not entered a valid number for the dice. Please try again");
                input = Console.ReadLine();
                setDiceSize = messageHandler.InputWasCorrect(input);
            }

            startGame(input);
            Console.WriteLine($"The first throw was a {game.getLastThrow()}. Do you think next throw will be higher or lower?");

            while (!GameOver)
            {
                int diceValue = game.getLastThrow();
                string guess = Console.ReadLine();
                GameOver = game.GuessWasCorrect(guess);
                if (diceValue == game.getLastThrow())
                {
                    Console.WriteLine("It was neither higher or lower. Guess higher or lower again!");
                }
                else if (!GameOver)
                {
                    Console.WriteLine($"Your guess was correct! The dice was {game.getLastThrow()}. Do you think the next throw will be higher or lower?");
                }

            }

            Console.WriteLine($"Sorry, your guess was incorrect. The dice was {game.getLastThrow()}. You collected {game.getPoints()} points. Good luck next time!");
            Console.ReadLine();
        }

        private static void startGame(string input)
        {
            int userInput = Int32.Parse(input);
            IRandom random = new MyRandom(1,userInput);
            Dice dice = new Dice(userInput,random);
            int startvalue = dice.throwDice();
            game = new Game(dice,startvalue);
        }
    }
}
