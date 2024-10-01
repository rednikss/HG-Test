using System.Collections.Generic;
using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.States.Play;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.StateMachine;
using App.Scripts.Libs.Patterns.StateMachine.State;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Game_Scene.Installer
{
    public class StateMachineInstaller : MonoInstaller
    {
        [SerializeField] private GameStateMachine _stateMachine;

        [SerializeField] private EntityBase[] _entities;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var timer = container.GetService<Timer>();

            foreach (var entity in _entities)
            {
                timer.AddTickable(entity);
            }
            
            List<ITickable> tickables = new()
            {
                timer
            };
            
            var playState = new PlayState(_stateMachine, tickables);
            
            _stateMachine.AddState(playState);
        }
    }
}