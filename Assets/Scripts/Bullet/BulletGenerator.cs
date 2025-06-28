using Bullet.Implement;
using UnityEngine;

namespace Bullet
{
    public class BulletGenerator:MonoBehaviour
    {
        public float interval;
        public float currentInterval;

        private void Start()
        {
            currentInterval = interval;
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
            newBullet.GetComponent<Bullet>().InitializeBullet(new BulletTypeA(),minPosition,transform.position);
        }
    }
}