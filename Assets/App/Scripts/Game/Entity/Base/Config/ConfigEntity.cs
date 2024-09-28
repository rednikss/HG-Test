using App.Scripts.Game.Entity.Health.Config;
using App.Scripts.Game.Entity.Movement.Config;
using UnityEngine;

namespace App.Scripts.Game.Entity.Config
{
    [CreateAssetMenu(fileName = "Default Entity Config", menuName = "Scriptable Object/Game/Entity Config", order = 0)]
    public class ConfigEntity : ScriptableObject
    {
        public ConfigHealth Health;
        
        public ConfigMovement Movement;
    }

}