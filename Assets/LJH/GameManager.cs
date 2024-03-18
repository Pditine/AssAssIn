using Cinemachine;
using LJH.Scripts.Utility;
using PurpleFlowerCore;
using PurpleFlowerCore.Event;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LJH
{
    public class GameManager : SingletonMono<GameManager>
    {
        [SerializeField] private Image blackCurtain;

        [SerializeField] private CinemachineVirtualCamera camera;
        [SerializeField] private Text playerDeadInfo;
        

        private void Start()
        {
            FadeUtility.FadeOut(blackCurtain,80);
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            EventSystem.AddEventListener("GameOver", GameOver);
            EventSystem.AddEventListener("GameStart", GameStart);
            
        }

        private void OnDisable()
        {
            EventSystem.RemoveEventListener("GameOver", GameOver);
            EventSystem.RemoveEventListener("GameStart", GameStart);
        }

        private void GameOver()
        {
            Time.timeScale = 0.3f;
            FadeUtility.FadeInAndStay(
                blackCurtain,
                45,
                () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        }

        private void GameStart()
        {
            
        }

        public void PlayerDead(Vector3 position,int playerIndex)
        {
            CameraMoveUtility.MoveAndZoom(camera, position, 0.03f, 4);
            FadeUtility.FadeInAndStay(playerDeadInfo,80);
            playerDeadInfo.text = $"Player{playerIndex + 1} Died";
        }
    }
}
