using System;

namespace BattleArena.ScreamObsever
{
    public class PainfulScreamObserver : IDamageCausedObserver
    {
        public void NotifyDamage(int hitCount)
        {
            String scream;
            if (hitCount < 2)
            {
                scream = "Autsch";
            }
            else if (hitCount < 5 && hitCount > 2)
            {
                scream = "Ahhhhh that's bad";
            }
            else
            {
                scream = "Help I need a doctor";
            }
            Console.WriteLine(scream);
        }
    }
}
