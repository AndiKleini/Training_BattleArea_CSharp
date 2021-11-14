namespace BattleArena.ScreamObsever
{
    public interface IDamageCausedObserver
    {
        void NotifyDamage(int hitCount);
    }
}
