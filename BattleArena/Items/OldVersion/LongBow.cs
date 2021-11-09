using System;

namespace BattleArena.Items.OldVersion
{
    public class LongBow
    {
        private Random randomNumberGenerator;
        private const int strength = 3;

        public LongBow(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public int looseAndHit()
        {
            int probabilityOfHit = this.haveDayLight() ? 5 : 2;
            return randomNumberGenerator.Next(10) < probabilityOfHit ? strength : 0;
        }

        private bool haveDayLight()
        {
            int hour = DateTime.Now.Hour;
            return hour > 6 && hour < 20;
        }
    }
}
