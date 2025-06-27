using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Bullet
{
    public class Bullet:MonoBehaviour
    {
        public float InitSpeed=10;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity=new Vector2(5*Mathf.Cos(Mathf.PI/4f),5*Mathf.Sin(Mathf.PI/4f));
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