using App.Scripts.Game.InputProvider;
using App.Scripts.Game.Player.Movement;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _playerMovement;
        
        public override void InstallBindings(ServiceContainer container)
        {
            
            _playerMovement.Construct(new DefaultPlayerInputProvider());
        }
    }
}