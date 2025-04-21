using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        public void PlayGame()
        {
            Debug.Log("게임 시작");
            fader.FadeTo(loadToScene);
        }
        public void QuitGame()
        {
            Debug.Log("게임 나가기");
            Application.Quit();     //Unity에디터에서 명령 무시, 빌드버전에서는 구동
        }
    }

}
