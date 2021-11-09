using BattleArena.Items.OldVersion;
using BattleArena.Pawn;

namespace BattleArena.Items
{
    public class LongBowAdapter : IEquipment
    {
        private LongBow longBowLegacyInstance;

        public LongBowAdapter(LongBow longBowLegacyInstance)
        {
            this.longBowLegacyInstance = longBowLegacyInstance;
        }

        public void Use(Hero other)
        {
                int damage = this.longBowLegacyInstance.looseAndHit();
                other.ReduceHealth(damage);
        }
    }
}
