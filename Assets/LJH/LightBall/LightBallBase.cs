using LJH.Scripts.Player;
using UnityEngine;

namespace LJH.LightBall
{
    public abstract class LightBallBase : MonoBehaviour
    {
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
            
        }

        protected virtual void BeDestroy()
        {
            //todo:be destroy
            gameObject.SetActive(false);
        }
    }
}