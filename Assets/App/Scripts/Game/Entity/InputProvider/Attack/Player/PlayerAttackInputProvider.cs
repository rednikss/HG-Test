using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider.Attack.Player
{
    public class PlayerAttackInputProvider : IAttackInputProvider
    {
        public bool IsAttacking()
        {
            return Input.GetButton("Fire1");
        }
    }
}