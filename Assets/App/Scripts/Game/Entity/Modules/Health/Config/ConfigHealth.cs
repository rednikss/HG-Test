using System;
using UnityEngine;

namespace App.Scripts.Game.Entity.Modules.Health.Config
{
    [Serializable]
    public class ConfigHealth
    {
        [Min(1)]
        public int StartHealth;
    }
}