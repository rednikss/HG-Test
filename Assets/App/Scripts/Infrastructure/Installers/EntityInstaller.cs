using App.Scripts.Game.Entity.Movement;
using App.Scripts.Game.Entity.Movement.Config;
using App.Scripts.Game.InputProvider.Default;
using App.Scripts.Game.InputProvider.FollowTarget;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class EntityInstaller : MonoInstaller
    {
        [SerializeField] private ConfigMovement _playerMovementConfig;
        [SerializeField] private MovingEntity _playerEntity;
        
        [SerializeField] private ConfigMovement _enemyMovementConfig;
        [SerializeField] private MovingEntity[] _enemyEntities;
        
        public override void InstallBindings(ServiceContainer container)
        {
            _playerEntity.Construct(new DefaultInputProvider(), 
                _playerMovementConfig.Settings);

            foreach (var entity in _enemyEntities)
            {
                entity.Construct(new FollowTargetInputProvider(_playerEntity.transform, entity.transform),
                    _enemyMovementConfig.Settings);
            }
        }
    }
}