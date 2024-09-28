using UnityEngine;

namespace App.Scripts.Game.InputProvider.FollowTarget
{
    public class FollowTargetInputProvider : IInputProvider
    {
        private readonly Transform _targetTransform;

        private readonly Transform _sourceTransform;
        
        public FollowTargetInputProvider(Transform target, Transform sourceTransform)
        {
            _targetTransform = target;
            _sourceTransform = sourceTransform;
        }
        
        public Vector3 GetMovementDirection()
        {
            return Vector3.zero;
        }

        public Vector2 GetRotationDirection()
        {
            var targetDirection = _targetTransform.position - _sourceTransform.position;
            var angle = Vector3.SignedAngle(_sourceTransform.forward, targetDirection, Vector3.up);
            angle = Mathf.Clamp(angle, -1, 1);
            
            return new Vector2(angle, 0);
        }
    }
}