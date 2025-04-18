using UnityEngine;

namespace MyDefence
{
    //타이머 기능을 이용하여 특정하는 시간마다 (5초, 6초) 파티클 이펙트를 플레이하는 기능 구현
    public class IntervalParticleSystemPlayer : MonoBehaviour
    {
        #region Field
        //타이머 설정
        public float particleTimer;
        private float particleDelay = 1f;
        private float countdown;

        //파티클 public으로 가져오기
        public ParticleSystem energyParticle;
        public ParticleSystem laserParticle;
        #endregion

        public void Update()
        {
            countdown += Time.deltaTime;
            if (countdown >= particleTimer)
            {
                laserParticle.Play();

                //딜레이를 주어 플레이 시간을 다르게 지정
                Invoke(nameof(startEnergyParticle), particleDelay);

                countdown = 0;
            }
        }

        public void startEnergyParticle()
        {
            energyParticle.Play();
        }
    }
}
