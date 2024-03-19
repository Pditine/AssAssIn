using System;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.Events;

namespace LJH.Scripts.Collide
{
    public abstract class ColliderBase : MonoBehaviour
    {
        private float _collideCD = 0.1f;
        private float _currentCollideCD;

        //private bool _canCollide = true;
        private ColliderBase _lastCollider;

        protected UnityAction collisionEvent;
        public UnityAction CollisionEvent => collisionEvent;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_currentCollideCD > 0) return;
            //if (!_canCollide) return;
            var otherCollider = other.collider.gameObject.GetComponent<ColliderBase>();
            if (!otherCollider) return;
            _lastCollider = otherCollider;
            if (otherCollider._currentCollideCD > 0) return;
            //if (!otherCollider._canCollide) return;
            otherCollider._currentCollideCD = otherCollider._collideCD;
            _currentCollideCD = _collideCD;
            //_canCollide = false;
            //otherCollider._canCollide = false;
            CollideHandler.ColliderHandle(gameObject.tag,otherCollider.gameObject.tag,this,otherCollider);
            //CollisionEvent?.Invoke();
            PFCLog.Info(_lastCollider.gameObject.name);
        }

        // private void OnCollisionExit2D(Collision2D other)
        // {
        //     //if (_canCollide) return;
        //     // var otherCollider = other.collider.gameObject.GetComponent<ColliderBase>();
        //     // if (!otherCollider) return;
        //     // PFCLog.Info(otherCollider.gameObject.name);
        //     // if (otherCollider == _lastCollider)
        //         _canCollide = true;
        //
        // }


        protected void Update()
        {
            _currentCollideCD -= Time.deltaTime;
            if (_currentCollideCD <= 0) _currentCollideCD = 0;
        }
    }
}