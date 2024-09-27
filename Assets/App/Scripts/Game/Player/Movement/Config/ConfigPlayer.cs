using UnityEngine;

namespace App.Scripts.Game.Player.Movement.Config
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Scriptable Object/Game/Player Config", order = 0)]
    public class ConfigPlayer : ScriptableObject
    {
        public float speed;
        public float sensitivity;
    }
}