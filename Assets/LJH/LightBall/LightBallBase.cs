using LJH.Scripts.Player;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace LJH.LightBall
{
    public abstract class LightBallBase : MonoBehaviour
    {
        [SerializeField]protected bool HasTriggered;
        protected SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (HasTriggered) return; 
            if (other.CompareTag("Player"))
            {
                PFCLog.Info("碰撞:"+gameObject.name);
                AddBuff(other.GetComponent<PlayerController>());
                BeDestroy();
                HasTriggered = true;
            }
            if (other.CompareTag("Thorn")|| other.CompareTag("Ass"))
            {
                PFCLog.Info("碰撞:"+gameObject.name);
                AddBuff(other.GetComponentInParent<PlayerController>());
                BeDestroy();
                HasTriggered = true;
            }
        }
        protected abstract void AddBuff(PlayerController thePlayer);

        public virtual void BeCreate()
        {
            HasTriggered = false;
            FadeUtility.FadeInAndStay(SpriteRenderer,100);
        }

        protected virtual void BeDestroy()
        {
            FadeUtility.FadeOut(SpriteRenderer,200, () =>
            {
                PoolSystem.PushGameObject(gameObject);
            });
        }
    }
}