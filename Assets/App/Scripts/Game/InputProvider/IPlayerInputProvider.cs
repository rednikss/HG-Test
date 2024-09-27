using UnityEngine;

namespace App.Scripts.Game.InputProvider
{
    public interface IPlayerInputProvider
    {
        public Vector3 GetMovementDirection();

        public Vector2 GetRotationDirection();
    }
}