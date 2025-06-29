using Bullet.Implement;
using Bullet.Interface;
using UnityEngine;

namespace Bullet
{
    public class BulletGenerator:MonoBehaviour
    {
        public IBulletType Type;
        
        private float interval;
        private float currentInterval;

        private SpriteRenderer _sr;
        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            
        }

        public void InitializeGenerator(IBulletType bulletType,Sprite generatorSprite,Vector3 position)
        {
            Type = bulletType;
            _sr.sprite = generatorSprite;
            interval = bulletType.interval;
            currentInterval = bulletType.interval;
            transform.position = position;
            transform.localScale = new Vector3(3, 3, 3);
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
            if(EnemyGenerator.Enemies.Count==0) return;
            GameObject newBullet = Instantiate(Resources.Load<GameObject>("Prefab/Bullet"), transform, true);
            Vector2 minPosition=new Vector2();
            float minLength=float.MaxValue;
            
            foreach (var enemy in EnemyGenerator.Enemies)
            {
                if ((enemy.transform.position - transform.position).magnitude <= minLength)
                {
                    minPosition=enemy.transform.position;
                }
            }//可以用小根堆压bug
            newBullet.GetComponent<Bullet>().InitializeBullet(Type,minPosition,transform.position);
        }
    }
}