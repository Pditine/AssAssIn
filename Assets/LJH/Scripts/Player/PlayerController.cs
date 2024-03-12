using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public int id;
        private bool _isCharging;
        private float _currentSpeed;
        public float CurrentSpeed => _currentSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float friction;
        [SerializeField] private float rotateSpeed;
        private Vector2 _inputDirection;
        public Vector2 Direction;
        
        private void FixedUpdate()
        {
            transform.position += (Vector3)Direction*(_currentSpeed*Time.deltaTime);
            transform.right = Vector3.Lerp(transform.right, Direction, rotateSpeed);
            ReduceSpeed();
        }

        public void ChangeDirection(InputAction.CallbackContext ctx)
        {
            if (!_isCharging) return;
            _inputDirection = -ctx.ReadValue<Vector2>().normalized;
        }

        public void Launch(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _isCharging = true;
                Debug.Log("开始蓄力");
            }
        
            if (ctx.canceled)
            {
                _isCharging = false;
                Direction = _inputDirection;
                _currentSpeed = maxSpeed;
                Debug.Log("结束蓄力");
            }
        }

        private void ReduceSpeed()
        {
            if (_currentSpeed <= 0) _currentSpeed = 0;
            _currentSpeed -= friction;
        }
    }
}
