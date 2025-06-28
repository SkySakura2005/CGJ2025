using System;
using Bullet.Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Bullet
{
    public class Bullet:MonoBehaviour
    {
        private float _initSpeed;
        private float _radius;
        public int hurts;
        
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _initSpeed = 10;
        }

        public void InitializeBullet(IBulletType type,Vector2 enemyPosition,Vector2 playerPosition)
        {
            transform.position = playerPosition;
            _rb.velocity = (enemyPosition-playerPosition).normalized * _initSpeed;
            _sr.sprite = type.sprite;
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