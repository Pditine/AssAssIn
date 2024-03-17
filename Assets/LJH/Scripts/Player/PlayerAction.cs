using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class PlayerAction : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private bool canSelect = true;
        private bool _ready;
        private bool Ready => _ready;// 期望判断玩家是否准备就绪以开始生成光球
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
                    //Debug.Log("Right");
                    _thePlayer.NextAss();
                    break;
                case >= 45 and <= 135:
                    // Up
                    _thePlayer.LastThorn();
                    break;
                case >= -135 and <= -45:
                    // Down
                    _thePlayer.NextThorn();
                    break;
                default:
                    // Left
                    _thePlayer.LastAss();
                    break;
            }

            canSelect = false;
        }

        public void Confirm(InputAction.CallbackContext ctx)
        {
            GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerInput");
        }

        #endregion

        public void OnDeviceLost(PlayerInput playerInput) => Destroy(gameObject);
    }
}