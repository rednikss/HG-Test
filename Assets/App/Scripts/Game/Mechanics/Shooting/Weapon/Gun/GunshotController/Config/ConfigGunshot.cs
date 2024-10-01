using System;
using App.Scripts.Game.Mechanics.Shooting.Bullet.Config;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Config
{
    [Serializable]
    public class ConfigGunshot
    {
        public ConfigBullet BulletConfig;
        
        public float AngleRange;
    }
}