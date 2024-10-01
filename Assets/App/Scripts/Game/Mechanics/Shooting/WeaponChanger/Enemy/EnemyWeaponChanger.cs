using System.Collections.Generic;
using App.Scripts.Game.Entity.Modules.Attacking;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Libs.Patterns.Factory;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.WeaponChanger.Enemy
{
    public class EnemyWeaponChanger : WeaponChanger
    {
        public EnemyWeaponChanger(List<IFactory<WeaponBehaviour>> weaponList, IArmed armed) 
            : base(weaponList, armed)
        {
        }

        public override void Init()
        {
            var weaponID = Random.Range(0, WeaponList.Count);
            
            Armed.SetWeapon(WeaponList[weaponID].Create());
        }

        public override void Tick(float deltaTime)
        {
            
        }
    }
}