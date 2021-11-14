using BattleArena.Items;
using BattleArena.Pawn;
using BattleArena.ScreamObsever;
using System;

namespace BattleArena
{
    class Program
    {
        static void Main(string[] args)
        {
            UserIO userinteraction = new UserIO();

            Random randomNumberGenerator = new Random();
            Hero hero1 = new Hero("Player 1", new LongBowAdapter(new Items.OldVersion.LongBow(randomNumberGenerator)));
            hero1.SubscribeTo(new PainfulScreamObserver());
            Hero hero2 = new Hero("Player 2", new CynradBow(randomNumberGenerator));
            hero2.SubscribeTo(new PainfulScreamObserver());
            Hero[] playerList = { hero1, hero2 };

            bool run = true;

            while (run)
            {
                userinteraction.ClearScreen();
                userinteraction.PrintPlayerInformation(playerList);

                foreach (Hero currentHero in playerList)
                {

                    bool action = false;
                    do
                    {
                        int userinput = -1;
                        do
                        {
                            userinteraction.PrintFightMenu(currentHero.Name);
                            userinput = userinteraction.GetUserIput();
                        } while (userinput < 0 || userinput > 5);

                        switch (userinput)
                        {
                            case 0:
                                // exit game
                                run = false;
                                userinteraction.ExitGame();
                                return ;
                            case 1:
                                if (currentHero.Name == "Player 1")
                                {
                                    action = currentHero.Action(playerList[1]);
                                }
                                else
                                {
                                    action = currentHero.Action(playerList[0]);
                                }
                                break;

                            case 2:
                                action = currentHero.AddLeprechaun();
                                break;
                            case 3:
                                action = currentHero.AddTinyGoblin(randomNumberGenerator);
                                break;
                            case 4:
                                action = currentHero.AddMediumGoblin(randomNumberGenerator);
                                break;
                            case 5:
                                action = currentHero.AddBigGoblin(randomNumberGenerator);
                                break;

                            default:
                                break;
                        }

                        if (!action)
                        {
                            userinteraction.ClearScreen();
                            userinteraction.PrintPlayerInformation(playerList);
                            Console.WriteLine("\nNot enought money");
                        }
                    } while (!action);

                    currentHero.UpdateCoins();

                    if (currentHero.Name == "Player 1")
                    {
                        currentHero.UseGoblins(playerList[1]);
                    }
                    else
                    {
                        currentHero.UseGoblins(playerList[0]);
                    }
                }

                // end condition
                if (playerList[0].Health <= 0)
                {
                    userinteraction.EndGame(playerList[0].Name);
                    run = false;
                }
                else if (playerList[1].Health <= 0)
                {
                    userinteraction.EndGame(playerList[1].Name);
                    run = false;
                }
            }
        }
    }
}
