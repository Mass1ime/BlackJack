public class Program
{
    public int[] cardP = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] cardD = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public string[] mast = { "♠;", "♥", "♦", "♣" };
    public int[] mastP = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] mastD = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int deckP = 1;
    public int deckD = 1;
    int pScore = 0;
    int dScore = 0;
    bool pasP = false;
    int acesP = 0;
    int acesD = 0;
    int gm = 1;

    public static void Main()
    {
        Console.WriteLine("Powered by Mass1ime");
        Program foo = new Program();
        foo.Oger();
    }
    public void Oger()
    {
        Start();
        while(gm == 1)
        {
            Console.WriteLine("Continue? (y/n)");
            string game = Console.ReadLine();
            if (game == "y" || game == "Y")
                {
                    Oger();
                }
            else if (game == "n" || game == "N")
            {
                gm = 0;
                break;
            }
            else
            {
                Console.WriteLine("Fuck you => Y and N");
            }
        }
    }
    public void Start()
    {
        Random random = new Random();
        cardP[deckP] = random.Next(2, 14);
        mastP[deckP] = random.Next(0, 3);
        Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastP[deckP]]);
        calc(deckP, 1);
        deckP++;
        cardP[deckP] = random.Next(2, 14);
        mastP[deckP] = random.Next(0, 3);
        Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastP[deckP]]);
        calc(deckP, 1);
        if (21 != pScore)
        {
            cardD[deckD] = random.Next(2, 14);
            mastD[deckD] = random.Next(0, 3);
            Console.WriteLine("Diller card: " + cardD[deckD].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastD[deckD]]);
            calc(deckD, 2);
            deckD++;
            cardD[deckD] = random.Next(2, 14);
            mastD[deckP] = random.Next(0, 3);
            calc(deckD, 2);
        }
        while (pScore < 21 || !pasP)
        {
            Console.WriteLine("Do you want to draw a card? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y"|| answer == "Y")
            {
                deckP++;
                cardP[deckP] = random.Next(2, 14);
                mastP[deckP] = random.Next(0, 3);
                Console.WriteLine("You card: " + cardP[deckP].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastP[deckP]]);
                calc(deckP, 1);
                if (pScore > 21)
                {
                    break;
                }
            }
            else if (answer == "n" || answer == "N")
            {
                pasP = true;
                break;
            }
            else
            {
                Console.WriteLine("Fuck you => Y and N");
            }
        }
        Console.WriteLine("Diller card: " + cardD[deckD].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastD[deckD]]);
        if (pScore < 21)
        {
            while (dScore < 17)
            {
                deckD++;
                cardD[deckD] = random.Next(2, 14);
                mastD[deckD] = random.Next(0, 3);
                Console.WriteLine("Diller card: " + cardD[deckD].ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A") + mast[mastD[deckD]]);
                calc(deckD, 2);
            }
        }
        string ds = "";
        if (pScore > 21 || pScore < dScore && dScore <= 21)
        {
            Console.WriteLine("You lose!");
            if (pScore < 21)
            {
                int tempd;
                for (int i = 1; i <= deckD; i++)
                {
                    for (int j = i + 1; j <= deckD; j++)
                    {
                        if (cardD[i] > cardD[j])
                        {
                            tempd = cardD[i];
                            cardD[i] = cardD[j];
                            cardD[j] = tempd;
                        }
                    }
                }
                for (int i = 1; i <= deckD; i++)
                {
                    ds += "_" + cardD[i].ToString();
                }
                stats(ds, 2);
            }
        }
        else if (dScore > 21 || pScore > dScore && pScore <= 21 || deckP == 2 && pScore == 21)
        {
            Console.WriteLine("You win!");
            int tempp;
            for (int i = 1; i <= deckP; i++)
            {
                for (int j = i + 1; j <= deckP; j++)
                {
                    if (cardP[i] > cardP[j])
                    {
                        tempp = cardP[i];
                        cardP[i] = cardP[j];
                        cardP[j] = tempp;
                    }
                }
            }
            for (int i = 1; i <= deckP; i++)
            {
                ds += "_" + cardP[i].ToString();
            }
            stats(ds, 1);
        }
        else if (pScore == dScore)
        {
            Console.WriteLine("It's a tie!");
        }
        else 
        {
            Console.WriteLine("Error Game");
        }
        Console.WriteLine("You Score: " + pScore + ". Diler Score: " + dScore);
        deckP = 1;
        deckD = 1;
        pScore = 0;
        dScore = 0;
        acesP = 0;
        acesD = 0;
    }
    public void calc(int id, int cid)
    {
        if (cid == 1)
        {
            if (cardP[id] == 11 || cardP[id] == 12 || cardP[id] == 13)
            {
                pScore += 10;
            }
            else if (cardP[id] == 14)
            {
                if (pScore + 11 <= 21)
                {
                    pScore += 11;
                    acesP++;
                }
                else if (pScore + 11 > 21)
                {
                    if(acesP == 0)
                    {
                        pScore += 1;
                    }
                    else if (acesP > 0 && pScore + 1 <= 21)
                    {
                        pScore += 1;
                    }
                    else if (acesP > 0 && pScore + 1 > 21)
                    {
                        acesP--;
                        pScore -= 9;
                    }
                }
            }
            else
            {
                pScore += cardP[id];
            }
            if (id >= 2)
            {
                Console.WriteLine("You Score: " + pScore);
            }
        }
        else if (cid == 2)
        {
            if (cardD[id] == 11 || cardD[id] == 12 || cardD[id] == 13)
            {
                dScore += 10;
            }
            else if (cardD[id] == 14)
            {
                if (dScore + 11 <= 21)
                {
                    dScore += 11;
                    acesD++;
                }
                else if (dScore + 11 > 21)
                {
                    if (acesD == 0)
                    {
                        dScore += 1;
                    }
                    else if (acesD > 0 && dScore + 1 <= 21)
                    {
                        dScore += 1;
                    }
                    else if (acesD > 0 && dScore + 1 > 21)
                    {
                        acesD--;
                        dScore -= 9;
                    }
                }
            }
            else
            {
                dScore += cardD[id];
            }
        }
    }
    public void stats(string name, int cid)
    {
        if (cid == 1)
        {
            var InI = new INI.IniFile("Player.ini");
            try
            {
                var nInI = Int32.Parse(InI.Read(name, "BlackJack"));
                nInI++;
                InI.Write(name, nInI.ToString(), "BlackJack");
            }
            catch
            {
                InI.Write(name, "1", "BlackJack");
            }
        }
        else if (cid == 2)
        {
            var InI = new INI.IniFile("Diler.ini");
            try
            {
                var nInI = Int32.Parse(InI.Read(name, "BlackJack"));
                nInI++;
                InI.Write(name, nInI.ToString(), "BlackJack");
            }
            catch
            {
                InI.Write(name, "1", "BlackJack");
            }
        }
    }
}
