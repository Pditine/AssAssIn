using System.Collections;
using Cinemachine;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.Events;

namespace LJH.Scripts.Utility
{
    public class CameraMoveUtility : SingletonMono<CameraMoveUtility>
    {
        public static void MoveAndZoom(Vector3 targetPos,float zoomRate,float orthographicSize,UnityAction callBack = null)
        {
            MonoSystem.Start_Coroutine(DoMoveAndZoom(targetPos,zoomRate,orthographicSize,callBack));
        }
        
        private static IEnumerator DoMoveAndZoom(Vector3 targetPos,float zoomRate,float orthographicSize,UnityAction callBack = null)
        {
            var main = Camera.main;
            var mainTransform = main.transform;
            if (mainTransform)
            {
                while (Vector2.SqrMagnitude(targetPos - main.transform.position) > 0.03f && main)
                {
                    yield return new WaitForSecondsRealtime(0.01f);

                    mainTransform.position = Vector2.Lerp(main.transform.position, targetPos, zoomRate);
                    main.orthographicSize = Mathf.Lerp(main.orthographicSize, orthographicSize, zoomRate);
                    mainTransform.position = new Vector3(mainTransform.position.x, mainTransform.position.y, -10);
                }

                mainTransform.position = targetPos;
                main.orthographicSize = orthographicSize;
                mainTransform.position = new Vector3(mainTransform.position.x, mainTransform.position.y, -10);
                callBack?.Invoke();
            }
        }
        
        public static void MoveAndZoom(CinemachineVirtualCamera camera,Vector3 targetPos,float zoomRate,float orthographicSize,UnityAction callBack = null)
        {
            MonoSystem.Start_Coroutine(DoMoveAndZoom(camera,targetPos,zoomRate,orthographicSize,callBack));
        }
        
        private static IEnumerator DoMoveAndZoom(CinemachineVirtualCamera camera,Vector3 targetPos,float zoomRate,float orthographicSize,UnityAction callBack = null)
        {
            var mainTransform = camera.transform;
            if (mainTransform)
            {
                while (Vector2.SqrMagnitude(targetPos - camera.transform.position) > 0.03f && camera)
                {
                    yield return new WaitForSecondsRealtime(0.01f);

                    mainTransform.position = Vector2.Lerp(camera.transform.position, targetPos, zoomRate);
                    camera.m_Lens.OrthographicSize = Mathf.Lerp(camera.m_Lens.OrthographicSize, orthographicSize, zoomRate);
                    mainTransform.position = new Vector3(mainTransform.position.x, mainTransform.position.y, -10);
                }

                mainTransform.position = targetPos;
                camera.m_Lens.OrthographicSize = orthographicSize;
                mainTransform.position = new Vector3(mainTransform.position.x, mainTransform.position.y, -10);
                callBack?.Invoke();
            }
        }
        
        public static void UIMoveAndZoom(RectTransform canvas,Vector3 targetPos, float moveSpeed, float zoomSpeed,
            UnityAction callBack = null)
        {
            MonoSystem.Start_Coroutine(DoUIMoveAndZoom(canvas,targetPos,moveSpeed,zoomSpeed,callBack));
        }

        private static IEnumerator DoUIMoveAndZoom(RectTransform canvas,Vector3 targetPos, float moveSpeed, float zoomSpeed,
            UnityAction callBack = null)
        {
            while (canvas&&Vector3.SqrMagnitude(canvas.position-Vector3.zero)>1f)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                var direction = (Vector3.zero-targetPos).normalized;
                if(canvas)
                {
                    canvas.position += direction * moveSpeed;
                    canvas.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
                }
            }
            callBack?.Invoke();
        }
        
    }
}