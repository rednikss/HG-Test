using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        public abstract void Attack();
        
        public void SetPivot(Transform pivot)
        {
            transform.SetParent(pivot);
            transform.localPosition = Vector3.zero;
            transform.rotation = pivot.rotation;
        }
    }
}