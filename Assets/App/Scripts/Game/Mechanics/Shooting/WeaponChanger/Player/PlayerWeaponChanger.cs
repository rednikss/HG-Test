using System.Collections.Generic;
using App.Scripts.Game.Entity.Modules.Attacking;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Libs.Patterns.Factory;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.WeaponChanger.Player
{
    public class PlayerWeaponChanger : WeaponChanger
    {
        public PlayerWeaponChanger(List<IFactory<WeaponBehaviour>> weaponList, IArmed armed) 
            : base(weaponList, armed)
        {
            
        }

        public override void Init()
        {
            var weaponID = 0;
            Armed.SetWeapon(WeaponList[weaponID].Create());
        }
        
        public override void Tick(float deltaTime)
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                if (Input.GetButton("Weapon " + (i + 1)))
                {
                    Armed.SetWeapon(WeaponList[i].Create());
                }
            }
        }

    }
}