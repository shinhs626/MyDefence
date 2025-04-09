using UnityEngine;

namespace MyDefence
{
    //타워 속성(데이터) 정의 직렬화 클래스
    [System.Serializable]   //이게 붙어있어 BuildMenu 스크립트에 저 아래있는 towerPrefab, cost를 연결가능함
    public class TowerBluePrint
    {
        public GameObject towerPrefab;  //타워 건설에 필요한 프리팹
        public int cost;                //타워 건설 비용
    }

}
