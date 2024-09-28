using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Game.Entity.InputProvider.FollowTarget
{
    public class FollowTargetInputProvider : IInputProvider
    {
        private readonly Transform _targetTransform;

        private readonly Transform _sourceTransform;

        private readonly Timer _timer;

        private float _lastTime;
        
        public FollowTargetInputProvider(Transform target, Transform sourceTransform, Timer timer)
        {
            _targetTransform = target;
            _sourceTransform = sourceTransform;
            _timer = timer;
            _lastTime = _timer.GetCurrentTime();
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

        public bool IsShooting()
        {
            var newTime = _timer.GetCurrentTime();

            if (newTime - _lastTime < 5) return false;
            
            _lastTime = newTime;
            return true;
        }
    }
}