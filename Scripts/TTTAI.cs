using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TTTAI
{
    int i = 0;
    int n = 0;
    int a = 0;

    void reset1()
    {
        i = 0;
        n = 0;
        a = 0;
    }

    int tools(int k)
    {
        if (k == 1 || k == 2 || k == 3)
            return 0;
        else if (k == 4)
            return 1;
        else if (k == 5 || k == 6)
            return 2;
        else if (k == 7)
            return 3;
        else
            return 6;
    }

    int tools1(int k)
    {
        if (k == 1)
            return 4;
        else if (k == 2 || k == 7 || k == 8)
            return 1;
        else if (k == 3 || k == 4 || k == 6)
            return 3;
        else
            return 2;
    }

    int tools3(char[] play, int m)
    {
        //checks and allots position for computer to win
        int z = win(play, m);
        if (z != -1)
            return z;
        //checks for opponent win and stops it
        z = move2(play, m);
        if (z != -1)
            return z;
        //calls for the random function to allot position at random as no pattern is present
        z = Random(play);
        return z;
    }

    int move1(char[] play, int n)
    {
        if (play[4] == ' ' && n == 2)
        {
            i++;
            return 4;
        }
        else if (n == 1 || play[4] != ' ')
        {
            i++;
            return 2;
        }
        return 2;
    }

    int win(char[] play, int n)
    {
        //this check for 0 in line to win the game #Computer Move 
        char ch; //allots X and O as required
        if (n == 1)
            ch = 'X';
        else
            ch = 'O';
        for (int k = 1; k <= 8; k++)
        {
            int x = tools(k);
            int c = tools1(k);
            int sum = 0;
            int sum1 = 0;
            int y = 0;
            int f = 0;
            while (f != 3)
            {
                sum += x;
                if (play[x] == ch)
                {
                    sum1 += x;
                    y++;
                }
                f++;
                x += c;
            }
            sum1 = sum - sum1;
            if (y == 2 && play[sum1] == ' ')
            {
                return sum1;
            }
        }
        return -1;
    }

    int move2(char[] play, int n)
    {
        //this checks for the X in line to prevent player from winning the game
        char ch; //allots X and O as required
        if (n == 2)
            ch = 'X';
        else
            ch = 'O';
        for (int k = 1; k <= 8; k++)
        {
            int x = tools(k);
            int c = tools1(k);
            int sum = 0;
            int sum1 = 0;
            int y = 0;
            int f = 0;
            while (f != 3)
            {
                sum += x;
                if (play[x] == ch)
                {
                    sum1 += x;
                    y++;
                }
                f++;
                x += c;
            }
            sum1 = sum - sum1;
            if (y == 2 && play[sum1] == ' ')
            {
                return sum1;
            }
        }
        return -1;
    }

    int Random(char[] play)
    {
        int b = 0;
        int[] rand = new int[9];
        for (int z = 0; z < 9; z++)
            rand[z] = -1; //-1 is used as filler
        b = 0;
        for (int i = 0; i < 9; i++)
        {
            if (play[i] == ' ')
            {
                rand[b] = i;
                b++;
            }
        }
        int j =  new System.Random().Next(1,b+1);
        i++;
        return (rand[j - 1]);
    }

    public int input(char[] play, int n, int x, int n1)
    {
        if (n == 2)
            return second(play, n, n1);
        else
            return first(play, n, x, n1);
    }

    int first(char[] play, int m, int x, int n1)
    {
        if (n1 == 1)
            return Random(play);
        else if (n1 == 2)
        {
            int j = new System.Random().Next(1, 5);
            if (i != 1)
                return Random(play);
        }
        else if (n1 == 3)
        {
            int j = new System.Random().Next(1, 5);
            if (i == 1)
                return Random(play);
        }
        if (i == 0)//assigning the first default position top corner
            return move1(play, m);
        else if (i > 1 && n == 2)
            return tools3(play, m);
        else if (play[4] == ' ' || n == 1)
        {
            //if player doesn't use center spot to give a move then a confirm win
            n = 1;
            i++;
            return fwin1(play, x);
        }
        else if (play[4] != ' ')
        {
            //if player uses center spot and gives a move
            n = 2;
            i++;
            return 6;
        }
        return 0;
    }

    int fwin1(char[] play, int x)
    {
        if (i == 2)
        {
            //the while loop checks for the position where O is given 
            while (play[a] != 'O')
                a++;
            //then checks if O is present there or not and returns value accordingly
            if (a == 0 || a == 1 || a == 7)
                return 8;
            else
                return 0;
        }
        else if (i == 3)
        {
            n = 2;
            if (a == 0 || a == 1)
            {
                if (x == 5)
                    return 6;
                else
                    return 5;
                //win already(else case) 
            }
            else if (a == 3 || a == 6)
            {
                if (x == 1)
                    return 8;
                else
                    return 1;
                //win already(else case) 
            }
            else if (a == 5 || a == 8)
            {
                //for a=3and 6 and a=8&5 they are same formation
                if (x == 1)
                    return 6;
                else
                    return 1;
                //win already(else case) 
            }
            else
            {
                //if a=7
                if (x == 5)
                    return 0;
                else
                    return 5;
            }
        }
        return 0;
    }

    int second(char[] play, int n, int n1)
    {
        if (n1 == 1)
            return Random(play);
        else if (n1 == 2)
        {
            int j = new System.Random().Next(1, 5); ;
            if (i != 1)
                return Random(play);
        }
        else if (n1 == 3)
        {
            int j = new System.Random().Next(1, 5); 
            if (i == 1)
                return Random(play);
        }
        if (i == 0)//CHECKING FOR WINNING CASE
            return move1(play, n);
        else if (i == 1 && play[4] == 'O')//STOPPING THE WINNING CASE
        {
            if (play[0] == 'X' && play[8] == 'X')
            {
                i++;
                return 3;
            }
            else if (play[2] == 'X' && play[6] == 'X')
            {
                i++;
                return 3;
            }
            else if (play[1] == 'X' && play[7] == 'X')
            {
                i++;
                return 0;
            }
            else if (play[3] == 'X' && play[5] == 'X')
            {
                i++;
                return 0;
            }
        }
        //checks and allots position for computer to win
        int z = win(play, n);
        if (z != -1)
            return z;
        //checks for opponent win and stops it
        z = move2(play, n);
        if (z != -1)
            return z;
        //calls for the random function to allot position at random as no pattern is present
        z = Random(play);
        return z;
    }
}
public class TTTAI1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
