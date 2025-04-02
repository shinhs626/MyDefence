using UnityEngine;

namespace Sample
{
    //싱글톤 패턴 클래스
    public class SingleTon
    {
        //클래스의 인스턴스를 정적(static) 변수 선언
        private  static SingleTon instance;

        public static SingleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingleTon();
                }
                return instance;
            }
        }

        //pulic한 메서드로 Instance를 전역적으로 접근하기
        /*public static SingleTon Instance()
        {
            if(instance == null)
            {
                instance = new SingleTon();
            }

            return instance;
        }*/
    }

}
/*
//싱글톤 패턴 클래스
1. 하나의 인스턴스만 존재 : new 를 한 번만 호출
2. 클래스의 인스턴스가 전역적 접근 가능 : 변수를 static 선언

*/