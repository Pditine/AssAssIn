using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerAction : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private bool canSelect = true;

        private PlayerController _thePlayer;

        public void BindPlayer(PlayerController targetPlayer)
        {
            _thePlayer = targetPlayer;
            _thePlayer.TheInput = GetComponent<PlayerInput>();
        }

        #region PlayerInput

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

        #endregion

        #region Prepare

        public void Select(InputAction.CallbackContext ctx)
        {
            var input = ctx.ReadValue<Vector2>();
            if (!canSelect)
            {
                if (input == Vector2.zero) canSelect = true;
                return;
            }

            var angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            switch (angle)
            {
                case >= -45 and <= 45:
                    // Right
                    Debug.Log("Right");
                    break;
                case >= 45 and <= 135:
                    // Up
                    Debug.Log("Up");
                    break;
                case >= -135 and <= -45:
                    // Left
                    Debug.Log("Left");
                    break;
                default:
                    // Down
                    Debug.Log("Down");
                    break;
            }

            canSelect = false;
        }

        public void Confirm(InputAction.CallbackContext ctx)
        {
            // confirm
            Debug.Log(ctx.ReadValue<bool>());
        }

        #endregion

        public void OnDeviceLost(PlayerInput playerInput) => Destroy(gameObject);
    }
}