using UnityEngine;

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

        //타일의 원래 매트리얼
        private Material startMaterial;
        //바뀔 타일의 매트리얼
        public Material changeMaterial;

        //타일의 Renderer
        private Renderer renderer;

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            startMaterial = renderer.material;
        }
        private void OnMouseDown()
        {
            Debug.Log("터렛을 설치합니다");
            //Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            Instantiate(BuildManager.Instance.GetTowerToBuild() , this.transform.position, Quaternion.identity);
        }
        private void OnMouseEnter()
        {
            renderer.material = changeMaterial;
        }
        private void OnMouseExit()
        {
            renderer.material = startMaterial;
        }
    }

}
