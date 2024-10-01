using App.Scripts.Game.Entity.InputProvider.Move;
using App.Scripts.Game.Entity.Modules.Movement.Config;
using App.Scripts.Libs.Patterns.StateMachine.State;
using UnityEngine;

namespace App.Scripts.Game.Entity.Modules.Movement
{
    public class MovingEntityModule : ITickable
    {
        private readonly ConfigMovement _configMovement;
        
        private readonly CharacterController _characterController;
        
        private readonly Transform _entityRotatableTransform;
        
        private readonly IMoveInputProvider _moveInputProvider;
        
        private readonly Transform _entityTransform;
        
        public MovingEntityModule(ConfigMovement configMovement, 
            IMoveInputProvider moveInputProvider,
            CharacterController characterController, 
            Transform entityRotatableTransform)
        {
            _configMovement = configMovement;
            _moveInputProvider = moveInputProvider;
            _characterController = characterController;
            _entityRotatableTransform = entityRotatableTransform;
            _entityTransform = characterController.transform;
        }

        public void Tick(float deltaTime)
        {
            MoveEntity(_moveInputProvider.GetMovementDirection(), deltaTime);
            RotateEntity(_moveInputProvider.GetRotationDirection());
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