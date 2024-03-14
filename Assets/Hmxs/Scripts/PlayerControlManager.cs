using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hmxs.Scripts
{
    public enum UIType
    {
        Left,
        Right
    }

    public class PlayerControlManager : MonoBehaviour
    {
        [SerializeField] private GameObject uiLeft;
        [SerializeField] private GameObject uiRight;

        public Dictionary<int, UIType> activePlayers = new();

        private PlayerInputManager _playerInputManager;

        private void Start()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.onPlayerJoined += OnPlayerJoined;
            _playerInputManager.onPlayerLeft += OnPlayerLeft;
        }

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            Debug.Log("Player Join: " + playerInput.devices[0].name);
            if (activePlayers.Count == 0)
            {
                activePlayers.Add(playerInput.playerIndex, UIType.Left);
                uiLeft.SetActive(false);
            }
            else
            {
                activePlayers.Add(playerInput.playerIndex, UIType.Right);
                uiRight.SetActive(false);
            }
        }

        private void OnPlayerLeft(PlayerInput playerInput)
        {
            Debug.Log("Player Left: " + playerInput.devices[0].name);
            if (activePlayers[playerInput.playerIndex] == UIType.Left)
                uiLeft.SetActive(true);
            else
                uiRight.SetActive(true);
            activePlayers.Remove(playerInput.playerIndex);
        }
    }
}