using App.Scripts.Game.Entity.Movement.Config;
using App.Scripts.Game.InputProvider;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement
{
    public class MovingEntity : ITickable
    {
        private readonly ConfigMovement _configMovement;
        
        private readonly CharacterController _characterController;
        
        private readonly Transform _entityRotatableTransform;
        
        private readonly IInputProvider _inputProvider;
        
        private readonly Transform _entityTransform;
        
        public MovingEntity(ConfigMovement configMovement, 
            IInputProvider inputProvider,
            CharacterController characterController, 
            Transform entityRotatableTransform)
        {
            _configMovement = configMovement;
            _inputProvider = inputProvider;
            _characterController = characterController;
            _entityRotatableTransform = entityRotatableTransform;
            _entityTransform = characterController.transform;
        }

        public void Tick(float deltaTime)
        {
            MoveEntity(_inputProvider.GetMovementDirection(), deltaTime);
            RotateEntity(_inputProvider.GetRotationDirection());
        }

        private void MoveEntity(Vector3 direction, float deltaTime)
        {
            direction.Normalize();
            direction = _entityTransform.rotation * direction;
            
            _characterController.Move(direction * (deltaTime * _configMovement.Speed));
        }

        private void RotateEntity(Vector2 direction)
        {
            direction *= _configMovement.Sensitivity;
            
            _entityTransform.rotation *= Quaternion.AngleAxis(direction.x, Vector3.up);
            _entityRotatableTransform.transform.rotation *= Quaternion.AngleAxis(direction.y, Vector3.left);
        }
    }
}