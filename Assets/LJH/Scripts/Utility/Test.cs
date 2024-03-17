using System;
using LJH.Scripts.Player;
using UnityEngine;

namespace LJH.Scripts.Utility
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
                _playerController.ChangeThorn(1);
        }
    }
}