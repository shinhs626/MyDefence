using UnityEngine;

namespace Sample
{
    public class PlayerTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //static 멤버 변수 사용하기
            //StaticTest.number = 10;
            //Debug.Log(StaticTest.number);

            //싱글톤 패턴 클래스 인스턴스 생성(호출, 접근)
            //SingleTon singleTon = new SingleTon();    //x
            //Debug.Log(singleTon);
            var singletonA = SingleTon.Instance;
            var singletonB = SingleTon.Instance;
            if(singletonA == singletonB)
            {
                Debug.Log(singletonA.ToString());
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
