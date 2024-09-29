using System.Collections.Generic;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Config;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Default
{
    public class DefaultGunshotController : IGunshotController
    {
        private readonly ConfigGunshot _gunshotConfig;

        private readonly IObjectPool<Bullet.Bullet> _bulletPool;

        public DefaultGunshotController(ConfigGunshot gunshotConfig, IObjectPool<Bullet.Bullet> bulletPool)
        {
            _gunshotConfig = gunshotConfig;
            _bulletPool = bulletPool;
        }
        
        public void CreateGunshot(IEnumerable<Transform> spawnPoints)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var bullet = _bulletPool.Get();

                bullet.transform.position = spawnPoint.position;
                
                bullet.Fly(
                    GetRangedDirection(spawnPoint.forward), 
                    _gunshotConfig.BulletConfig);
            }
        }
        
        private Vector3 GetRangedDirection(Vector3 direction)
        {
            var rotation = Quaternion.Euler(
                GetRandomAngle(_gunshotConfig.AngleRange), 
                GetRandomAngle(_gunshotConfig.AngleRange), 
                0);
            
            return rotation * direction;
        }

        private float GetRandomAngle(float angle)
        {
            return Random.Range(-angle, angle);
        }
    }
}