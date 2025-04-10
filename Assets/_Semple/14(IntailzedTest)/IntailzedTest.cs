using UnityEngine;

public class IntailzedTest : MonoBehaviour
{
    [SerializeField]private int number = 50;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //start 함수에서 초기화
        number = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(number);
    }
}

/*
//필드 초기화 저장 순서
1.필드 선언부에서 초기화된 값을 가져와서 저장
2.인스펙터창에 입력된 값을 가져와서 저장
3.start 함수에서 초기화된 값을 가져와 저장
*/