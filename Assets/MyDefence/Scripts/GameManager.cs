using UnityEngine;

namespace MyDefence
{
    //게임의 전체 흐름을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Field
        //치트 체크
        [SerializeField] private bool isCheat = false;
        #endregion

        private void Update()
        {
            //Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
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

        //레벨 치트
        void LevelUpCheat()
        {
            //PlayerStats.LevelUP(100);
        }
    }

}
