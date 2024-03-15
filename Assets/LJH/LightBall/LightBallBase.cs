using LJH.Scripts.Player;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace LJH.LightBall
{
    public abstract class LightBallBase : MonoBehaviour
    {
        protected SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                AddBuff(other.GetComponent<PlayerController>());
                BeDestroy();
            }
        }
        protected abstract void AddBuff(PlayerController thePlayer);

        public virtual void BeCreate()
        {
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