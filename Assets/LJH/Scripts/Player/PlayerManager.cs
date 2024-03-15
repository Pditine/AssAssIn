using System.Collections.Generic;
using PurpleFlowerCore;
using UnityEngine;

namespace LJH.Scripts.Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        [SerializeField] private List<PlayerController> players = new();

        public void ChangePlayerThorn(int playerIndex,int thornIndex)
        {
            
        }

        public void ChangePlayerAss(int playerIndex,int assIndex)
        {
            
        }
    }
}