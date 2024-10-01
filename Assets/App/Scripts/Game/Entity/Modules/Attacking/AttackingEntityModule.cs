using App.Scripts.Game.Entity.InputProvider.Attack;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Libs.Patterns.StateMachine.State;
using UnityEngine;

namespace App.Scripts.Game.Entity.Modules.Attacking
{
    public class AttackingEntityModule : ITickable
    {
        private readonly Transform _weaponPivotTransform;
        
        private readonly IAttackInputProvider _attackInputProvider;
        
        private WeaponBehaviour _currentWeapon;
        
        public AttackingEntityModule(Transform weaponPivotTransform, 
            IAttackInputProvider attackInputProvider)
        {
            _weaponPivotTransform = weaponPivotTransform;
            _attackInputProvider = attackInputProvider;
        }
        
        public void Tick(float deltaTime)
        {
            if (_attackInputProvider.IsAttacking()) Attack();
        }

        private void Attack()
        {
            _currentWeapon.Attack();
        }
        
        public void SetWeapon(WeaponBehaviour newWeapon)
        {
            if (_currentWeapon != null)
            {
                Object.Destroy(_currentWeapon.gameObject);
            }

            _currentWeapon = newWeapon;
            newWeapon.SetPivot(_weaponPivotTransform);
        }
    }
}