using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerAction : MonoBehaviour
    {
        private PlayerController _thePlayer;

        public void BindPlayer(PlayerController targetPlayer)
        {
            _thePlayer = targetPlayer;
            _thePlayer.TheInput = GetComponent<PlayerInput>();
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

        public void OnDeviceLost(PlayerInput playerInput)
        {
            Destroy(gameObject);
        }
    }
}