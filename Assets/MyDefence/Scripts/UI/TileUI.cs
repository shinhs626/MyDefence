using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        #region Field
        public GameObject offset;

        //선택한 타일
        private Tile selectTile;

        //업그레이드 cost Text UI
        public TextMeshProUGUI upgradeCost;
        public Button upgradeButton;

        //판매 Text UI
        public TextMeshProUGUI sellCost;
        #endregion

        //타일 UI 보이기
        public void ShowTileUI(Tile tile)
        {
            selectTile = tile;
            //선택된 타일로 위치 이동
            this.transform.position = tile.transform.position;

            if(tile.IsUpgrade == true)
            {
                upgradeCost.text = "COMPLETE";
                sellCost.text = ((tile.bluePrint.cost + tile.bluePrint.upgradeCost) / 2).ToString() + "G";
                upgradeButton.interactable = false;
            }
            else
            {
                //업그레이드 가격 표시
                upgradeCost.text = tile.bluePrint.upgradeCost.ToString() + "G";
                sellCost.text = (tile.bluePrint.cost / 2).ToString() + "G";
                upgradeButton.interactable = true;
            }  
            offset.SetActive(true);
        }
        
        //타일 UI 감추기
        public void HideTileUI()
        {
            offset.SetActive(false);
        }
        //업그레이드 버튼 클릭시
        public void UpgradeTower()
        {
            //선택된 타일에 있는 타워를 업그레이드 한다
            selectTile.UpgradeTower();

            //업그레이드 후 창 닫기
            BuildManager.Instance.DeSelectTile();
        }
        public void SellTower()
        {
            //선택된 타일에 있는 타워를 판매한다(판매가격은 기존 타워 값에 /2 값)
            selectTile.SellTower();

            //업그레이드 후 창 닫기
            BuildManager.Instance.DeSelectTile();
        }
    }

}
