using System.Collections.Generic;
using System.Linq;
using LJH.Scripts.UI;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace LJH.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private int id;
        public int ID => id;
        private bool _isCharging;
        [HideInInspector]public float CurrentSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float friction;
        [SerializeField] private float rotateSpeed;
        private Vector2 _inputDirection;
        [SerializeField] private GameObject directionArrow;
        [HideInInspector]public Vector2 Direction;
        private PlayerCD _cdUI;
        
        [SerializeField] private float cd;
        private float _currentCD;

        [HideInInspector]public PlayerInput TheInput;

        [SerializeField] private List<Thorn> thorns = new();
        [SerializeField] private List<Ass> asses = new();

        private Thorn _theThorn;
        public Thorn TheThorn => _theThorn;
        private Ass _theAss;
        public Ass TheAss => _theAss;

        private void Start()
        {
            Direction = transform.right;
            _cdUI = FindObjectsOfType<PlayerCD>().FirstOrDefault(p=>p.ID == id);
            if(!_cdUI)
                PFCLog.Error("未找到UI");
            ChangeThorn(0);
            ChangeAss(1);
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3)Direction*(CurrentSpeed*Time.deltaTime);
            transform.right = Vector3.Lerp(transform.right, Direction, rotateSpeed);
        }

        private void Update()
        {
            ReduceSpeed();
            UpdateCD();
        }

        public void ChangeDirection(InputAction.CallbackContext ctx)
        {
            if (!_isCharging) return;
            var tempInputDirection = _inputDirection;
            _inputDirection = ctx.ReadValue<Vector2>().normalized;
            if (_inputDirection.normalized == Vector2.zero)
                _inputDirection = tempInputDirection;
            directionArrow.transform.right = _inputDirection;
        }

        public void Launch(InputAction.CallbackContext ctx)
        {
            if (_currentCD > 0) return;
            
            if (ctx.started)
            {
                if (_isCharging) return;
                _isCharging = true;
                directionArrow.SetActive(true);
                Debug.Log("开始蓄力");
            }
        
            if (ctx.canceled)
            {
                if (!_isCharging) return;
                _isCharging = false;
                Direction = _inputDirection;
                CurrentSpeed = maxSpeed;
                _currentCD = cd;
                directionArrow.SetActive(false);
                Debug.Log("结束蓄力");
            }
        }

        private void ReduceSpeed()
        {
            CurrentSpeed -= friction*Time.deltaTime;
            if (CurrentSpeed <= 0) CurrentSpeed = 0;
        }

        private void UpdateCD()
        {
            if(!_isCharging)
                _currentCD -= Time.deltaTime;
            if (_currentCD <= 0) _currentCD = 0;
            _cdUI.UpdateCD(_currentCD/cd);
        }

        public void ChangeSpeed(float percentageDelta)
        {
            maxSpeed *= 1 + percentageDelta*0.01f;
        }

        public void ChangeThorn(int thornIndex)
        {
            if(_theThorn)
                _theThorn.gameObject.SetActive(false);
            _theThorn = thorns[thornIndex];
            _theThorn.gameObject.SetActive(true);
        }
        
        public void ChangeAss(int assIndex)
        {
            if(_theAss)
                _theAss.gameObject.SetActive(false);
            _theAss = asses[assIndex];
            _theAss.gameObject.SetActive(true);
        }
    }
}
