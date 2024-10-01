using App.Scripts.Game.Mechanics.Shooting.Weapon;

namespace App.Scripts.Game.Mechanics.Shooting.WeaponChanger
{
    public interface IArmed
    {
        public void SetWeapon(WeaponBehaviour weaponBehaviour);
    }
}