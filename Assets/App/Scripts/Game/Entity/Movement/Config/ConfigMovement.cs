using System;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Config
{
    [CreateAssetMenu(fileName = "Default Movement Config", menuName = "Scriptable Object/Game/Movement Config", order = 0)]
    public class ConfigMovement : ScriptableObject
    {
        public MovementSettings Settings;
    }

    [Serializable]
    public class MovementSettings
    {
        [Min(0)]
        public float Speed;
        
        [Min(0)]
        public float Sensitivity;
    }
}