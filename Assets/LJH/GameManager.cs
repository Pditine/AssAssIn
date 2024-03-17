using Hmxs.Toolkit.Flow.Timer;
using PurpleFlowerCore.Event;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LJH
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Image blackCurtain;

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
                30,
                () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        }

        private void GameStart()
        {
            
        }
    }
}
