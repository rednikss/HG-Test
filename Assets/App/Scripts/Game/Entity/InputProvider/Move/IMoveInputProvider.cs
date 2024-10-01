using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider.Move
{
    public interface IMoveInputProvider
    {
        public Vector3 GetMovementDirection();

        public Vector2 GetRotationDirection();
    }
}