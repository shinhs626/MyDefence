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
        //폭발지점으로 부터 거리를 구하여 거리에 반비례하여 데미지 주기
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            foreach (var hitCollider in hitColliders)
            {
                //데미지 영역안의 모든 충돌체에서 Enemy찾기
                if (hitCollider.tag == enemyTag)
                {
                    //거리 구하기
                    float distance = Vector3.Distance(this.transform.position, hitCollider.transform.position);
                    //거리 비례로 데미지 구하기
                    float damage = attackDamage * ( (damageRange - distance) / damageRange);

                    Enemy enemy = hitCollider.GetComponent<Enemy>();
                    if(enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
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

