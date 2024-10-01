using App.Scripts.Game.States.Play;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable;
using App.Scripts.Libs.Patterns.StateMachine;
using UnityEngine;

namespace App.Scripts.Infrastructure.Game_Scene.Starter
{
    public class GameSceneStarter : MonoInitializable
    {
        [SerializeField] private GameStateMachine _stateMachine;
        
        public override void Init()
        {
            _stateMachine.ChangeState<PlayState>();
        }
    }
}