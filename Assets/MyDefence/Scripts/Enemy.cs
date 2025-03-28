using UnityEngine;

namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        //필드
        #region Field
        //속도
        public float speed = 4f;

        //waypoint 오브젝트의 트랜스폼 객체
        private Transform target;
        //waypoint 배열의 인덱스
        private int wayPointIndex = 0;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            // 이동 구현
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

            // target 도착 판정 확인
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.1f)
            {
                // 다음 타겟 셋팅
                GetNextTarget();
            }
        }
        //다음 타겟포지션 얻어오기
        void GetNextTarget()
        {
            if(wayPointIndex == WayPoints.wayPoints.Length - 1)
            {
                Debug.Log($"종점 도착");
                Destroy(this.gameObject);
                return;
            }
            wayPointIndex++;
            target = WayPoints.wayPoints[wayPointIndex];
        }
    }

}
