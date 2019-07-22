using System;

namespace NumberGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = "NumberGuess";
            string version = "version";
            string master = "Poime";
            bool startGame = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Version: {1} made by {2}", appName, version, master);
            Console.ResetColor();
            Console.WriteLine("What is your name player1?");
            string inputname1 = Console.ReadLine();
            Console.WriteLine("Hello {0}", inputname1);
            Console.WriteLine("What is your name player2?");
            string inputname2 = Console.ReadLine();
            Console.WriteLine("Hello {0}", inputname2);

            Player player1 = new Player();
            player1.name = inputname1;
            player1.points = 0;
            Player player2 = new Player();
            player2.name = inputname2;
            player2.points = 0;

            while (startGame)
            {
                int count = 0;

                Random random = new Random();
                int number = random.Next(6);
                string inputNumber = "";
                bool flag = true;
                while (flag)
                {
                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.ResetColor();
                        if (count % 2 == 0) { 
                            Console.WriteLine("{0} pick a number from 0 to 5", player1.name);
                            inputNumber = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("{0} pick a number from 0 to 5", player2.name);
                            inputNumber = Console.ReadLine();
                        }
                        int value;
                        if (int.TryParse(inputNumber, out value))
                        {
                            flag2 = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is not a number!");
                            Console.ResetColor();
                        }
                    }

                    if (Int32.Parse(inputNumber) == number)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct :D");

                        if(count % 2 == 0)
                        {
                            player1.points = player1.points+1;
                        }
                        else
                        {
                            player2.points = player2.points + 1;
                        }

                        flag = false;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Do you want to continue? (y/n)");
                        string answer = Console.ReadLine();

                        bool cont = true;
                        while (cont)
                        {
                            if (answer.ToLower().Equals("y"))
                            {
                                startGame = true;
                                cont = false;
                            }

                            else if (answer.ToLower().Equals("n"))
                            {
                                startGame = false;
                                cont = false;
                            }
                        }


                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Try again!");
                    }
                    count++;
                }

                if (player1.points > player2.points)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Final results: {0} WINNER with {1} points", player1.name, player1.points);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Final results: {0} LOSER with {1} points", player2.name, player2.points);
                }
                else if (player2.points > player1.points)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Final results: {0} WINNER with {1} points", player2.name, player2.points);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Final results: {0} LOSER with {1} points", player1.name, player1.points);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("DRAW: {0} with {1} points", player1.name, player1.points);
                    Console.WriteLine("{0} with {1} points", player2.name, player2.points);

                }

                Console.ResetColor();

            }

        }
    }

    class Player
    {

        public string name { get; set; }
        public int points { get; set; }

    }
}
