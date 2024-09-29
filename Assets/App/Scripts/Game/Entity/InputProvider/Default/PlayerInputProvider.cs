using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider.Default
{
    public class PlayerInputProvider : IInputProvider
    {
        public Vector3 GetMovementDirection()
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        public Vector2 GetRotationDirection()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        public bool IsAttacking()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}