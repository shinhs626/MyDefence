using UnityEngine;

namespace MyDefence
{
    //카메라를 제어하는 스크립트
    public class CameraController : MonoBehaviour
    {
        #region Field
        //카메라 이동속도
        public float moveSpeed = 10f;

        //카메라 스크롤 이동속도
        public float scrollSpeed = 3f;

        public float scrollMin = 10f;
        public float scrollMax = 40f;

        //카메라 컨트롤 제어 유무 ( true 이면 못움직임, false면 움직임)
        public bool isCannotMove = false;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            isCannotMove = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.IsGameOver)
                return;

            if (Input.GetKey(KeyCode.Escape))
            {
                isCannotMove = !isCannotMove;
            }

            //isCannotMove가 true이면 return 아래 코드를 실행하지 마라
            //if (isCannotMove)
            //    return;

            //W,A,S,D 키 ( 또는 키보드의 상하좌우 화살표 ) 값을 받아
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 포인터가 스크린 상단에 위치하면
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            float screenY = Screen.height;
            float screenX = Screen.width;

            // 위쪽 이동 (마우스가 화면 상단 근처에 위치)
            if (mouseY >= screenY - 10 && mouseY < Screen.height)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }

            // 아래쪽 이동 (마우스가 화면 하단 근처에 위치)
            if (mouseY <= 10 && mouseY > 0)
            {
                transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }

            // 왼쪽 이동 (마우스가 화면 좌측 근처에 위치)
            if (mouseX <= 10 && mouseX > 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }

            // 오른쪽 이동 (마우스가 화면 우측 근처에 위치)
            if (mouseX >= screenX - 10 && mouseX < Screen.width)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 휠을 스크롤하면 줌인, 줌아웃 한다
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 upMove = this.transform.position;
            upMove.y += (scroll * 1000) * Time.deltaTime * scrollSpeed;
            //(upMove.y : 10f이상, 40이하)
            upMove.y = Mathf.Clamp(upMove.y, scrollMin, scrollMax);
            this.transform.position = upMove;
        }
    }
}

