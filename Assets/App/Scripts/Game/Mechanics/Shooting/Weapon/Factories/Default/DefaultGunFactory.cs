using App.Scripts.Game.Mechanics.Shooting.Weapon.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Default;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Factories.Default
{
    public class DefaultGunFactory : IFactory<Gun.Gun>
    {
        private readonly ConfigWeapon _weaponConfig;

        private readonly IObjectPool<Bullet.Bullet> _bulletPool;

        private readonly Timer _timer;

        public DefaultGunFactory(ConfigWeapon weaponConfig, IObjectPool<Bullet.Bullet> bulletPool, Timer timer)
        {
            _weaponConfig = weaponConfig;
            _bulletPool = bulletPool;
            _timer = timer;
        }

        public Gun.Gun Create()
        {
            var weapon = Object.Instantiate(_weaponConfig.Prefab);

            var gunshotController = new DefaultGunshotController(_weaponConfig.Gunshot, _bulletPool);
                
            weapon.Construct(_weaponConfig.Gun, gunshotController, _timer);

            return weapon;
        }
    }
}