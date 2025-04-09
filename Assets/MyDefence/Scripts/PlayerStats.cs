using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        public static int money = 400;

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
            
        }

        public static void AddMoney(int amount)
        {
            money += amount;
        }
        public static bool UseMoney(int amount)
        {
            if(money < amount)
            {
                Debug.Log($"소지금이 부족합니다. 현재 소지금 : {money}");
                return false;
            }
            money -= amount; 
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
