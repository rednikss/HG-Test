using System.Collections.Generic;
using App.Scripts.Game.Entity.Attacking;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.Health;
using App.Scripts.Game.Entity.InputProvider;
using App.Scripts.Game.Entity.Movement;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base
{
    public class EntityBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterController _characterController;
        
        [SerializeField] private Transform _entityRotatableTransform;

        [SerializeField] private Transform _weaponPivotTransform;
        
        private readonly List<ITickable> _tickables = new();

        private HealthController _healthController;

        public void Construct(ConfigEntity entityConfig, IInputProvider inputProvider, WeaponBehaviour weapon)
        {
            _healthController = new HealthController(entityConfig.Health, this);
            
            var movement = new MovingEntity(
                entityConfig.Movement, 
                inputProvider,
                _characterController, 
                _entityRotatableTransform);

            var attack = new AttackingEntity(_weaponPivotTransform, inputProvider, weapon);
            
            _tickables.Add(movement);
            _tickables.Add(attack);
        }

        private void Update()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(Time.deltaTime);
            }
        }

        public void TakeDamage(float damage)
        {
            _healthController.RemoveHealth(damage);
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}