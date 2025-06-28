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
            _rb.velocity=new Vector2(_initSpeed*Mathf.Cos(Mathf.PI/4f),_initSpeed*Mathf.Sin(Mathf.PI/4f));
            hurts=100;
        }

        public void InitializeBullet(IBulletType type)
        {
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