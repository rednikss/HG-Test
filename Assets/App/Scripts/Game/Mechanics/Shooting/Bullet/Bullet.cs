using App.Scripts.Game.Entity.Modules.Health;
using App.Scripts.Game.Mechanics.Shooting.Bullet.Config;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Patterns.StateMachine.State;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Bullet
{
    public class Bullet : MonoBehaviour, ITickable
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private ConfigBullet _bulletConfig;
        
        private IObjectPool<Bullet> _pool;

        private Timer _timer;

        private Vector3 _currentDirection;
        
        public void Construct(IObjectPool<Bullet> pool, Timer timer)
        {
            _pool = pool;
            _timer = timer;
        }

        public void Fly(Vector3 direction, ConfigBullet bulletConfig)
        {
            _bulletConfig = bulletConfig;
            _currentDirection = direction.normalized;
            
            var lifeTime = _bulletConfig.Range / _bulletConfig.Speed;
            
            _timer.AddTickable(this);
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
            _timer.RemoveTickable(this);
            _pool.ReturnObject(this);
        }

        public void Tick(float deltaTime)
        {
            _rigidbody.MovePosition(_rigidbody.position + _currentDirection * (deltaTime * _bulletConfig.Speed));
        }
    }
}