using System;

public class PlayerLives
{
    public int Lives { get; set; }

    public void LoseLife()
    {
        if (Lives > 0)
        {
            Lives--;
        }
    }

    public void GainLife()
    {
        if (Lives < 3)
        {
            Lives++;
        }
    }

    public PlayerLives(int lives = 3)
    {
        Lives = lives;
    }
}