using App.Scripts.Game.Entity.Base;
using App.Scripts.Game.Entity.InputProvider;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using UnityEngine;

namespace App.Scripts.Game.Entity.Attacking
{
    public class AttackingEntity : ITickable
    {
        private readonly Transform _weaponPivotTransform;
        
        private readonly IInputProvider _inputProvider;
        
        private WeaponBehaviour _currentWeapon;
        
        public AttackingEntity(Transform weaponPivotTransform, IInputProvider inputProvider, WeaponBehaviour weapon)
        {
            _weaponPivotTransform = weaponPivotTransform;
            _inputProvider = inputProvider;
            SetWeapon(weapon);
        }
        
        public void Tick(float deltaTime)
        {
            if (_inputProvider.IsAttacking()) Attack();
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