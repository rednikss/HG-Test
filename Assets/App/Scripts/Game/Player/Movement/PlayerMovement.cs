using App.Scripts.Game.InputProvider;
using App.Scripts.Game.Player.Movement.Config;
using UnityEngine;

namespace App.Scripts.Game.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private ConfigPlayer _playerConfig;
        
        [SerializeField] private CharacterController _characterController;
        
        [SerializeField] private Camera _playerCamera;

        private Transform _playerTransform;
        
        private IPlayerInputProvider _playerInputProvider;

        public void Construct(IPlayerInputProvider playerInputProvider)
        {
            _playerInputProvider = playerInputProvider;
            _playerTransform = _characterController.transform;
        }

        private void Update()
        {
            MovePlayer(_playerInputProvider.GetMovementDirection());
            RotatePlayer(_playerInputProvider.GetRotationDirection());
        }

        private void MovePlayer(Vector3 direction)
        {
            direction.Normalize();
            direction = _playerTransform.rotation * direction;
            
            _characterController.Move(direction * (Time.deltaTime * _playerConfig.speed));
        }

        private void RotatePlayer(Vector2 direction)
        {
            direction *= _playerConfig.sensitivity;
            
            _playerTransform.rotation *= Quaternion.AngleAxis(direction.x, Vector3.up);
            _playerCamera.transform.rotation *= Quaternion.AngleAxis(direction.y, Vector3.left);
        }
    }
}