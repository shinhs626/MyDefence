using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        #region Field
        public TextMeshProUGUI roundText;
        #endregion

        private void OnEnable()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }

        public void RetryButton()
        {
            Debug.Log("Retry");
            SceneManager.LoadScene("PlayScene");
        }

        public void MenuButton()
        {
            Debug.Log("Go to Menu");
        }
    }

}
