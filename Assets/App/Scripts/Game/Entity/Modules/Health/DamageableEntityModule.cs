using App.Scripts.Game.Entity.Modules.Health.Config;

namespace App.Scripts.Game.Entity.Modules.Health
{
    public class DamageableEntityModule
    {
        private readonly ConfigHealth _healthConfig;

        private readonly IDamageable _damageableObject;
        
        private float _currentHealth;
        
        public DamageableEntityModule(ConfigHealth healthConfig, IDamageable damageableObject)
        {
            _healthConfig = healthConfig;
            
            _damageableObject = damageableObject;
            
            ResetHealth();
        }

        public void ResetHealth()
        {
            _currentHealth = _healthConfig.StartHealth;
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0) _damageableObject.Kill();
        }
    }
}