using BattleArena.Items.OldVersion;
using System;

namespace BattleArena.Items
{
    public static class EquipmentFactoryMethod
    {
        public static IEquipment GetEquipment(EquipmentType equipment, Random randomNumberGenerator) => equipment switch
        {
            EquipmentType.LongBow => new LongBowAdapter(new LongBow(randomNumberGenerator)),
            EquipmentType.CynradBow => new CynradBow(randomNumberGenerator),
            _ => throw new Exception("Not Supported"),
        };
    }
}
