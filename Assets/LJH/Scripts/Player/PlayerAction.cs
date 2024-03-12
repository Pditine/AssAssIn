using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerAction : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerController _thePlayer;
        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _thePlayer = FindObjectsOfType<PlayerController>().FirstOrDefault(p=>p.id == _playerInput.playerIndex);
        }

        public void ChangeDirection(InputAction.CallbackContext ctx)
        {
            if (!_thePlayer) return;
            _thePlayer.ChangeDirection(ctx);
        }

        public void Launch(InputAction.CallbackContext ctx)
        {
            if (!_thePlayer) return;
            _thePlayer.Launch(ctx);
        }
        
    }
}