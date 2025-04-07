using UnityEngine;
namespace MyDefence
{
    //타워 부모 클래스 - 타워 기본 기능
    public class Tower : MonoBehaviour
    {
        #region Field
        //공격 범위
        public float attackRange = 7f;
        //가장 가까운 적
        private Transform target;
        //타이머 구현
        private float updateTimer = 0.5f;   //몇 초 마다 실행시킬건지
        private float countdown = 0f;    //countdown

        //Enemy tag
        public string enemyTag = "Enemy";

        //turret Head
        public Transform partToRotate;
        public float turnSpeed = 0.5f;

        //shoot
        public float shootTimer = 1f;
        private float shootCountdown = 0f;

        //bullet
        public GameObject bulletPrefab;
        public Transform firePoint;
        #endregion


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //UpdateTarget 함수를 즉시 0.5초 마다 반복해서 호출한다
            //InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
        //가장 가까운 적 찾기
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            //최소거리 구하고 가 최소거리의 해당하는 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;

            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        void Update()
        {
            //0.5초마다 함수 실행시키기 코드(타이머 구현)
            countdown += Time.deltaTime;
            if (countdown >= updateTimer)
            {
                //가장 가까운 적 찾기
                UpdateTarget();
                //타이머 초기화
                countdown = 0f;
            }

            if (target == null)
            {
                return;
            }
            //터렛 조준
            LockOn();

            //1초마다 shoot 출력 시켜주는 타이머 구현
            shootCountdown += Time.deltaTime;
            if (shootCountdown >= shootTimer)
            {
                //shoot 함수 실행
                Shoot();
                //타이머 초기화
                shootCountdown = 0f;
            }
        }
        //탄환 발사
        private void Shoot()
        {
            //Debug.Log("Shoot!!!!");
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target);
            }
        }

        void LockOn()
        {
            //터렛 헤드 회전
            Vector3 dir = target.position - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Quaternion lookRotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, Time.deltaTime * turnSpeed);
            Vector3 eulerRotation = lookRotation.eulerAngles;   //4자리에 3자리 구하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
    }

}
