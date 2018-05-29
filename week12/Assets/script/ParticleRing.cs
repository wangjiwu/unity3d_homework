using UnityEngine;
using System.Collections;

public class ParticleRing : MonoBehaviour
{
    public class particleClass
    {
        public float ini_radiu = 0.0f;//初始化半径

        public float now_radiu = 0.0f;//粒子当前时刻半径，用于扩大缩小时与上两者比较

        public float angle = 0.0f;
        public particleClass(float radiu_, float angle_)
        {
            ini_radiu = radiu_;
            angle = angle_;

            now_radiu = radiu_;
        }
    }

    //创建粒子系统，
    public ParticleSystem particleSystem;
    //粒子数组
    private ParticleSystem.Particle[] particlesArray;
    //粒子属性数组
    private particleClass[] particleAttr;
    public int particleNum = 24000;

    //较宽的环的内外半径
    public float outMinRadius = 6.0f;
    public float outMaxRadius = 9.0f;

    //较窄的环(带缺口)的内外半径
    public float inMinRadius = 6.0f;
    public float inMaxRadius = 8.0f;

    public float speed = 0.1f;

    public int flag;

    void Start()
    {
        flag = -1;
        particleAttr = new particleClass[particleNum];
        particlesArray = new ParticleSystem.Particle[particleNum];
        particleSystem.maxParticles = particleNum;
        particleSystem.Emit(particleNum);
        particleSystem.GetParticles(particlesArray);
        for (int i = 0; i < particleNum; i++)
        {
            
            float randomAngle;

            float maxR, minR;

            if (i < particleNum * 5 / 12)
            {
                maxR = outMaxRadius;
                minR = outMinRadius;
                randomAngle = Random.Range(0.0f, 360.0f);
            }
            else
            {
                maxR = inMaxRadius;
                minR = inMinRadius;
                float minAngle = Random.Range(-90f, 0.0f);
                float maxAngle = Random.Range(0.0f, 90f);
                float angle = Random.Range(minAngle, maxAngle);

                randomAngle = i % 2 == 0 ? angle : angle - 180;
            }

            float midRadius = (maxR + minR) / 2;

            float min = Random.Range(minR, midRadius);

            float max = Random.Range(midRadius, maxR);

            float randomRadius = Random.Range(min, max);


            //if (i%2 == 0)
            //{
            //    randomRadius = -randomRadius;
            //}


       
            particleAttr[i] = new particleClass(randomRadius, randomAngle);
            particlesArray[i].position = new Vector3(randomRadius * Mathf.Cos(randomAngle), randomRadius * Mathf.Sin(randomAngle), 0.0f);
        }
  
        particleSystem.SetParticles(particlesArray, particleNum);
    }


    void Update()
    {
        for (int i = 0; i < particleNum; i++)
        {
            //根据新的角度
            if (i > particleNum * 5 / 12)
                speed = 0.1f;
            else
                speed = 0.05f;
            particleAttr[i].angle -= speed;
            particleAttr[i].angle = particleAttr[i].angle % 360;
            float rad = particleAttr[i].angle / 180 * Mathf.PI;


            if(i % 8 == 0)
            {
                particlesArray[i].position = new Vector3(-particleAttr[i].now_radiu * Mathf.Cos(rad), particleAttr[i].now_radiu * Mathf.Sin(rad), 0f);
            } else
            {
                particlesArray[i].position = new Vector3(particleAttr[i].now_radiu * Mathf.Cos(rad), particleAttr[i].now_radiu * Mathf.Sin(rad), 0f);
            }
           
        }
        particleSystem.SetParticles(particlesArray, particleNum);
    }


}