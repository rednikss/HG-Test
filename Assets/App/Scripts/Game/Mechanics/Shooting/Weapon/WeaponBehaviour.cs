using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        public abstract void Attack();
        
        public void SetPivot(Transform pivot)
        {
            var weaponTransform = transform;
            
            weaponTransform.SetParent(pivot);
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.rotation = pivot.rotation;
        }
    }
}