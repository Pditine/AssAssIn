using PurpleFlowerCore;
using UnityEngine;

namespace LJH.Scripts.Collide
{
    public abstract class ColliderBase : MonoBehaviour
    {
        [SerializeField] private float collideCD;
        
        private float _currentCollideCD;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_currentCollideCD > 0) return;
            PFCLog.Info(gameObject.name+":"+ _currentCollideCD);
            var otherCollider = other.collider.gameObject.GetComponent<ColliderBase>();
            if (!otherCollider) return;
            otherCollider._currentCollideCD = otherCollider.collideCD;
            _currentCollideCD = collideCD;
            CollideHandler.ColliderHandle(gameObject.tag,otherCollider.gameObject.tag,this,otherCollider);
        }

        protected void Update()
        {
            _currentCollideCD -= Time.deltaTime;
            if (_currentCollideCD <= 0) _currentCollideCD = 0;
        }
    }
}