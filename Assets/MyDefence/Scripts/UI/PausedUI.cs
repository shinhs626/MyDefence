using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    //PausedUI 관리하는 클래스
    public class PausedUI : MonoBehaviour
    {
        #region Field
        public SceneFader fader;

        //UI 오브젝트
        public GameObject pausedUI;
        #endregion


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pausedUI.SetActive(!pausedUI.activeSelf);

            //창이 열리면
            if (pausedUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //창이 닫치면
            {
                Time.timeScale = 1f;
            }
        }
        public void Continue()
        {
            Toggle();  // 다시 게임 재개
        }

        public void Retry()
        {
            Time.timeScale = 1f;

            //해당(자기 자신) 씬을 다시 부른다
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);    //씬이름으로 로드
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}