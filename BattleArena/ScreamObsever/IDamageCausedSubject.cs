namespace BattleArena.ScreamObsever
{
    public interface IDamageCausedSubject
    {
        void SubscribeTo(IDamageCausedObserver notifyMeWhenDamageCaused);
        void UnsubscribeFrom(IDamageCausedObserver notifyMeWhenDamageCaused);
    }
}
