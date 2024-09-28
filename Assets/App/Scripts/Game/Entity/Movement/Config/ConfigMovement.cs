﻿using System;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Config
{
    [Serializable]
    public class ConfigMovement
    {
        [Min(0)]
        public float Speed;
        
        [Min(0)]
        public float Sensitivity;
    }
}