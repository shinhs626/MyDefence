using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        public TextMeshProUGUI roundText;
        #endregion

        private void OnEnable()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }

        public void RetryButton()
        {
            //해당(자기 자신) 씬을 다시 부른다
            fader.FadeTo(SceneManager.GetActiveScene().name);    //씬이름으로 로드
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //빌드 인덱스로 로드
        }

        public void MenuButton()
        {
            fader.FadeTo(loadToScene);
        }
    }

}
