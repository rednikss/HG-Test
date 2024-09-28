using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.Default;
using App.Scripts.Game.Entity.InputProvider.FollowTarget;
using App.Scripts.Game.Entity.Movement;
using App.Scripts.Game.Entity.Movement.Config;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class EntityInstaller : MonoInstaller
    {
        [SerializeField] private ConfigEntity _playerConfig;
        [SerializeField] private ConfigEntity _enemyConfig;
        
        [SerializeField] private EntityBase _playerEntity;
        [SerializeField] private EntityBase[] _enemyEntities;
        
        public override void InstallBindings(ServiceContainer container)
        {
            _playerEntity.Construct(_playerConfig, 
                new DefaultInputProvider());

            var timer = container.GetService<Timer>();
            
            foreach (var entity in _enemyEntities)
            {
                entity.Construct(_enemyConfig, 
                    new FollowTargetInputProvider(_playerEntity.transform, entity.transform,
                        timer));
            }
        }
    }
}