using System.Collections.Generic;
using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.Attack.Player;
using App.Scripts.Game.Entity.InputProvider.Move.Player;
using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Config.List;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Factories.Default;
using App.Scripts.Game.Mechanics.Shooting.WeaponChanger.Player;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Game_Scene.Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private ConfigEntity _playerConfig;
        
        [SerializeField] private ConfigWeaponList _playerWeaponsConfig;
        
        [SerializeField] private EntityBase _playerEntity;

        public override void InstallBindings(ServiceContainer container)
        {
            var timer = container.GetService<Timer>();
            var pool = container.GetService<IObjectPool<Bullet>>();

            _playerEntity.Construct(_playerConfig, 
                new PlayerMoveInputProvider(), 
                new PlayerAttackInputProvider(),
                new PlayerWeaponChanger(BuildWeaponFactoryList(pool, timer), _playerEntity));
        }
        
        
        private List<IFactory<WeaponBehaviour>> BuildWeaponFactoryList(IObjectPool<Bullet> pool, Timer timer)
        {
            var list = new List<IFactory<WeaponBehaviour>>();

            foreach (var weaponConfig in _playerWeaponsConfig.List)
            {
                list.Add(new DefaultGunFactory(weaponConfig, pool, timer));
            }
            
            return list;
        }
    }
}