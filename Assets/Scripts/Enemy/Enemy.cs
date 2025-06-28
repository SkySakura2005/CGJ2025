using System;
using Enemy.Interface;
using UnityEngine;

namespace Enemy
{
    public class Enemy:MonoBehaviour
    {
        private Rigidbody2D _rb;
        
        private Vector2 _generatePoint;
        private Vector2 _centerPoint;
        private int _maxLife;
        private int _life;
        private Sprite _sprite;
        private int _speed;

        public int Hurt;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void InitializeEnemy(IEnemyType type,Vector2 centerPoint) 
        {
            _generatePoint = transform.position;
            _centerPoint = centerPoint;
            _maxLife = type.MaxLife;
            _life = _maxLife;
            _speed = type.Velocity;
            Hurt = type.Hurt;
        }

        private void Update()
        {
            _rb.velocity = new Vector2(_centerPoint.x-_generatePoint.x, _centerPoint.y-_generatePoint.y).normalized*_speed;
            if ((transform.position - (Vector3)_centerPoint).magnitude < 0.1f)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullets"))
            {
                Debug.Log(other.transform.name);
                _life -= other.transform.GetComponent<Bullet.Bullet>().hurts;
                if (_life <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}