using System;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Bullet.Config
{
    [Serializable]
    public class ConfigBullet
    {
        [Min(0)]
        public float Damage;

        [Min(0)] 
        public float Speed;
        
        [Min(0)]
        public float Range;
    }
}