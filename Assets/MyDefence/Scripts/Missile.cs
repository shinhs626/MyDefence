using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    //미사일을 관리하는 클래스
    public class Missile : Bullet
    {
        #region Field
        public float damageRange = 3.5f;

        public string enemyTag = "Enemy";
        #endregion

        public override void HitTarget()
        {
            //타격 이펙트 효과
            GameObject effectBullet = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectBullet, 2f);

            Explosion();
            
            //탄환 게임 오브젝트 킬
            Destroy(this.gameObject);
        }
        //폭발 - 데미지 영역(3.5f)에 있는 적을 찾아 킬
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            foreach (var hitCollider in hitColliders)
            {
                //데미지 영역안의 모든 충돌체에서 Enemy찾기
                if (hitCollider.tag == enemyTag)
                {
                    Destroy(hitCollider.gameObject);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
    }
    
}

