using TMPro;
using UnityEngine;

namespace Sample
{
    //Old InputSystem 
    public class InputTest : MonoBehaviour
    {
        //UI Text
        public TextMeshProUGUI xText;
        public TextMeshProUGUI yText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //스크린
            Debug.Log($"{Screen.width}");
        }

        // Update is called once per frame
        void Update()
        {
            //GetKey(키값(wasd)
            if (Input.GetKey("w"))
            {
                Debug.Log("w");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("WWW");
            }

            //GetButton(버튼이름) - InputManager
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
            }

            //GetAxis(Axis이름) - InputManager

            //float hValue = Input.GetAxis("Horizontal");
            //Debug.Log(hValue);
            //a, left 화살표 버튼 : -1 ~ 0;

            //float hValue = Input.GetAxisRaw("Horizontal");

            //float vValue = Input.GetAxis("Vertical");

            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            //xText.text = "Mouse X :" + ((int)mouseX).ToString();
            //yText.text = "Mouse Y :" + ((int)mouseY).ToString();
            xText.text = ((int)mouseX).ToString() + "," + ((int)mouseY).ToString();
            xText.rectTransform.position = new Vector2(mouseX, mouseY);
        }
    }

}
/*
Old InputSystem
New InputSystem
*/