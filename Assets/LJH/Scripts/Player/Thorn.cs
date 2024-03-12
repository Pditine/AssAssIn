using UnityEngine;

namespace LJH.Scripts.Player
{
    public class Thorn : MonoBehaviour
    {
        [SerializeField] private PlayerController thePlayer;

        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Player":
                    if(other.collider.gameObject.CompareTag("Thorn"))
                    {
                        var otherPlayer = other.gameObject.GetComponent<PlayerController>();
                        //if (!thePlayer) thePlayer = other.gameObject.GetComponentInParent<PlayerController>();
                        otherPlayer.Direction = -otherPlayer.Direction;
                        otherPlayer.CurrentSpeed = thePlayer.CurrentSpeed;
                        
                    }
                    break;
            }
            
        }
    }
}