namespace App.Scripts.Libs.Patterns.StateMachine.State
{
    
    public interface ITickable
    {
        public void Tick(float deltaTime);
    }
}