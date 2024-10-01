using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Config.List
{
    [CreateAssetMenu(fileName = "Weapon List Config", menuName = "Scriptable Object/Game/Weapon/Weapon List Config", order = 0)]
    public class ConfigWeaponList : ScriptableObject
    {
        public ConfigWeapon[] List;
    }
}