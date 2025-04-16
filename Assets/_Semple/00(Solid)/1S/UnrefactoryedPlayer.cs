using UnityEngine;

namespace Solid
{
    public class UnrefactoryedPlayer : MonoBehaviour
    {
        //이동3
        private Vector3 InputVector;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            Move(InputVector);
        }

        //플레이어 인풋
        private void HandleInput()
        {

        }

        private void Move(Vector3 inputVector)
        {
            //플레이어 이동
        }

        private void PlayRandomAudioClip()
        {
            //사운드 플레이
        }

        //플레이어 이펙트
        private void PlayEffect()
        {
            //이펙트 플레이
        }
    }

}
