using System.Collections.Generic;
using PurpleFlowerCore;
using PurpleFlowerCore.Event;
using UnityEngine;

namespace LJH.Scripts.Player
{
    public class PlayerActionManager : SingletonMono<PlayerActionManager>
    {
        [SerializeField] private List<PlayerAction> players = new();

        
        public void AddPlayer(PlayerAction thePlayer)
        {
            players.Add(thePlayer);
        }

        public void CheckReady()
        {
            foreach (var player in players)
            {
                if (!player.Ready) return;
            }
            EventSystem.EventTrigger("GameStart");
        }
    }
}