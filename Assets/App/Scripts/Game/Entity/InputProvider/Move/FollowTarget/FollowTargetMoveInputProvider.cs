using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider.Move.FollowTarget
{
    public class FollowTargetMoveInputProvider : IMoveInputProvider
    {
        private readonly Transform _targetTransform;

        private readonly Transform _sourceTransform;

        
        public FollowTargetMoveInputProvider(Transform target, Transform sourceTransform)
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