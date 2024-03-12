using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public int id;
        private bool _isCharging;
        [HideInInspector]public float CurrentSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float friction;
        [SerializeField] private float rotateSpeed;
        private Vector2 _inputDirection;
        [HideInInspector]public Vector2 Direction;

        private void Start()
        {
            Direction = transform.right;
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3)Direction*(CurrentSpeed*Time.deltaTime);
            transform.right = Vector3.Lerp(transform.right, Direction, rotateSpeed);
        }

        private void Update()
        {
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
                CurrentSpeed = maxSpeed;
                Debug.Log("结束蓄力");
            }
        }

        private void ReduceSpeed()
        {
            CurrentSpeed -= friction*Time.deltaTime;
            if (CurrentSpeed <= 0) CurrentSpeed = 0;
        }
    }
}
