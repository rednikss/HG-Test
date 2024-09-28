using App.Scripts.Game.Entity.Movement.Config;
using App.Scripts.Game.InputProvider;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement
{
    public class MovingEntity : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        [SerializeField] private Transform _entityRotatableTransform;
        
        private IInputProvider _inputProvider;
        
        private MovementSettings _movementSettings;
        
        private Transform _entityTransform;
        
        public void Construct(IInputProvider inputProvider, MovementSettings movementSettings)
        {
            _inputProvider = inputProvider;
            _movementSettings = movementSettings;
            _entityTransform = _characterController.transform;
        }

        private void Update()
        {
            MoveEntity(_inputProvider.GetMovementDirection());
            RotateEntity(_inputProvider.GetRotationDirection());
        }

        private void MoveEntity(Vector3 direction)
        {
            direction.Normalize();
            direction = _entityTransform.rotation * direction;
            
            _characterController.Move(direction * (Time.deltaTime * _movementSettings.Speed));
        }

        private void RotateEntity(Vector2 direction)
        {
            direction *= _movementSettings.Sensitivity;
            
            _entityTransform.rotation *= Quaternion.AngleAxis(direction.x, Vector3.up);
            _entityRotatableTransform.transform.rotation *= Quaternion.AngleAxis(direction.y, Vector3.left);
        }
    }
}