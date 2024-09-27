using UnityEngine;

namespace App.Scripts.Game.InputProvider
{
    public class DefaultPlayerInputProvider : IPlayerInputProvider
    {
        public Vector3 GetMovementDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        public Vector2 GetRotationDirection()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}