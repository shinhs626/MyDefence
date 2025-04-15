using UnityEngine;

namespace MyDefence
{
    //게임의 전체 흐름을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Field
        //치트 체크
        [SerializeField] private bool isCheat = false;

        public GameObject gameOverUI;

        private static bool isGameOver = false;
        #endregion

        #region Property
        public static bool IsGameOver
        {
            get { return isGameOver; }
        }
        #endregion
        private void Start()
        {
            //초기화
            isGameOver = false;

        }
        private void Update()
        {
            //GameOver Check
            if (IsGameOver)
                return;

            if (PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }

            if (Input.GetKeyDown(KeyCode.O) && isCheat == true)
            {
                GameOver();
            }
        }

        //Cheating
        //M키를 누르면 10만 에너지 지급
        void ShowMeTheMoney()
        {
            if (isCheat == false)
                return;
            PlayerStats.AddMoney(100000);
        }
        void GameOver()
        {
            /* if (gameOver.activeSelf == false)
             {
                 gameOver.SetActive(true);
             }
             else
             {
                 gameOver.SetActive(false);
             }*/
            isGameOver = true;
            gameOverUI.SetActive(true);
        }
        //레벨 치트
        void LevelUpCheat()
        {
            //PlayerStats.LevelUP(100);
        }
    }

}
