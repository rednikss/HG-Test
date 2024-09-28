using App.Scripts.Game.Entity.Health.Config;

namespace App.Scripts.Game.Entity.Health
{
    public class HealthController
    {
        private readonly ConfigHealth _healthConfig;

        private readonly IDamageable _damageableObject;
        
        private float _currentHealth;
        
        public HealthController(ConfigHealth healthConfig, IDamageable damageableObject)
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