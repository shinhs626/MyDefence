using UnityEngine;

namespace Sample
{
    //타겟으로 이동한다
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Field
        //이동 속도
        public float moveSpeed = 5f;

        //타겟으로 이동하기 위해서는 타겟 오브젝트의 transform 정보가 필요
        //public Transform target;
        public Transform target;

        //타겟 오브젝트에 붙어 있는 TargetTest라는 컴포넌트(스크립트)의 객체를 GetComponent로 가져오기
        //private TargetTest targetTest;

        //타겟 오브젝트에 붙어 있는 TargetTest라는 컴포넌트(스크립트)의 객체를 GetComponent로 가져오기
        public TargetTest targetTest;

        //자신 오브젝트에 붙어 있는 TargetTest라는 컴포넌트(스크립트)의 객체를 GetComponent로 가져오기
        private MyTest myTest;
        //public MyTest myTest
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            //targetTest = target.GetComponent<TargetTest>();
            //targetTest.SetA(30);
            //Debug.Log(targetTest.GetA());

            myTest = this.transform.GetComponent<MyTest>();     //둘이 똑같음
            myTest = this.GetComponent<MyTest>();               //둘이 똑같음
            myTest.SetA(30);
            Debug.Log(myTest.GetA());
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }
    }
}

/*

*/