using System;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.Config
{
    [Serializable]
    public class ConfigGun
    {
        [Min(0)]
        [Tooltip("Rounds per second")]
        public float Rapidity;

        [Min(0)]
        public int Rounds;
        
        [Min(0)]
        public float ReloadTime;
    }
}