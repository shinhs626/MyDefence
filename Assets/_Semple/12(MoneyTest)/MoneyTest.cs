using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    //골드를 관리하는 클래스
    public class MoneyTest : MonoBehaviour
    {
        #region Field
        //소지금
        private int gold;

        [SerializeField]
        private int startGold = 1000;

        public TextMeshProUGUI goldText;

        public Button button1000;
        public Button button9000;
        #endregion
        private void Start()
        {
            //초기화 - 게임 시작시 startGold 1000 Gold 지급
            gold = startGold;
        }

        private void Update()
        {
            UpdateGold();
            //아이템 구매가 가능하면 버튼 이미지는 white,
            //소지금이 부족하여 구매가 불가능하면 버튼 이미지는 red,
            if (CheckGold(1000))
            {
                button1000.interactable = true;
                button1000.image.color = Color.white;
            }
            else
            {
                button1000.interactable = false;
                button1000.image.color = Color.red;
            }
            if (CheckGold(9000))
            {
                button9000.interactable = true;
                button9000.image.color = Color.white;
            }
            else
            {
                button9000.interactable = false;
                button9000.image.color = Color.red;
            }
        }

        public void UpdateGold()
        {
            goldText.text = gold.ToString() + "Gold";
        }

        //Gold를 연산하는 함수
        //돈을 번다 : 사냥, 퀘스트 클리어, 캐쉬 구매, 이벤트 보상....
        public void AddGold(int amount)
        {
            gold += amount;
        }
        //돈을 쓴다 : 아이템 구매, 기구 사용...
        public bool UseGold(int amount)
        {
            if (gold < amount)
            {
                return false;
            }
            gold -= amount;
            return true;
        }
        //소지금 체크 : amount 만큼 소지금을 가지고 있는지
        public bool CheckGold(int amount)
        {
            if (gold < amount)
            {
                return false;
            }
            return true;
        }

        //버튼 3개 클릭시 호출되는 함수 3개 만들고 각 버튼에 연결하세요
        //버튼 클릭시 Gold 계산하고 출력하세요
        public void SaveButton()
        {
            AddGold(1000);
            Debug.Log($"현재 소지금 : {gold}");
        }
        public void ItemButtonOne()
        {
            if (UseGold(1000) == true)
            {
                Debug.Log($"현재 소지금 : {gold}");
            }
        }
        public void ItemButtonTwo()
        {
            if (UseGold(9000) == true)
            {
                Debug.Log($"현재 소지금 : {gold}");
            }
        }
    }

}

/*
MoneyTest

1. 시작하면 소지금을 1000원 지급
2. 화면 상단에 소지금 표시 (1000 Gold)
3. 버튼 3개
1) 저축 버튼 : 1000원 저축, 버튼 클릭시 +1000, Debug.Log("1000 Gold Save);
2) 구매 버튼 : 1000원 아이템 구매, 버튼 클릭시 -1000, Debug.Log("1000 Gold Purchase);
3) 구매 버튼 : 9000원 아이템 구매, 버튼 클릭시 -9000, Debug.Log("9000 Gold Purchase);

구매 버튼 : 아이템 구매가 가능하면 버튼 이미지는 white,
            소지금이 부족하여 구매가 불가능하면 버튼 이미지는 red,
            구매가 불가능하면 구매버튼을 클릭해도 구매가 불가능해야 한다
*/