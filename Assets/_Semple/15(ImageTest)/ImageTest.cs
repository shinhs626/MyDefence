using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        #region Field
        public Button skillButton;
        public Image skillButtonImage;

        public float skillCoolTime = 5f;
        private float countdown;

        //쿨타임 체크
        private bool isCharge = false;
        #endregion

        public void Update()
        {
            if (isCharge)
                return;

            countdown += Time.deltaTime;
            if(countdown >= skillCoolTime)
            {
                SkillButton();

                countdown = 0f;
                isCharge = true;
            }

            //countdown : 0 -> 5, fillamunt 0->1 ,소수점, 분수
            //백분율 : (현재값량) / (총값량)
            skillButtonImage.fillAmount = countdown / skillCoolTime;
        }

        public void SkillButton()
        {
            Debug.Log("skill use");
            if(skillButton.interactable == false)
            {
                skillButton.interactable = true;
            }
            else
            {
                skillButton.interactable = false;
            }
            isCharge = false;
        }
    }

}
