using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class Title : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        public GameObject AnyKeyText;
        private bool isSceneChanging = false;
        #endregion

        public void Start()
        {
            //3초후 AnyKey 함수를 실행하라는 코드
            Invoke("ShowAnyKeyText", 3f);
        }
        public void Update()
        {
            if (AnyKeyText.activeSelf && Input.anyKeyDown)
            {
                isSceneChanging = true;
                fader.FadeTo(loadToScene);
            }

        }
        public void ShowAnyKeyText()
        {
            if (AnyKeyText != null)
            {
                AnyKeyText.SetActive(true);
                StartCoroutine(AutoLoadNextScene());
            }
        }

        IEnumerator AutoLoadNextScene()
        {
            yield return new WaitForSeconds(10f);

            if (!isSceneChanging)
            {
                isSceneChanging = true;
                fader.FadeTo(loadToScene);
            }
        }
    }
}
