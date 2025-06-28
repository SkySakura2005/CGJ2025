using System;
using Bullet.Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Bullet
{
    public class Bullet:MonoBehaviour
    {
        private float _initSpeed=10;
        private float _radius;
        public int hurts;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void InitializeBullet(IBulletType type,Vector2 enemyPosition,Vector2 playerPosition)
        {
            _rb.velocity = (enemyPosition-playerPosition).normalized * _initSpeed;
            hurts = type.Hurts;
        }
        private void Update()
        {
            if (_rb.velocity.magnitude <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}