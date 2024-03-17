using System.Collections.Generic;
using PurpleFlowerCore;
using PurpleFlowerCore.Event;
using UnityEngine;

namespace LJH.Scripts.Player
{
    public class PlayerActionManager : SingletonMono<PlayerActionManager>
    {
        private readonly List<PlayerAction> _players = new();

        
        public void AddPlayer(PlayerAction thePlayer)
        {
            _players.Add(thePlayer);
        }

        public void CheckReady()
        {
            if (_players.Count <= 1) return;
            foreach (var player in _players)
            {
                if (!player.Ready) return;
            }

            foreach (var player in _players)
            {
                player.StartFight();
            }
            EventSystem.EventTrigger("GameStart");
        }
    }
}