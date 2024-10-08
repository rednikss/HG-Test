﻿using App.Scripts.Game.Entity.Modules.Health.Config;
using App.Scripts.Game.Entity.Modules.Movement.Config;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Config
{
    [CreateAssetMenu(fileName = "Default Entity Config", menuName = "Scriptable Object/Game/Entity Config", order = 0)]
    public class ConfigEntity : ScriptableObject
    {
        public ConfigHealth Health;
        
        public ConfigMovement Movement;
    }

}