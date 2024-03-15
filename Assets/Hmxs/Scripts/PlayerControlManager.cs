using System.Collections.Generic;
using Hmxs.Toolkit.Base.Singleton;
using LJH.Scripts.Player;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hmxs.Scripts
{
    public class PlayerControlManager : SingletonMono<PlayerControlManager>
    {
        [SerializeField] private GameObject uiLeft;
        [SerializeField] private GameObject uiRight;
        public PlayerController playerLeft;
        public PlayerController playerRight;

        [ReadOnly] [SerializeField] private List<int> activePlayers = new(2) { -1, -1 };

        private PlayerInputManager _playerInputManager;

        private void Start()
        {
            uiLeft.SetActive(true);
            uiRight.SetActive(true);
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.onPlayerJoined += OnPlayerJoined;
            _playerInputManager.onPlayerLeft += OnPlayerLeft;
        }

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            if (activePlayers[0] == -1)
            {
                playerInput.GetComponent<PlayerAction>().BindPlayer(playerLeft);
                activePlayers[0] = playerInput.playerIndex;
                uiLeft.SetActive(false);
                Debug.Log("Player Join: " + playerInput.devices[0].name);
            }
            else if (activePlayers[1] == -1)
            {
                playerInput.GetComponent<PlayerAction>().BindPlayer(playerRight);
                activePlayers[1] = playerInput.playerIndex;
                uiRight.SetActive(false);
                Debug.Log("Player Join: " + playerInput.devices[0].name);
            }
            else
                Debug.Log("No more player can join");
        }

        private void OnPlayerLeft(PlayerInput playerInput)
        {
            if (activePlayers[0] == playerInput.playerIndex)
            {
                if (uiLeft) uiLeft.SetActive(true);
                activePlayers[0] = -1;
                Debug.Log("Player Left: " + playerInput.devices[0].name);
            }
            else if (activePlayers[1] == playerInput.playerIndex)
            {
                if (uiRight) uiRight.SetActive(true);
                activePlayers[1] = -1;
                Debug.Log("Player Left: " + playerInput.devices[0].name);
            }
            else
                Debug.Log("No player to leave");
        }
    }
}