using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.Default;
using App.Scripts.Game.Entity.InputProvider.FollowTarget;
using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Default;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private ConfigEntity _playerConfig;
        
        [SerializeField] private ConfigWeapons _playerWeaponsConfig;
        
        [SerializeField] private EntityBase _playerEntity;

        public override void InstallBindings(ServiceContainer container)
        {
            var weaponConfig = _playerWeaponsConfig.list[0];
            
            var playerWeapon = Instantiate(weaponConfig.Prefab);

            var gunshotController = new DefaultGunshotController(weaponConfig.Gunshot,
                container.GetService<IObjectPool<Bullet>>());
            
            playerWeapon.Construct(gunshotController,
                container.GetService<Timer>());
            
            _playerEntity.Construct(_playerConfig, 
                new PlayerInputProvider(), 
                playerWeapon);
        }
    }
}