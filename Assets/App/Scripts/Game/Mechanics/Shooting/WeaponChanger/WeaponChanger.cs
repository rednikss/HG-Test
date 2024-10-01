using System.Collections.Generic;
using App.Scripts.Game.Mechanics.Shooting.Weapon;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.StateMachine.State;

namespace App.Scripts.Game.Mechanics.Shooting.WeaponChanger
{
    public abstract class WeaponChanger : ITickable
    {
        protected readonly List<IFactory<WeaponBehaviour>> WeaponList;
        
        private WeaponBehaviour _currentWeapon;

        protected readonly IArmed Armed;

        protected WeaponChanger(List<IFactory<WeaponBehaviour>> weaponList, IArmed armed)
        {
            WeaponList = weaponList;
            Armed = armed;
        }

        public virtual void Init()
        {
            
        }
        
        public abstract void Tick(float deltaTime);
    }
}