using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;

namespace App.Scripts.Game.Mechanics.Shooting.Bullet.Pool
{
    public class BulletPool : MonoBehaviourPool<Bullet>
    {
        private Timer _timer;
        public void Construct(Timer timer)
        {
            _timer = timer;
        }
        
        protected override Bullet Create()
        {
            var bullet = base.Create();
            bullet.Construct(this, _timer);
            
            return bullet;
        }
    }
}