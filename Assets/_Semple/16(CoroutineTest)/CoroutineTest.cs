using System.Collections;
using UnityEngine;

namespace Sample
{
    public class CoroutineTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(CoroutineTestSample());
        }

        IEnumerator CoroutineTestSample()
        {
            Debug.Log("3초 후에 시작됩니다!!");

            yield return new WaitForSeconds(3f);

            Debug.Log("방송 시작");
        }
    }

}
