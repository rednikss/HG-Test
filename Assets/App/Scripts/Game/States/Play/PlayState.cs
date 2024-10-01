using System.Collections.Generic;
using App.Scripts.Libs.Patterns.StateMachine;
using App.Scripts.Libs.Patterns.StateMachine.State;

namespace App.Scripts.Game.States.Play
{
    public class PlayState : GameState
    {
        public PlayState(GameStateMachine machine, IEnumerable<ITickable> tickables) : base(machine, tickables)
        {
        }
    }
}