using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider
{
    public interface IInputProvider
    {
        public Vector3 GetMovementDirection();

        public Vector2 GetRotationDirection();

        public bool IsAttacking();
    }
}