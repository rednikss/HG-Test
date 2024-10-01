using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.Patterns.StateMachine.State
{
    public abstract class GameState : ITickable
    {
        protected readonly GameStateMachine StateMachine;

        private readonly IEnumerable<ITickable> _tickables;

        protected GameState(GameStateMachine machine, IEnumerable<ITickable> tickables)
        {
            StateMachine = machine;
            _tickables = tickables;
        }
        
        public virtual Task OnEnterState() => Task.CompletedTask;
        
        public virtual void Tick(float deltaTime)
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(Time.deltaTime);
            }
        }

        public virtual Task OnExitState() => Task.CompletedTask;
    }
}