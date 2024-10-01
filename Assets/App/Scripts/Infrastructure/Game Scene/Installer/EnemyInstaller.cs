using System.Collections.Generic;
using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.Attack.Periodic;
using App.Scripts.Game.Entity.InputProvider.Move.FollowTarget;
using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Config.List;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Factories.Default;
using App.Scripts.Game.Mechanics.Shooting.WeaponChanger.Enemy;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Game_Scene.Installer
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ConfigEntity _enemyConfig;

        [SerializeField] private ConfigWeaponList _enemyWeaponsConfig;
        
        [SerializeField] private Transform _targetTransform;
        
        [SerializeField] private EntityBase[] _enemyEntities;

        [SerializeField] private float _attackPeriod;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var timer = container.GetService<Timer>();
            var pool = container.GetService<IObjectPool<Bullet>>();
            
            foreach (var entity in _enemyEntities)
            {
                entity.Construct(_enemyConfig, 
                    new FollowTargetMoveInputProvider(_targetTransform.transform, entity.transform),
                    new PeriodicAttackInputProvider(timer, _attackPeriod),
                    new EnemyWeaponChanger(BuildWeaponFactoryList(pool, timer), entity));
            }
        }

        private List<IFactory<WeaponBehaviour>> BuildWeaponFactoryList(IObjectPool<Bullet> pool, Timer timer)
        {
            var list = new List<IFactory<WeaponBehaviour>>();

            foreach (var weaponConfig in _enemyWeaponsConfig.List)
            {
                list.Add(new DefaultGunFactory(weaponConfig, pool, timer));
            }
            
            return list;
        }
    }
}