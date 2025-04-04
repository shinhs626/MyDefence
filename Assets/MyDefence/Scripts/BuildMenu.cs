using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(BuildManager.Instance.machineGunPrefab);
        }
    }

}
