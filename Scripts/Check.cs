using System;
public class Check 
{
    public char check(char[] play)
    {
        int i = 0;
        // Check for vertical column
        while (i < 3)
        {
            if (play[i] == play[i + 3] && play[i] == play[i + 6] && play[i] != ' ')
                return play[i];
            i++;
        }
        i = 0;
        // Check for horizontal row
        while (i < 7)
        {
            if (play[i] == play[i + 1] && play[i] == play[i + 2] && play[i] != ' ')
                return play[i];
            i += 3;
        }
        i = 0;
        // Check for diagonal checking
        int d = 4;
        while (d != 1)
        {
            if (play[i] == play[i + d] && play[i] == play[i + 2 * d])
                return play[i];
            i += 2;
            d /= 2;
        }
        return 'n';
    }
}
