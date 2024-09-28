namespace App.Scripts.Game.Entity.Health
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);

        public void Kill();
    }
}