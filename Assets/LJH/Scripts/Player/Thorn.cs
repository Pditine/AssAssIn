using System;
using LJH.Scripts.Collide;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LJH.Scripts.Player
{
    public class Thorn : ColliderBase
    {
        [SerializeField] private PlayerController thePlayer;
        public PlayerController ThePlayer => thePlayer;

        private void Start()
        {
            CollisionEvent += HandleVibration;
        }

        private void HandleVibration()
        {
            var theGamepad = thePlayer.TheInput.devices[0] as Gamepad;
            if (theGamepad==null) return;
            theGamepad.SetMotorSpeeds(0.5f,0.5f);
            DelayUtility.Delay(0.3f,() =>
            {
                theGamepad.ResetHaptics();
            });
        }
    }
    

}