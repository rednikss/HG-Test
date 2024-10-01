using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.Config;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Config;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Config
{
    [CreateAssetMenu(fileName = "Weapon Config", menuName = "Scriptable Object/Game/Weapon/Weapon Config", order = 0)]
    public class ConfigWeapon : ScriptableObject
    {
        public Gun.Gun Prefab;

        public ConfigGun Gun;
        
        public ConfigGunshot Gunshot;
    }
}