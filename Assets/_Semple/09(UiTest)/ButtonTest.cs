using UnityEngine;

namespace Sample
{
    public class ButtonTest : MonoBehaviour
    {
        //Fire 버튼 클릭시 (실행)호출되는 함수
        public void Fire()
        {
            Debug.Log("Fire 버튼을 눌렀습니다");
        }

        public void Jump()
        {
            Debug.Log("Jump 버튼을 눌렀습니다");
        }
    }

}
