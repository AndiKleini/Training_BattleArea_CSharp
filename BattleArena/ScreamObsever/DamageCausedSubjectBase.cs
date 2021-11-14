using System.Collections.Generic;

namespace BattleArena.ScreamObsever
{
    public abstract class DamageCausedSubjectBase
    {
        private List<IDamageCausedObserver> observers = new List<IDamageCausedObserver>();

        protected void NotifyHit(int hitCount)
        {
            this.observers.ForEach(s=>s.NotifyDamage(hitCount));
        }

        public void SubscribeTo(IDamageCausedObserver notifyMeWhenDamageCaused)
        {
            this.observers.Add(notifyMeWhenDamageCaused);
        }

       
        public void UnsubscribeFrom(IDamageCausedObserver notifyMeWhenDamageCaused)
        {
            this.observers.Remove(notifyMeWhenDamageCaused);
        }
    }
}
