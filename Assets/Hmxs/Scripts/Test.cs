using UnityEngine;
using UnityEngine.InputSystem;

namespace Hmxs.Scripts
{
    public class Test : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.actions["Act"].performed += _ =>
            {
                Debug.Log("Act" + name);
            };
        }


    }
}