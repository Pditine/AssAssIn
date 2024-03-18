using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.Events;

namespace LJH.Scripts.Collide
{
    public abstract class ColliderBase : MonoBehaviour
    {
        private float _collideCD = 0.2f;
        
        private float _currentCollideCD;

        protected UnityAction collisionEvent;
        public UnityAction CollisionEvent => collisionEvent;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_currentCollideCD > 0) return;
            var otherCollider = other.collider.gameObject.GetComponent<ColliderBase>();
            if (!otherCollider) return;
            if (otherCollider._currentCollideCD > 0) return;
            otherCollider._currentCollideCD = otherCollider._collideCD;
            _currentCollideCD = _collideCD;
            CollideHandler.ColliderHandle(gameObject.tag,otherCollider.gameObject.tag,this,otherCollider);
            //CollisionEvent?.Invoke();
        }
        
        
        protected void Update()
        {
            _currentCollideCD -= Time.deltaTime;
            if (_currentCollideCD <= 0) _currentCollideCD = 0;
        }
    }
}