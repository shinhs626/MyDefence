using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    //씬 시작시 페이드인, 씬 종료시 페이드 아웃 효과 구현
    public class SceneFader : MonoBehaviour
    {
        #region Field
        //페이더 이미지
        public Image img;

        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            StartCoroutine(FadeIn());
            //StartCoroutine(FadeOut());
        }

        //코루틴으로 구현
        //FadeIn : 1초 동안 : 페이드 인(이미지 알파값 a:1 -> a:0)
        IEnumerator FadeIn()
        {
            float inTime = 1f;

            while (inTime > 0)
            {
                inTime -= Time.deltaTime;
                float a = curve.Evaluate(inTime);
                img.color = new Color(0f, 0f, 0f, inTime);

                yield return null;
            }
        }

        //FadeOut : 1초 동안 : 페이드 아웃(이미지 알파값 a:0 -> a:1)
        IEnumerator FadeOut()
        {
            float outTime = 0f;

            while (outTime < 1)
            {
                outTime += Time.deltaTime;
                float a = curve.Evaluate(outTime);
                img.color = new Color(0f, 0f, 0f, outTime);

                yield return null;
            }
        }
        //다른 씬으로 이동시 FadeOut 효과 후 LoadScene 으로 이동
        //FadeOut 효과 후 매개변수로 받은 씬으로 이동
        IEnumerator FadeOut(string sceneName)
        {
            float outTime = 0f;

            while (outTime < 1)
            {
                outTime += Time.deltaTime;
                float a = curve.Evaluate(outTime);
                img.color = new Color(0f, 0f, 0f, outTime);

                yield return null;
            }

            SceneManager.LoadScene(sceneName);
        }
        //다른 씬으로 이동시 호출
        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
            
        }
    }

}
