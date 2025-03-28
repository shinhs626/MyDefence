using System.Collections;
using UnityEngine;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        //타일 프리팹
        public GameObject tilePrefab;

        public int  row = 0;
        public int column = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //
            //BlankSquare();

            //[2] n(10) x m(10) 생성 - 5x5, 7x7
            //GenerateMap(row,column);
            //GenerateMap2(row, column);

            //[3] 타일을 생성 - x좌표를 0~500사이의 랜덤값, y = 0, z 좌표를 0~500사이의 랜덤값
            /*for (int i = 0; i < 30; i++)
            {
                GenerateRandomMapTile();
            }*/

            //[4] 타일을 10개 찍는다, 타일 하나 생성할 때 마다 딜레이 0.2초 준다
            //코루틴(Coroutine) - 지연 함수
            StartCoroutine(GenerateRandomMap());

        }

        void Update()
        {

        }
        void GenerateMap(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0, j * -5f);    //생성할 위치
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }
        }
        void GenerateMap2()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    GameObject go = Instantiate(tilePrefab, this.transform);
                    go.transform.position = new Vector3(j * 5f, 0, i * -5f);
                }
            }
        }
        void GenerateRandomMapTile()
        {
            float xPos = Random.Range(0f, 500f);
            float zPos = Random.Range(-500f,0f);
            Vector3 position = new Vector3(xPos, 0f, zPos);
            Instantiate(tilePrefab, position, Quaternion.identity);
        }

        IEnumerator GenerateRandomMap()
        {
            for (int i = 0; i < row; i++)
            {
                Vector3 position = new Vector3(Random.Range(0,50f), 0f, Random.Range(-50f, 0));
                Instantiate(tilePrefab, position, Quaternion.identity);

                //0.2초 딜레이
                yield return new WaitForSeconds(0.2f);
            }
        }





        void BlankSquare()
        {
            #region
            for (int i = 0; i < 34; i++)
            {
                Vector3 position = new Vector3(i, 0, 0);    //생성할 위치
                Instantiate(tilePrefab, position, Quaternion.identity);
                if (i == 33)
                {
                    for (int j = 0; j < 34; j++)
                    {
                        position = new Vector3(i, 0, j);    //생성할 위치
                        Instantiate(tilePrefab, position, Quaternion.identity);
                        if (j == 33 && i == 33)
                        {
                            for (int p = 0; p < 34; p++)
                            {
                                position = new Vector3(i - p, 0, j);    //생성할 위치
                                Instantiate(tilePrefab, position, Quaternion.identity);
                                if (p == 33)
                                {
                                    for (int q = 0; q < 34; q++)
                                    {
                                        position = new Vector3(i - p, 0, j - q);    //생성할 위치
                                        Instantiate(tilePrefab, position, Quaternion.identity);
                                    }
                                }
                            }
                        }
                    }

                }
                #endregion
            }
        }
    }
}
/*
타일을 10x10으로 배치

*/