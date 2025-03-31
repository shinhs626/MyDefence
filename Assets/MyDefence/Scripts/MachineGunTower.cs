using System.Threading;
using UnityEngine;

namespace MyDefence
{
    public class MachineGunTower : MonoBehaviour
    {
        #region Field
        //공격 범위
        public float attackRange = 7f;
        //가장 가까운 적
        private Transform target;
        //타이머 구현
        private float updateTimer = 0.5f;   //몇 초 마다 실행시킬건지
        private float countdown;    //countdown

        //Enemy tag
        public string enemyTag = "Enemy";
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //UpdateTarget 함수를 즉시 0.5초 마다 반복해서 호출한다
            //InvokeRepeating("UpdateTarget",0f, 0.5f);
        }
        //가장 가까운 적 찾기
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 구하고 가 최소거리의 해당하는 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;

            foreach(var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }
            if(nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy.transform;
            }
            else
            {
                target = null;
            }
            Debug.Log($"0.5{target}");
        }

        void Update()
        {
            //0.5초마다 함수 실행시키기 코드(타이머 구현)
            countdown += Time.deltaTime;
            if(countdown >= updateTimer)
            {
                //가장 가까운 적 찾기
                UpdateTarget();
                //타이머 초기화
                countdown = 0f;
            }
            

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
    }

}
