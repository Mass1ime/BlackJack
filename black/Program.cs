using System;

public class Program
{
    public int[] cardP = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    public int deckP = 1;
    public int deckD = 1;
    public int[] cardD = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    int pScore = 0;
    int dScore = 0;
    bool pasP = false;

    public static void Main()
    {
        Console.WriteLine("Powered by Mass1ime");
        Program foo = new Program();
        foo.Oger();
    }
    public void Oger() 
    {
        Start();
        Console.WriteLine("Continue? (y/n)");
        string game = Console.ReadLine();
        if (game == "y")
        {
            Oger();
        }
    }
    public void Start()
    {
        Random random = new Random();
        cardP[deckP] = random.Next(2, 14);
        Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "D").Replace("12", "V").Replace("13", "K").Replace("14", "T"));
        calc(deckP, 1);
        cardD[deckD] = random.Next(2, 14);
        calc(deckD, 2);
        deckP++;
        cardP[deckP] = random.Next(2, 14);
        Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "D").Replace("12", "V").Replace("13", "K").Replace("14", "T"));
        calc(deckP, 1);
        deckD++;
        cardD[deckD] = random.Next(2, 14);
        calc(deckD, 2);

        while (pScore < 21 || !pasP)
        {
            Console.WriteLine("Do you want to draw a card? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                deckP++;
                cardP[deckP] = random.Next(2, 14);
                Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "D").Replace("12", "V").Replace("13", "K").Replace("14", "T"));
                calc(deckP, 1);
                if (pScore > 21)
                {
                    break;
                }
            }
            else
            {
                pasP = true;
                break;
            }
        }

        while (dScore < 18)
        {
            deckD++;
            cardD[deckD] = random.Next(2, 14);
            calc(deckD, 2);
        }

        if (pScore > 21)
        {
            Console.WriteLine("You lose!");
        }
        else if (dScore > 21)
        {
            Console.WriteLine("You win!");
        }
        else if (pScore > dScore)
        {
            Console.WriteLine("You win!");
        }
        else if (pScore < dScore)
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
        Console.WriteLine("You Score: " + pScore + ". Diler Score: " + dScore);
        deckP = 1;
        deckD = 1;

    }
    public void calc(int id, int cid)
    {
        if (cid == 1)
        {
            if (cardP[id] == 11 || cardP[id] == 12 || cardP[id] == 13)
            {
                cardP[id] = 10;
            }
            if (cardP[id] == 14 && pScore + 11 > 21)
            {
                cardP[id] = 1;
            }
            if (cardP[id] == 14 && pScore + 11 <= 21)
            {
                cardP[id] = 11;
            }
            pScore += cardP[id];
            if (id >= 2)
            {
                Console.WriteLine("You Score: " + pScore);
            }
        }
        else if (cid == 2)
        {
            if (cardD[id] == 11 || cardD[id] == 12 || cardD[id] == 13)
            {
                cardD[id] = 10;
            }
            if (cardD[id] == 14 && dScore + 11 > 21)
            {
                cardD[id] = 1;
            }
            if (cardD[id] == 14 && dScore + 11 <= 21)
            {
                cardD[id] = 11;
            }
            dScore += cardD[id];
        }
    }
}
