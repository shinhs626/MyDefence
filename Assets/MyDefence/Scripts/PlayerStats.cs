using UnityEngine;
using TMPro;

namespace MyDefence
{
    //플레이어의 속성들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        public static int money;

        [SerializeField] private int startMoney = 400;

        //Life
        public static int lives;

        //시작 Life
        [SerializeField]  private readonly int startLives = 10;

        public TextMeshProUGUI livesText;
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        public static int Lives
        {
            get { return lives ; }
        }
        //Round 카운트
        public static int Rounds { get; set; }
        #endregion

        //소지금 초기값 400
        public void Start()
        {
            money = startMoney;
            lives = startLives;
            Rounds = 0;
        }
        public void Update()
        {
            livesText.text = lives.ToString();
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

        public static void AddLife(int amount)
        {
            lives += amount;
        }
        public static bool UseLife(int amount)
        {
            lives -= amount;
            if (lives <= 0)
            {
                //게임 오버 UI활성화
                return false;
            }
            return true;
        }

        //public static void 
    }

}
