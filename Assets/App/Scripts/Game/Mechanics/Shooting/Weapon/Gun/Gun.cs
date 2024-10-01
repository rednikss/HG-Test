using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun
{
    public class Gun : WeaponBehaviour
    {
        [SerializeField] private Transform[] _spawnBulletPoints;

        private ConfigGun _gunConfig;
        
        private IGunshotController _gunshotController;

        private Timer _timer;
        
        private int _currentRounds;

        private float _lastShotTime;
        
        public void Construct(ConfigGun gunConfig, IGunshotController gunshotController, Timer timer)
        {
            _gunConfig = gunConfig;
            _gunshotController = gunshotController;
            _timer = timer;
            _currentRounds = _gunConfig.Rounds;
        }
        
        public override void Attack()
        {
            if (!IsPossibleToShoot()) return;

            _lastShotTime = _timer.GetCurrentTime();
            
            if (--_currentRounds == 0)
            {
                _timer.AddDelayedEvent(_gunConfig.ReloadTime, ResetRounds);
            }
            
            _gunshotController.CreateGunshot(_spawnBulletPoints);
        }

        private bool IsPossibleToShoot()
        {
            var shotDelta = _timer.GetCurrentTime() - _lastShotTime;
            
            return _currentRounds > 0 && shotDelta >= (1f / _gunConfig.Rapidity);
        }

        private void ResetRounds()
        {
            _currentRounds = _gunConfig.Rounds;
            _lastShotTime = -_gunConfig.Rapidity;
        }
    }
}