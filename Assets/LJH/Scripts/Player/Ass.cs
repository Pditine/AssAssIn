using LJH.Scripts.Collide;
using UnityEngine;

namespace LJH.Scripts.Player
{
    public class Ass : ColliderBase
    {
        [SerializeField] private PlayerController thePlayer;
        
        public PlayerController ThePlayer => thePlayer;
    }
}