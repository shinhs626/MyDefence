using UnityEngine;

namespace Sample
{
    public class ObjectTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // this.transform : 
            // ObjectTest 가 붙어있는 게임 오브젝트의 Transform의 인스턴스(객체)
            Debug.Log(this.transform.ToString());

            // this.gameObject : 
            // ObjectTest 가 붙어있는 게임 오브젝트의 gameObject의 인스턴스(객체)
            Debug.Log(this.gameObject.ToString());

            //this.transform.gameObject == this.gameObject
            //this.gameObject.transform == this.transform
        }
    }

}
