using App.Scripts.Game.Entity.InputProvider;
using App.Scripts.Game.Entity.Movement;
using UnityEngine;

namespace App.Scripts.Game.Entity.Shooting
{
    public class ShootingEntity : ITickable
    {
        private readonly Transform _weaponPivotTransform;
        
        private readonly IInputProvider _inputProvider;
        
        //private Weapon _currentWeapon;
        
        public ShootingEntity(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }
        
        public void Tick(float deltaTime)
        {
            if (_inputProvider.IsShooting()) Shoot();
        }

        private void Shoot()
        {
            
        }
        
        public void SetWeapon()
        {
            
        }
    }
}