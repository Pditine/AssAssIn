using System;
using System.Collections.Generic;
using PurpleFlowerCore;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LJH.LightBall
{
    public class LightBallSpawner : MonoBehaviour
    {
        [SerializeField] private Transform leftUpPoint;
        [SerializeField] private Transform rightDownPoint;

        [SerializeField] private List<GameObject> lightBalls = new();

        private void Start()
        {
            var theProcess = ProcessSystem.CreateProcess("CreateLightBall_Loop",true);
            theProcess.Add(new WaitNode(4f)).Add(new ActionNode(CreateLightBall));
            theProcess.Start_();
        }

        private void CreateLightBall()
        {
            var theBall = PoolSystem.GetGameObject(lightBalls[Random.Range(0, lightBalls.Count)]).GetComponent<LightBallBase>();
            theBall.transform.position = new Vector3(
                Random.Range(leftUpPoint.transform.position.x, rightDownPoint.transform.position.x),
                Random.Range(rightDownPoint.transform.position.y, leftUpPoint.transform.position.y), 0);
            theBall.BeCreate();
        }
    }
}