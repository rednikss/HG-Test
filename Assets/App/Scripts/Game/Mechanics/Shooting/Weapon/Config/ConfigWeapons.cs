using System;
using App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController.Config;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Config
{
    [CreateAssetMenu(fileName = "Weapons Config", menuName = "Scriptable Object/Game/Weapons Config", order = 0)]
    public class ConfigWeapons : ScriptableObject
    {
        public ConfigWeapon[] list;
    }
    
    [Serializable]
    public class ConfigWeapon
    {
        public string Name;
        
        public Gun.Gun Prefab;
        
        public ConfigGunshot Gunshot;
    }
}