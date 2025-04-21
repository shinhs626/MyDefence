using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    //맵의 타일을 관리하는 클래스
    public class Tile : MonoBehaviour
    {
        #region Field
        //마우스를 올려놓으면 변하는 색
        //public Color hoverColor;
        //타일의 원래 색
        //public Color startColor;

        //타일의 원래 매트리얼 - 돈이 충분할 때
        private Material startMaterial;
        //타일의 원래 매트리얼 - 돈이 부족할 때
        public Material moneyMaterial;
        //바뀔 타일의 매트리얼
        public Material changeMaterial;
        //타워 설치된 후 이펙트
        public GameObject buildEffectPrefab;
        //타워 판매 후 이펙트
        public GameObject sellEffectPrefab;

        //타일의 Renderer
        private new Renderer renderer;

        private BuildManager buildManager;

        //타일에 설치한 타워 오브젝트
        private GameObject tower;

        //타일에 설치한 타워의 정보
        public TowerBluePrint bluePrint;

        #endregion

        #region Property
        //타워 업그레이드 여부
        public bool IsUpgrade
        {
            get;
            private set;
        }
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            startMaterial = renderer.material;
        }
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }

            // 현재 타일에 타워오브젝트가 설치되어있는지
            if (tower != null)
            {
                buildManager.SelectTile(this);
                return;
            }

            if (buildManager.CannotBuild)
            {
                Debug.Log("설치하실 터렛을 선택해주세요");
                return;
            }
            //타워 건설
            BuildTower();
        }
        void BuildTower()
        {
            if (buildManager.NotEnoughMoney)
                return;

            //건설된 타워의 정보를 저장
            bluePrint = buildManager.GetTowerToBuild();

            //건설할 타워의 정보를 저장
            PlayerStats.UseMoney(bluePrint.cost);

            //Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            tower = Instantiate(bluePrint.towerPrefab, this.transform.position, Quaternion.identity);

            //타워 건설 이펙트 실행 후 2초후 삭제
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //초기화 - 저장된 타워 프리팹 초기화
            buildManager.SetTowerToBuild(null);

            //건설하고 남은돈
            //Debug.Log($"현재 비용 : {PlayerStats.money}");
        }

        //타워 업그레이드
        public void UpgradeTower()
        {
            if (PlayerStats.CheckMoney(bluePrint.upgradeCost) == false || IsUpgrade == true)
            {
                return;
            }

            //건설할 타워의 정보를 저장
            PlayerStats.UseMoney(bluePrint.upgradeCost);

            //기존 설치된 타워 킬
            Destroy(tower);

            IsUpgrade = true;

            //Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            tower = Instantiate(bluePrint.upgradePrefab, this.transform.position, Quaternion.identity);

            //타워 건설 이펙트 실행 후 2초후 삭제
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //초기화 - 저장된 타워 프리팹 초기화
            buildManager.SetTowerToBuild(null);

            //건설하고 남은돈
            //Debug.Log($"현재 비용 : {PlayerStats.money}");
        }
        public void SellTower()
        {
            if (IsUpgrade)
            {
                ////판매 되었을때 들어오는 에너지((기존 타워 값 + 업그레이드 비용) /2)
                PlayerStats.AddMoney((bluePrint.cost + bluePrint.upgradeCost) / 2);
            }
            else
            {
                //판매 되었을때 들어오는 에너지(기존 타워 값의 /2)
                PlayerStats.AddMoney(bluePrint.cost / 2);
            }
               
            //타워 건설 이펙트 실행 후 2초후 삭제
            GameObject effectGo = Instantiate(sellEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //타워 킬
            Destroy(tower);

            // 상태 초기화
            tower = null;
            IsUpgrade = false;
            bluePrint = null;
        }

        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
                return;

            if (buildManager.CannotBuild)
            {
                return;
            }
            //돈 계산
            if (buildManager.NotEnoughMoney)
            {
                renderer.material = moneyMaterial;
            }
            else
            {
                renderer.material = changeMaterial;
            }  
        }
        private void OnMouseExit()
        {
            renderer.material = startMaterial;
        }
    }

}
