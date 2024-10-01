namespace App.Scripts.Game.Entity.Modules.Health
{
    public interface IDamageable
    {
        public void TakeDamage(float damage);

        public void Kill();
    }
}