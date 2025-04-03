using UnityEngine;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //2) 스크립트의 필드 선언부에서 Transform,GameObject 인스턴스(객체)를 public으로 만들고 Inspector 창에서 직접 연결한다
        public Transform publicTransform;
        public GameObject publicObject;

        //3) 게임오브젝트의 tag를 이용하여 GameObject의 객체(인스턴스) 가져오기
        private GameObject[] tagObjects;
        private GameObject tagObject;

        //4) 프리팹 게임오브젝트 생성시 Instantiate 함수의 반환값으로 GameObject의 객체 가져오기
        public GameObject gameObjectPrefab;

        //5) 같은 종류, 기능들로 묶어서 게임 오브젝트의 객체(인스턴스) 가져오기
        //  부모 게임오브젝트를 만들어 묶은 다음 부모 오브젝트의 접근하여 자식 오브젝트들의 객체를 가져오기
        public Transform parentObject;
        private Transform[] childObjects;

        //6) static, 싱글톤 패턴 디자인으로 게임 오브젝트들의 객체(인스턴스) 가져오기
        private SingletonTest singletonTest;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            /*
            1) 게임오브젝트에 스크립트 소스를 컴포넌트를 추가하여 직접(this.~~) 가져온다
            this.transform
            this.gameObject
            */

            /*
            2)
            publicTransform
            publicObject
            */

            /*//3)FindGameObject를 사용하여 ()안에 들어가있는 태그의 GameObject를 가져온다
            tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
            tagObject = GameObject.FindGameObjectWithTag("Enemy");*/

            //4)Instantiate(프리팹 오브젝트, 생성위치, 생성회전값)의 반환값으로 GameObject 객체를 가져옴
            //Instantiate(gameObjectPrefab,this.transform.position , Quaternion.identity);

            /*//5) parentObject.childCount, parentObject.GetChild() 반환값으로 자식 게임오브젝트들의 객체를 가져온다
            childObjects = new Transform[parentObject.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = parentObject.GetChild(i);
            }*/

            //6)클래스이름.객체이름 으로 접근하여 사용
            //SingletonTest.Instance.number = 10;

            //singletonTest = SingletonTest.Instance;
            //singletonTest.number = 10;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }

}

/*
(하이라키창에 있는)게임오브젝트의 gameObject, transform에 접근하는 방법
게임 오브젝트의 GameObject, Trnasform 클래스의 객체를 가져오는 방법

1) 게임오브젝트에 스크립트 소스를 컴포넌트를 추가하여 직접(this.~~) 가져온다
2) 스크립트의 필드 선언부에서 Transform,GameObject 인스턴스(객체)를 public으로 만들고 Inspector 창에서 직접 연결한다
3) FindGameObject를 사용하여 ()안에 들어가있는 태그의 GameObject를 가져온다 - FindGameObjectsWithTag(), FindGameObjectWithTag() 을 사용하여 반환값 가져오기
4)
5)
6)static : 싱글톤 패턴 디자인을 이용하여 게임 오브젝트 객체(인스턴스 가져오기)
    클래스이름.인스턴스이름
*/