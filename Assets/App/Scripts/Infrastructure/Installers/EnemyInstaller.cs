using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.FollowTarget;
using App.Scripts.Game.Mechanics.Shooting.Bullet;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Default;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ConfigEntity _enemyConfig;

        [SerializeField] private ConfigWeapons _enemyWeaponsConfig;
        
        [SerializeField] private Transform _targetTransform;
        
        [SerializeField] private EntityBase[] _enemyEntities;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var timer = container.GetService<Timer>();
            var pool = container.GetService<IObjectPool<Bullet>>();
            
            foreach (var entity in _enemyEntities)
            {
                var weaponID = Random.Range(0, _enemyWeaponsConfig.list.Length);
                var weaponConfig = _enemyWeaponsConfig.list[weaponID];

                var enemyWeapon = Instantiate(weaponConfig.Prefab);

                var gunshotController = new DefaultGunshotController(weaponConfig.Gunshot, pool);
                
                enemyWeapon.Construct(gunshotController,
                    timer);


                entity.Construct(_enemyConfig, 
                    new FollowTargetInputProvider(_targetTransform.transform, entity.transform,
                        timer),
                    enemyWeapon);
            }
        }
    }
}