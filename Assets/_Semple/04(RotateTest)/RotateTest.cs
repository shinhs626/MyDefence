using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Sample
{
    
    public class RotateTest : MonoBehaviour
    {
        //Field
        #region Field
        private float y;
        private float x;
        private float z;

        //회전 속도
        public float turnSpeed = 10f;
        //이동속도
        public float moveSpeed = 5f;

        //타겟 오브젝트의 transform
        public Transform targetTransform;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);      //x축
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);      //y축
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);      //z축

        }

        // Update is called once per frame
        void Update()
        {
            /*//y축 기준으로 +방향으로 회전하기
            y += turnSpeed * Time.deltaTime;        //무작정 turnSpeed만 넣는다면 1초당 1씩 5번 회전이 아니라 1초당 5씩 1번 회전 이동한다가 됨
            this.transform.rotation = Quaternion.Euler(0f, y, 0f);*/

            /*//x축 기준으로 +방향으로 회전하기
            x += 1;
            this.transform.rotation = Quaternion.Euler(x, 0f, 0f);*/

            /*//z축 기준으로 +방향으로 회전하기
            z += 1;
            this.transform.rotation = Quaternion.Euler(0f, 0f, z);*/

            //y축 기준으로 속도 5로 회전하기
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);

            //타겟 중심으로 회전하기
            //transform.RotateAround(targetTransform.transform.position, Vector3.up, 20 * Time.deltaTime);

            //타겟 방향으로 회전하기
            //Vector3 dir = targetTransform.position - this.transform.position;
            //방향 Vetor3로 부터 그쪽 방향을 바라보는 회전값 구하기
            //Quaternion targetRotation = Quaternion.LookRotation(-dir, Vector3.up);
            //transform.rotation = LookRotation;
            //Quaternion lookRotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed );
            //this.transform.rotation = lookRotation;

            //Y축 연산을 위해 Euler 값 얻어오기
            //Vector3 eulerRotation = lookRotation.eulerAngles;
            //Euler 값 으로 Quaternion 값 구하기
            //this.transform.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);

            //회전 + 이동
            Vector3 dir = targetTransform.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);      //회전
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);     //이동
            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);    //자기 기준으로 된 dir로 이동하기에 이상하게 이동함
        }
    }

}

/*
Quaternion(쿼터니온)
Euler(오일러)

[1] Euler(오일러)값으로 Quaternion(쿼터니온) 값 구하기
3자리에서 4자리 값 구하기
Quaternion(쿼터니온) 값 = Quaternion.Euler(Euler x, Euler y, Euler z)

[2] Quaternion 깂에서 Euler 값 구하기
4자리에서 3자리 값 구하기
var angles = Quaternion(transform.rotation).eulerAngles;
*/