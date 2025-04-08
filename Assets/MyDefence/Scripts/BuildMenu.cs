using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Field
        public TowerBluePrint machineGunTower;
        public TowerBluePrint missileTower;
        #endregion

        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(machineGunTower.towerPrefab);
        }

        public void MissileButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(missileTower.towerPrefab);
        }
    }

}
