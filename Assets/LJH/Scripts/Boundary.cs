using LJH.Scripts.Player;
using UnityEngine;

namespace LJH.Scripts
{
    public class Boundary : MonoBehaviour
    {
        //[SerializeField] private float offset;
        [SerializeField] private Vector2 normalDirection;
        //[SerializeField] private float force;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var thePlayer = other.gameObject.GetComponent<PlayerController>();
                var originDirection = thePlayer.Direction;
                Vector2 Out_Direction = Vector2.Reflect(originDirection,normalDirection);

                thePlayer.Direction = Out_Direction;
                
                //other.transform.position += (Vector3)normalDirection*offset;
            }
            
        }
    }
}