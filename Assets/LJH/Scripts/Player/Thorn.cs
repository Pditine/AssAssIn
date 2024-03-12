using UnityEngine;

namespace LJH.Scripts.Player
{
    public class Thorn : MonoBehaviour
    {
        [SerializeField] private PlayerController thePlayer;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //thePlayer.Direction = 
            }
        }
    }
}