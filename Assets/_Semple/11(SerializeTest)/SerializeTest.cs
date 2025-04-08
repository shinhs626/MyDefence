using UnityEngine;

namespace Sample
{
    public class SerializeTest : MonoBehaviour
    {
        #region Field
        public int number = 10;

        [SerializeField]
        //private string name = "abc";

        //private string namee = "홍길동";
        public TestStruct testStruct;

        public Transform target;

        public GameObject prefabTest;
        #endregion
    }

}
