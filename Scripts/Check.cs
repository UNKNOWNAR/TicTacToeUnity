using System;
public class Check
{
    // "X" - 0,"O" - 1,No Result - 69
    char c;
    int z = 0;
    public int check(char[] play)
    {
        int i = 0;
        // Check for vertical column
        while (i < 3)
        {
            if (play[i] == play[i + 3] && play[i] == play[i + 6] && play[i] != ' ')
            {
                c = play[i];
                z = i * 10 + 3;
                break;
            }
            i++;
        }
        i = 0;
        // Check for horizontal row
        while (i < 7)
        {
            if (play[i] == play[i + 1] && play[i] == play[i + 2] && play[i] != ' ')
            {
                z = i * 10 + 1;
                c = play[i];
                break;
            }
            i += 3;
        }
        i = 0;
        // Check for diagonal checking
        int d = 4;
        while (d != 1)
        {
            if (play[i] == play[i + d] && play[i] == play[i + 2 * d] && play[i] != ' ')
            {
                c = play[i];
                z = 10 * i + d;
                break;
            }
            i += 2;
            d /= 2;
        }
        if (c == 'X')
            return (z*10);
        else if(c =='O')
            return (z*10+1);
        return 69;
    }
}
