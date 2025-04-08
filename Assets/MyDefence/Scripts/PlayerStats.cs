using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        private static int money;

        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        #endregion

        //소지금 초기값 400
        public void Start()
        {
            money += 400;
        }

        public static void AddMoney(int amount)
        {
            money += amount;
        }
        public static bool UseMoney(int amount)
        {
            if(money < amount)
            {
                return false;
            }
            money += amount; 
            return true;
        }
        public static bool CheckMoney(int amount)
        {
            if (money < amount)
            {
                return false;
            }
            return true;
        }
    }

}
