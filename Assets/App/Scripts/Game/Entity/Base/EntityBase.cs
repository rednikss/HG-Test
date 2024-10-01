using System.Collections.Generic;
using App.Scripts.Game.Entity.Base.Config;
using App.Scripts.Game.Entity.InputProvider.Attack;
using App.Scripts.Game.Entity.InputProvider.Move;
using App.Scripts.Game.Entity.Modules.Attacking;
using App.Scripts.Game.Entity.Modules.Health;
using App.Scripts.Game.Entity.Modules.Movement;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Game.Mechanics.Shooting.WeaponChanger;
using App.Scripts.Libs.Patterns.StateMachine.State;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base
{
    public class EntityBase : MonoBehaviour, ITickable, IDamageable, IArmed
    {
        [SerializeField] private CharacterController _characterController;
        
        [SerializeField] private Transform _entityRotatableTransform;

        [SerializeField] private Transform _weaponPivotTransform;
        
        private readonly List<ITickable> _tickables = new();

        private DamageableEntityModule _damageableEntityModule;

        private AttackingEntityModule _attackingEntityModule;

        public void Construct(ConfigEntity entityConfig, 
            IMoveInputProvider moveInputProvider, 
            IAttackInputProvider attackInputProvider, 
            WeaponChanger weaponChanger)
        {
            _damageableEntityModule = new DamageableEntityModule(entityConfig.Health, this);
            
            var movement = new MovingEntityModule(
                entityConfig.Movement, 
                moveInputProvider,
                _characterController, 
                _entityRotatableTransform);

            _attackingEntityModule = new AttackingEntityModule(_weaponPivotTransform, attackInputProvider);
            
            weaponChanger.Init();
            _tickables.Add(weaponChanger);
            _tickables.Add(movement);
            _tickables.Add(_attackingEntityModule);
        }

        public void Tick(float deltaTime)
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(deltaTime);
            }
        }

        public void TakeDamage(float damage)
        {
            _damageableEntityModule.RemoveHealth(damage);
        }

        public void Kill()
        {
            _tickables.Clear();
            gameObject.SetActive(false);
        }

        public void SetWeapon(WeaponBehaviour weaponBehaviour)
        {
            _attackingEntityModule.SetWeapon(weaponBehaviour);
        }
    }
}