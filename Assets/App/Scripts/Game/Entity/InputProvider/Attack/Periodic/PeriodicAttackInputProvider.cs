using App.Scripts.Libs.Utilities.Timer;

namespace App.Scripts.Game.Entity.InputProvider.Attack.Periodic
{
    public class PeriodicAttackInputProvider : IAttackInputProvider
    {
        private readonly Timer _timer;

        private readonly float _period;
        
        private float _lastTime;

        public PeriodicAttackInputProvider(Timer timer, float period)
        {
            _timer = timer;
            _lastTime = _timer.GetCurrentTime();
            _period = period;
        }

        public bool IsAttacking()
        {
            var newTime = _timer.GetCurrentTime();

            if (newTime - _lastTime < _period) return false;
            
            _lastTime = newTime;
            return true;
        }
    }
}