using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Field
        public TowerBluePrint machineGunTower;
        public TowerBluePrint missileTower;
        public TowerBluePrint laserTower;

        #endregion

        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(machineGunTower);
        }

        public void MissileButton()
        {
            //빌드매니저의 towerToBuild에 missileTower을 저장한다
            BuildManager.Instance.SetTowerToBuild(missileTower);
        }
        public void LaserButton()
        {
            //빌드매니저의 towerToBuild에 laserTower을 저장한다
            BuildManager.Instance.SetTowerToBuild(laserTower);
        }
    }

}
