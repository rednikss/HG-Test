using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Bullet.Pool;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Game_Scene.Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BulletPool _bulletPool;

        public override void InstallBindings(ServiceContainer container)
        {
            var timer = new Timer();
            _bulletPool.Construct(timer);
            
            container.SetServiceSelf(timer);
            container.SetService<IObjectPool<Bullet>, BulletPool>(_bulletPool);
        }
    }
}