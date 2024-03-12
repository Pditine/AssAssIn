using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hmxs.Scripts
{
    public class PlayerControlManager : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;

        private void Start()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.onPlayerJoined += OnPlayerJoined;
            _playerInputManager.onPlayerLeft += OnPlayerLeft;
        }

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            Debug.Log("Player Join" + playerInput.devices[0].name);
        }

        private void OnPlayerLeft(PlayerInput playerInput)
        {
            Debug.Log("Player Left" + playerInput.devices[0].name);
        }
    }
}