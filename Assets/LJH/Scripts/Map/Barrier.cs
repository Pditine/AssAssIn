﻿using System;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace LJH.Scripts.Map
{
    public class Barrier : MonoBehaviour
    {
        [HideInInspector]public float CurrentSpeed;
        [SerializeField] private float friction;
        [SerializeField] private float rotateSpeed;
        [HideInInspector]public Vector2 Direction;
        public MMF_Player collideWithBoundary;

        private void Start()
        {
            Direction = transform.right;
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3)Direction*(CurrentSpeed*Time.deltaTime);
            if(CurrentSpeed>0)
                transform.right = Vector3.Lerp(transform.right, Direction, rotateSpeed);
        }

        private void Update()
        {
            ReduceSpeed();
        }

        private void ReduceSpeed()
        {
            CurrentSpeed -= friction*Time.deltaTime;
            if (CurrentSpeed <= 0) CurrentSpeed = 0;
        }
    }
}