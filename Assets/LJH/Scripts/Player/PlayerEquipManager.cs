using System.Collections.Generic;
using PurpleFlowerCore;
using UnityEngine;

namespace LJH.Scripts.Player
{
    public class PlayerEquipManager : SingletonMono<PlayerEquipManager>
    {
        [SerializeField] private List<PlayerController> players = new();

        public void LastPlayerThorn(int playerIndex)
        {
            players[playerIndex].LastThorn();
        }

        public void NextPlayerThorn(int playerIndex)
        {
            players[playerIndex].NextThorn();
        }
        public void LastPlayerAss(int playerIndex)
        {
            players[playerIndex].LastAss();
        }
        public void NextPlayerAss(int playerIndex)
        {
            players[playerIndex].NextAss();
        }
    }
}