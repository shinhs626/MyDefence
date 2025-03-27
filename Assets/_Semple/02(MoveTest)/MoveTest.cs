using UnityEngine;

namespace Sample
{
    public class MoveTest : MonoBehaviour
    {
        //필드
        //이동속도
        //private float speed = 5f;

        //이동 목표 설정
        //Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Transform transform = new Transform();    //unity에서 해줌 가져다 쓰기만 하면 됨

            //this.transform : MoveTest 클래스가 붙어 있는 게임 오브젝트의 Transform 인스턴스
            //transform.position = new Vector3(7f, 1f, 8f);
            //this.transform.position = targetPosition;

            //Debug.Log(this.transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 이동하라
            //this.transform.position.z = this.transform.position.z + 1;

            //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);    //앞

            //뒤, 좌, 우, 위, 아래
            //this.transform.position = this.transform.position + new Vector3(0f, 0f, -1f);   //뒤
            //this.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);    //위
            //this.transform.position = this.transform.position + new Vector3(0f, -1f, 0f);   //아래
            //this.transform.position = this.transform.position + new Vector3(1f, 0f, 0f);    //우
            //this.transform.position = this.transform.position + new Vector3(-1f, 0f, 0f);   //좌

            //this.transform.position += Vector3.forward;
            //this.transform.position += Vector3.right;

            //속도
            //앞 방향으로 1초에 1unit 만큼 이동
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 1;
            //앞 방향으로 1초에 5unit 만큼 이동
            //this.transform.position += Vector3.forward * Time.deltaTime * 5;

            //Translate : 이동 함수
            //방향 : 앞
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            //speed : 이동속도 - 초당 이동하는 거리
            //Vector3 * float * float => Vector3
            //this.transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //이동 방향 구하기 : (목표위치 - 현재위치), (목표위치 - 현재위치).normalized
            //dir.margnitude : 벡터의 크기, 길이
            //dir.normalized : 길이가 1인 벡터, 정규화된 벡터, 단위벡터
            //Vector3 dir = targetPosition - this.transform.position;
            //transform.Translate(dir.normalized * Time.deltaTime * speed);

            //Space.World, Space.Self
            //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
    }

}

/*
1. 앞, 뒤, 좌, 우 로 이동하기
2. 5의 속도로 이동하기
3. 목표지점(7, 1, 8)으로 이동하기
4. 목표지점 도착 판정

1 unit
*/

/*
n 프레임 : 초당 n번 실행하기(보여주기)
20프레임 : 1프레임 보여주는데 0.05초 걸린다
FPS : 1초에 (실행) 보여주는데 프레임 갯수

// unity
1 Frame
Time.deltaTime : 1프레임을 실행하는데 걸리는 시간

초당 20만큼 이동
speed = 20;

PC1 : 성능이 좋은 컴
10프레임 - 1초 10만큼 이동

Time.deltaTime 값 : 0.1f

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;

PC2 : 성능이 나쁜 컴
2프레임 - 1초 2만큼 이동

Time.deltaTime 값 : 0.5f

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 20;

방향 * speed * Time.deltaTime
*/