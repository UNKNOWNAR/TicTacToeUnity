using System;
using System.IO;

public class TTT3x3 : TTTAI
{
    Check check1 = new Check();
    char[] play = new char[9];

    void fill()
    {
        // Fill the array with blank spaces
        for (int i = 0; i < 9; i++)
            play[i] = ' ';
    }

    int input(int n)
    {
        // Input for multiplayer
        if (n % 2 == 0)
        {
            Console.WriteLine("PLAYER 1 ENTER:-");
            int n1 = int.Parse(Console.ReadLine());
            if (play[n1 - 1] == ' ')
            {
                play[n1 - 1] = 'X';
                return (n - 1);
            }
            else
            {
                Console.WriteLine("WRONG INPUT. INPUT COINCIDING, INPUT AGAIN");
                return 10;
            }
        }
        else
        {
            Console.WriteLine("PLAYER 2 ENTER:-");
            int n1 = int.Parse(Console.ReadLine());
            if (play[n1 - 1] == ' ')
            {
                play[n1 - 1] = 'O';
                return (n - 1);
            }
            else
            {
                Console.WriteLine("WRONG INPUT. INPUT COINCIDING, INPUT AGAIN");
                return 10;
            }
        }
    }

    int input(char c)
    {
        // Input for single player
        Console.WriteLine("PLAYER ENTER:-");
        int n = int.Parse(Console.ReadLine());
        if (play[n - 1] == ' ')
        {
            play[n - 1] = c;
            return (n - 1);
        }
        else
        {
            Console.WriteLine("WRONG INPUT. INPUT COINCIDING, INPUT AGAIN");
            return 10;
        }
    }

    void input(char c, int f, int x, int n1)
    {
        // Calling TTTAI
        int n = input(play, f, x, n1);
        play[n] = c;
    }

    public void TicTacToe()
    {
        int c = 5;
        while (c == 5)
        {
            string result = "GAME ON";
            int choice = 2;
            fill();
            int i = 0;
            if (choice == 1)
            {
                while (i < 9)
                {
                    int n = input(i);
                    if (n != 10)
                        i++;
                    if (i >= 4)
                    {
                        if (check1.check(play) == 'X')
                        {
                            Console.WriteLine("Player 1 Won, Congratulations");
                            result = "Player 1 Won";
                            break;
                        }
                        else if (check1.check(play) == 'O')
                        {
                            Console.WriteLine("Player 2 Won, Congratulations");
                            result = "Player 2 Won";
                            break;
                        }
                    }
                }
                if (result == "GAME ON")
                    Console.WriteLine("Well Played Player 1 and Player 2, The Game is a Draw");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter 1 for Easy Mode, 2 for Medium mode, 3 for Hard Mode, and 4 for Impossible Mode");
                int n1 = int.Parse(Console.ReadLine());
                int r = (new System.Random().Next(2) + 1);
                if (r == 1)
                {
                    Console.WriteLine("Computer's First Move");
                    int n = -1;
                    while (i < 9)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("MOVE BY COMPUTER");
                            Console.WriteLine();
                            input('X', r, n, n1);
                            i++;
                        }
                        else
                        {
                            n = input('O');
                            if (n != 10)
                                i++;
                            else
                                continue;
                        }
                        if (i > 4)
                        {
                            if (check1.check(play) == 'X')
                            {
                                result = "Computer Won";
                                Console.WriteLine("Computer Won");
                                break;
                            }
                            else if (check1.check(play) == 'O')
                            {
                                result = "Congratulations, Player Won";
                                Console.WriteLine("Congratulations, Player Won");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Player's First Move");
                    int n = -1;
                    while (i < 9)
                    {
                        if (i % 2 == 0)
                        {
                            n = input('X');
                            if (n != 10)
                                i++;
                            else
                                continue;
                        }
                        else
                        {
                            Console.WriteLine("MOVE BY COMPUTER");
                            input('O', r, n, n1);
                            i++;
                        }
                        if (i > 4)
                        {
                            if (check1.check(play) == 'X')
                            {
                                result = "Congratulations, Player Won";
                                Console.WriteLine("Congratulations, Player Won");
                                break;
                            }
                            else if (check1.check(play) == 'O')
                            {
                                result = "Computer Won";
                                Console.WriteLine("Computer Won");
                                break;
                            }
                        }
                    }
                }
                if (result == "GAME ON")
                    Console.WriteLine("The Game is a Draw");
            }
            Console.WriteLine("ENTER 5 to Continue and any Number to Quit");
            c = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Thanks for Playing the Game");
    }
}
