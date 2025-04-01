using UnityEngine;

namespace Sample
{
    struct CBox
    {
        public float x; //x좌표
        public float y; //y좌표
        public float w; //width
        public float h; //height
    }

    struct CCircle
    {
        public float x;
        public float y;
        public float r;
    }

    public class HitTest : MonoBehaviour
    {
        //필드
        #region Field
        //타겟 오브젝트
        public Transform target;
        //이동 속도
        public float moveSpeed = 100f;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //매개변수로 받은 두 개의 box가 충돌하였는지 확인
        //충돌하면 true, 아니라면 false
        private bool CheckHitBox(CBox a, CBox b)
        {
            float dx = (a.x > b.x) ? a.x - b.x : b.x - a.x;
            float dy = (a.y > b.y) ? a.y - b.y : b.y - a.y;

            if (dx <= (a.w / 2 + b.w / 2) && dy <= (a.h / 2 + b.h / 2))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        //매개변수로 받은 두 개의 circle이 충돌했는지 체크
        //충돌하면 true 반환, 충돌하지 않았으면 false 반환
        private bool CheckHitCircle(CCircle a, CCircle b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;

            //두 원의 거리는
            //float distance = Mathf.Sqrt(dx * dx + dy * dy);
            float distanceS = dx * dx + dy * dy;

            //두 원의 거리보다 두 원의 반지름의 합이 더 크면 
            if (distanceS <= (a.r + b.r) * (a.r + b.r))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //두 지점의 거리가 일정거리(0.5f) 안에 있으면 충돌이라고 판정
        private bool CheckArrivePosition()
        {
            float distance = Vector3.Distance(target.position, this.transform.position);

            if(distance < 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //타겟으로 이동할 때 타겟까지 남은거리가 한 프레임에 이동하는 거리보다 작을 때 충돌이라고 함
        private bool CheckPassPosition()
        {
            //타겟까지 남은거리
            float distance = Vector3.Distance(target.position, this.transform.position);

            //이번 프레임에 이동하는 거리
            //dir.normalized * Time.deltaTime * moveSpeed;
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (distance <= distanceThisFrame)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
