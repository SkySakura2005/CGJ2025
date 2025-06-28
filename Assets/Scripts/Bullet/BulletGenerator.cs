using Bullet.Implement;
using Bullet.Interface;
using UnityEngine;

namespace Bullet
{
    public class BulletGenerator:MonoBehaviour
    {
        private IBulletType _type;
        
        public float interval;
        public float currentInterval;

        private void Start()
        {
            currentInterval = interval;
        }

        public void InitializeGenerator(IBulletType bulletType)
        {
            _type = bulletType;
        }
        private void Update()
        {
            currentInterval-= Time.deltaTime;
            if (currentInterval <= 0)
            {
                GenerateBullet();
                currentInterval = interval;
            }
        }

        private void GenerateBullet()
        {
            GameObject newBullet = Instantiate(Resources.Load<GameObject>("Prefab/Bullet"), transform, true);
            Vector2 minPosition=new Vector2();
            float minLength=float.MaxValue;
            foreach (var enemy in EnemyGenerator.Enemies)
            {
                if ((enemy.transform.position - transform.position).magnitude < minLength)
                {
                    minPosition=enemy.transform.position;
                }
            }//可以用小根堆压bug
            newBullet.GetComponent<Bullet>().InitializeBullet(_type,minPosition,transform.position);
        }
    }
}