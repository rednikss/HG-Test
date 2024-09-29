using App.Scripts.Game.Entity.Health;
using App.Scripts.Game.Mechanics.Shooting.Bullet.Config;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private ConfigBullet _bulletConfig;
        
        private IObjectPool<Bullet> _pool;

        private Timer _timer;
        
        public void Construct(IObjectPool<Bullet> pool, Timer timer)
        {
            _pool = pool;
            _timer = timer;
        }

        public void Fly(Vector3 direction, ConfigBullet bulletConfig)
        {
            _bulletConfig = bulletConfig;
            
            _rigidbody.velocity = direction.normalized * _bulletConfig.Speed;

            var lifeTime = _bulletConfig.Range / _bulletConfig.Speed;
            _timer.AddDelayedEvent(lifeTime, Destroy);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_bulletConfig.Damage);
            }

            Destroy();
        }

        private void Destroy()
        {
            _pool.ReturnObject(this);
        }
    }
}