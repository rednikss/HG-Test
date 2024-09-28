using UnityEngine;

namespace App.Scripts.Game.InputProvider
{
    public interface IInputProvider
    {
        public Vector3 GetMovementDirection();

        public Vector2 GetRotationDirection();
    }
}