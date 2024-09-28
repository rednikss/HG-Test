namespace App.Scripts.Game.Entity.Movement
{
    public interface ITickable
    {
        public void Tick(float deltaTime);
    }
}