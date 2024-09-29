using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun
{
    public class Gun : WeaponBehaviour
    {
        [SerializeField] private ConfigGun gunConfig;

        [SerializeField] private Transform[] _spawnBulletPoints;

        private IGunshotController _gunshotController;

        private Timer _timer;
        
        private int _currentRounds;

        private float _lastShotTime;
        
        public void Construct(IGunshotController gunshotController, Timer timer)
        {
            _gunshotController = gunshotController;
            _timer = timer;
            _currentRounds = gunConfig.Rounds;
        }
        
        public override void Attack()
        {
            if (!IsPossibleToShoot()) return;

            if (--_currentRounds == 0)
            {
                _timer.AddDelayedEvent(gunConfig.ReloadTime, ResetRounds);
            }
            
            _gunshotController.CreateGunshot(_spawnBulletPoints);
        }

        private bool IsPossibleToShoot()
        {
            var shotDelta = _timer.GetCurrentTime() - _lastShotTime;
            
            return _currentRounds > 0 && shotDelta >= 1 / gunConfig.Rapidity;
        }

        private void ResetRounds()
        {
            _currentRounds = gunConfig.Rounds;
            _lastShotTime = -gunConfig.Rapidity;
        }
    }
}