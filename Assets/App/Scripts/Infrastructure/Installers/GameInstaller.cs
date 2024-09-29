using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Bullet.Pool;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BulletPool _bulletPool;
        
        public override void InstallBindings(ServiceContainer container)
        {
            _bulletPool.Construct(container.GetService<Timer>());
            
            container.SetService<IObjectPool<Bullet>, BulletPool>(_bulletPool);
        }
    }
}