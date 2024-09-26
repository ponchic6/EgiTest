using System;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace PlayerControl
{
    public class PlayerMover : MonoBehaviour, ISpeedControlable
    {
        public event Action<Vector2> OnJoystickTilt;
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform playerCameraPos;
        
        private float _speed;
        private MainInputMap _mainInputMap;
        private GlobalConfig _globalConfig;

        public float CurrentSpeed => _speed;
        public Transform PlayerCameraPos => playerCameraPos;

        [Inject]
        public void Constructor(GlobalConfig globalConfig)
        {
            _globalConfig = globalConfig;
        }
        
        private void Start()
        {
            _mainInputMap = new MainInputMap();
            _mainInputMap.Enable();
            SetBaseSpeed();
        }

        private void OnDestroy()
        {
            _mainInputMap.Disable();
        }

        private void Update()
        {
            var readValue = _mainInputMap.MainActionMaps.PlayerMove.ReadValue<Vector2>();
            MoveAndRotatePlayer(readValue);
            OnJoystickTilt?.Invoke(readValue);
        }

        public void SetBaseSpeed() => _speed = _globalConfig.BaseSpeed;
        public void IncreaseSpeed(float addingSpeed) => _speed += addingSpeed;

        private void MoveAndRotatePlayer(Vector2 readValue)
        {
            Vector3 direction = new Vector3(readValue.x, 0, readValue.y);
            rb.velocity = direction * _speed;
            
            if (readValue != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
