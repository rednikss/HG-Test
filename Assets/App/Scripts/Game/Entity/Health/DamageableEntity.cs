using UnityEngine;

namespace App.Scripts.Game.Entity.Health
{
    public class DamageableEntity : MonoBehaviour, IDamageable
    {
        private int _health;
        
        public void Construct(int health)
        {
            _health = health;
        }
        
        public void TakeDamage()
        {
            if (--_health > 0) return;
            
            //Action?.Invoke();
        }
    }
}