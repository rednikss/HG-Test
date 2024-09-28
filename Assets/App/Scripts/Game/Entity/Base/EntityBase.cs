using System.Collections.Generic;
using App.Scripts.Game.Entity.Config;
using App.Scripts.Game.Entity.Health;
using App.Scripts.Game.Entity.Movement;
using App.Scripts.Game.InputProvider;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base
{
    public class EntityBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterController _characterController;
        
        [SerializeField] private Transform _entityRotatableTransform;

        private readonly List<ITickable> _tickables = new();

        private HealthController _healthController;

        public virtual void Construct(ConfigEntity entityConfig, IInputProvider inputProvider)
        {
            _healthController = new HealthController(entityConfig.Health, this);
            
            var movement = new MovingEntity(
                entityConfig.Movement, 
                inputProvider,
                _characterController, 
                _entityRotatableTransform);
            
            _tickables.Add(movement);
        }

        private void Update()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(Time.deltaTime);
            }
        }

        public void TakeDamage(int damage)
        {
            _healthController.RemoveHealth(damage);
        }

        public virtual void Kill()
        {
            Destroy(gameObject);
        }
    }
}