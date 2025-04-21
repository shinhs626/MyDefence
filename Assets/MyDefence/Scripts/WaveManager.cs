using System.Collections;
using UnityEngine;
using TMPro;

namespace MyDefence
{
    //Enemy 스폰/웨이브를 관리하는 스크립트
    public class WaveManager : MonoBehaviour
    {
        #region Field
        //현재 게임 화면에서 살아있는 enemy 숫자
        public static int enemyAlive = 0;

        //웨이브 데이터 셋팅
        public Wave[] waves;

        //적 프리팹
        public GameObject enemyPrefab;
        //적 스폰위치
        public Transform startPoint;
        //private Transform startPoint;

        //타이머
        public float waveTimer = 5f;
        private float countdown;

        private int waveCount = 0;

        //UI Countdown Text
        public TextMeshProUGUI countdownText;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            countdown = 3f;
            waveCount = 0;
            enemyAlive = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //현재 맵에 enemy가 있는지 여부 체크
            if (enemyAlive > 0) 
                return;

            //타이머 구현
            countdown += Time.deltaTime;
            if(countdown >= waveTimer)
            {
                StartCoroutine(SpawnWave());
                //타이머 초기화
                countdown = 0f;
               
            }

            //UI
            countdownText.text = Mathf.Round(countdown).ToString();
        }

        IEnumerator SpawnWave()
        {
            waveCount++;

            PlayerStats.Rounds++;

            for (int i = 0; i < waveCount; i++)
            {
                //타이머 기능
                SpawnEnemy();

                yield return new WaitForSeconds(0.4f);
            }
        }
        void SpawnEnemy()
        {
            //WayPoint 스크립트에서 static으로 만든 Transform을 사용해 불러오기
            //int wayPointIndex = 0;
            //startPoint = WayPoints.wayPoints[wayPointIndex];

            enemyAlive++;
            //시작 지점에 enemy 한마리 스폰
            Instantiate(enemyPrefab, startPoint.transform.position, Quaternion.identity);
        }

    }

}
