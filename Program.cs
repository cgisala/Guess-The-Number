using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {

        #region Heading
        //The heading function gives the name of the game, the name of the author, and game version.
        static void Heading()
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("*                                                          *");
            Console.WriteLine("*              Program: GUESS THE NUMBER                   *");
            Console.WriteLine("*              Author:  Christian Gisala                   *");
            Console.WriteLine("*              Version: 3.0.0                              *");
            Console.WriteLine("*                                                          *");
            Console.WriteLine("************************************************************");
        }
        #endregion

        #region Introduction
        //The intro function gives a greeting and explains the game.
        static void Intro()
        {
            Console.WriteLine("\n                       **  WELCOME  **\n");
            Console.WriteLine("  The game will start with a coin toss and the winner will  ");
            Console.WriteLine("  make the loser guess a number between 1 and 100.          ");
        }
        #endregion

        #region Farewell Message
        //This function gives a farewell message and the game statistic.
        static void Farewell()
        {
            Console.WriteLine("\n-------------------Thank You For Playing--------------------");
            Console.WriteLine("\n-----------------Press the 'ENTER' key to exit---------------");
            Console.ReadLine();
        }

        #endregion

        #region  Game Statistics
        //This function displays the game statistics
        static void Statistics(int player, int comp, int playerTurn, int computerTurn, int game)
        {
            float playerAvg, compAvg;

            Console.WriteLine("\n----------------------Game Statistics-----------------------");
            if (playerTurn == 0)
            {
                //The player did not play the game.
                playerAvg = 0;
                //Calculates the computer average guesses.
                compAvg = comp / computerTurn;

                Console.WriteLine($"\n            Player average guess--------- {playerAvg}");
                Console.WriteLine($"            Computer average guess------- {compAvg}");
                Console.WriteLine($"            Number of games played------- {game}");
            }
            else if(computerTurn == 0)
            {
                //Computer did not play the game
                compAvg = 0;
                //Calculates the players avgerage guesses.
                playerAvg = player / playerTurn;

                Console.WriteLine($"\n            Player average guess--------- {playerAvg}");
                Console.WriteLine($"            Computer average guess------- {compAvg}");
                Console.WriteLine($"            Computer average guess------- {compAvg}");
            }
            else
            {
                //Calculates the players avgerage guesses.
                playerAvg = player / playerTurn;
                //Calculates the computer average guesses.
                compAvg = comp / computerTurn;

                Console.WriteLine($"\n            Player average guess--------- {playerAvg}");
                Console.WriteLine($"            Computer average guess------- {compAvg}");
                Console.WriteLine($"            Number of games played------- {game}");
            }
            
        }

        #endregion

        #region Coin Toss Function
        //The function generates a random number between 1 and 2.
        static int CoinToss()
        {
            Random rand = new Random();
            int tossResult = rand.Next(1, 3);
            return tossResult;
        }

        #endregion

        #region WhoGoesFirst Function
        //The function takes in the user choice and compares it with the result from the coin toss
        //to determine who goes first.
        static int WhoGoesFirst(ref int nameCount, ref string name)
        {
            int winner = 0, num = -1;
            int userPick = 0, nameLength = 0;
            
            //Prompt the user to enter their name.
            if(nameCount == 0)
            {
                name = UserName();
                nameCount++;
            }
            Console.WriteLine($"\n\n{name} which side of the coin do you want? (1 = Heads or 2 = Tails)");
            string input = Console.ReadLine();

            //Checks to see if the input value is an integer and if the value is with the range of the menu.
            userPick = MenuError(input);
            
            nameLength = name.Length;

            Console.WriteLine("\n\n                        ** COIN TOSS **");

            //Generates the dashes after the name
            string dashes = DashGenerator(nameLength);

            if (userPick == 1)
            {
                Console.WriteLine($"\n               {name}{dashes}Heads");
            }
            else
            {
                Console.WriteLine($"\n               {name}{dashes}Tails");
            }

            int CoinSide = CoinToss();

            if (CoinSide == 1)
            {
                Console.WriteLine("               Coin Toss Result-----------Heads\n\n");
            }
            else
            {
                Console.WriteLine("               Coin Toss Result-----------Tails\n\n");
            }
            if (userPick == CoinSide)
            {
                Console.WriteLine($"\n  ---------------------{name} goes first-----------------------");
                winner = 1;
            }
            else
            {
                Console.WriteLine("\n  -------------------Computer goes first----------------------");
                winner = 2;
            }
            return winner;
        }

        #endregion

        #region MenuError Function
        //This function Checks to see if the input value is an integer and if 
        //the value is with the range of the menu.
        static int MenuError(string input)
        {
            int num = -1;
            int userPick = 0;
            while (true)
            {
                //Checks to see if the input is a string number.
                if (!int.TryParse(input, out num))
                {
                    Console.WriteLine("    **Error: The value you entered is not an integer!**    ");
                    input = Console.ReadLine();
                }
                //Checks to see if the input is either 1 or 2.
                else if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 2)
                {
                    Console.WriteLine("   **Error: The value you entered is not in the menu!** ");
                    input = Console.ReadLine();
                }
                else
                {
                    //Converts the string into an integer.
                    userPick = Convert.ToInt32(input);
                    break;
                }
            }
            return userPick;
        }
        #endregion

        #region InputError Function
        //This function Checks to see if the input value is an integer and if 
        //the value is between 1 to 100.
        static int InputError(string input)
        {
            int num = -1;
            int mysteryNumber = 0;
            while (true)
            {
                //Checks to see if the input is a string number.
                if (!int.TryParse(input, out num))
                {
                    Console.WriteLine("        **Error: The value you entered is not an integer!**    ");
                    Console.WriteLine("\n               **Enter a number between 1 and 100**      ");
                    input = Console.ReadLine();
                }
                //Checks to see if the input is between 1 and 100.
                else if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 100)
                {
                    Console.WriteLine("         **Error: The value you entered is out of range!** ");
                    Console.WriteLine("\n               **Enter a number between 1 and 100**      ");
                    input = Console.ReadLine();
                }
                else
                {
                    //Converts the string into an integer.
                    mysteryNumber = Convert.ToInt32(input);
                    break;
                }
            }
            return mysteryNumber;
        }
        #endregion

        #region GameLogic Function
        static int GameLogic(int playerTurn, int mysteryNumber, string name)
        {
            int counter = 0, max = 100, min = 1;
            int guess = 0, mid = 0, randNum = 0;
            string YesOrNo = "";
            
            switch(playerTurn)
            {
                //The computer is guessing the players number
                case 1:
                    //The computer makes an initial guess
                    guess = max / 2;

                    while(true)
                    {
                        //The computer asks the user if the guess is correct?
                        Console.WriteLine($"\n{name} is the number {guess}? (y = Yes or n = No)");

                        //Counts each guess.
                        counter++;

                        //The user responds to the computers question.
                        YesOrNo = Console.ReadLine();

                        if (YesOrNo?.ToLower().FirstOrDefault() == 'y')
                        {
                            //The computer guess the mystery number correct.
                            Console.WriteLine($"\nIt took the computer {counter} guesses.");
                            break;
                        }
                        else if (YesOrNo?.ToLower().FirstOrDefault() == 'n')
                        {
                            //The computer asks if the number is above the guess.
                            Console.WriteLine($"\n{name} is it above {guess}? (y = Yes or n = No)");

                            //The user responds to the computers question.
                            YesOrNo = Console.ReadLine();

                            if (YesOrNo?.ToLower().FirstOrDefault() == 'y')
                            {
                                min = guess + 1;
                                mid = (max - min) / 2;
                                guess = min + mid;
                            }
                            else if (YesOrNo?.ToLower().FirstOrDefault() == 'n')
                            {
                                max = guess - 1;
                                mid = (max - min) / 2;
                                guess = min + mid;
                            }
                        }
                        else
                        {
                            //The prints an error message.
                            Console.WriteLine("\n  **Error: The input value is not correct** ");

                            //Restate the question to the user.
                            Console.WriteLine($"\n{name} is the number {guess}? (y = Yes or n = No)");

                            //The user responds to the computers question.
                            YesOrNo = Console.ReadLine();
                        }
                    }
                    break;
                //The player is guessing the computers number
                case 2:
                    guess = mysteryNumber;
                    counter++;

                    Random rand = new Random();

                    //Generates a number between 1 and 100.
                    randNum = rand.Next(1, 101);

                    while(true)
                    {
                        if (guess == randNum)
                        {
                            Console.WriteLine($"\nCongratulations {name}, you guessed the number correct.");
                            Console.WriteLine($"\n{name}, it took you {counter} guesses.");                           
                            break;
                        }
                        else
                        {
                            if (guess < randNum)
                            {
                                Console.WriteLine("\nYour guess is too low.\n");
                                guess = Convert.ToInt32(Console.ReadLine());
                                counter++;
                            }
                            else
                            {
                                Console.WriteLine("\nYour guess is to High.\n");
                                guess = Convert.ToInt32(Console.ReadLine());
                                counter++;
                            }
                        }
                    }
                    break;
            }
            return counter;
        }
        #endregion

        #region UserName Function
        //This prompts the user to enter their name and capitalizes the first letter.
        static string UserName()
        {
            string NewName;

            Console.WriteLine("\n\nPlease enter your first name:");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            NewName = char.ToUpper(name[0]) + name.Substring(1);
            return NewName;
        }
        #endregion

        #region DashGenerator Function
        //This function adjust the generated dashes based on the length of the user's name.
        static string DashGenerator(int nameLength)
        {
            int newNum = 0, fixedNum = 27;
            char s = '-';
            string dash = "";

            newNum = fixedNum - nameLength;

            for (int i = 0; i < newNum; i++)
            {
                dash += s;
            }
            return dash;
        }

        #endregion

        static void Main(string[] args)
        {
            //Variables
            int mysteryNumber = 0, nameCount = 0, game = 0;
            int player = 0, computer = 0, playerTurn = 0, computerTurn = 0, compSum = 0, playerSum = 0;
            string PlayerName = "";

            //Displays the game heading
            Heading();

            //Displays the game into
            Intro();

            //Loops until the user chooses to exit the game.
            while(true)
            {

                //Prints the number of game
                Console.WriteLine($"\n\n                        ** GAME: {game + 1} **");
                int winner = WhoGoesFirst(ref nameCount, ref PlayerName);


                switch (winner)
                {
                    //The user wins the coin toss and goes first
                    case 1:
                        Console.WriteLine($"\n{PlayerName} enter a number between 1 and 100 for the computer to guess");
                        Console.WriteLine("followed by the 'Enter' key on the keyboard.\n");
                        mysteryNumber = InputError(Console.ReadLine());

                        //Takes a number from the player for the computer to guess and
                        //outputs the number of guesses it took the computer.
                        computer = GameLogic(winner, mysteryNumber, PlayerName);

                        compSum += computer;

                        //Counts the number of computer's turn.
                        computerTurn++;
                        break;
                    //The computer wins the coin toss and goes first.
                    case 2:
                        Console.WriteLine($"\n{PlayerName} guess the number I'm thinking of that is between 1 and 100.\n");
                        mysteryNumber = InputError(Console.ReadLine());

                        //Takes a number from the computer for the player to guess and 
                        //outputs the number of guesses it took the player.
                        player = GameLogic(winner, mysteryNumber, PlayerName);

                        playerSum += player;

                        //Counts the number of player's turn.
                        playerTurn++;
                        break;
                }
                //Counts the number of games played
                game++;

                //Asks if the player wants to continue playing the game.
                Console.WriteLine("\nDo you want to contiue playing? (y = Yes or n = No)\n");
                string choice = Console.ReadLine();

                //If the user answers no the loop will break.
                if (choice?.ToLower().FirstOrDefault() == 'n')
                {
                    break;
                }
            }
            //Displays the game statistics.
            Statistics(playerSum, compSum, playerTurn, computerTurn, game);

            //Displays a thank you message to the player.
            Farewell();
        }
    }
}
