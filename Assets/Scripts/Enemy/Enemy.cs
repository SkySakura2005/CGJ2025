using System;
using System.Collections;
using Enemy.Interface;
using UnityEngine;

namespace Enemy
{
    public class Enemy:MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        
        private Vector2 _generatePoint;
        private Vector2 _centerPoint;
        private int _maxLife;
        private int _life;
        private float _speed;
        private Sprite[] _enemyAnim;

        public int Hurt;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        }

        public void InitializeEnemy(IEnemyType type,Vector2 centerPoint) 
        {
            _generatePoint = transform.position;
            _centerPoint = centerPoint;
            _maxLife = type.MaxLife;
            _life = _maxLife;
            _enemyAnim = type.EnemySprite;
            _speed = type.Velocity;
            Hurt = type.Hurt;
            StartCoroutine(enemyAnimation());
        }

        private void OnDestroy()
        {
            EnemyGenerator.Enemies.Remove(gameObject);
        }

        private void Update()
        {
            _rb.velocity = new Vector2(_centerPoint.x-_generatePoint.x, _centerPoint.y-_generatePoint.y).normalized*_speed;
            if ((transform.position - (Vector3)_centerPoint).magnitude < 1f)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullets"))
            {
                _life -= other.transform.GetComponent<Bullet.Bullet>().hurts;
                StartCoroutine(attackedAnimation());
                
            }
        }

        private IEnumerator enemyAnimation()
        {
            while (true)
            {
                foreach (var sprite in _enemyAnim)
                {
                    _sr.sprite = sprite;
                    yield return new WaitForSeconds((float)1/7);
                }
            }
        }

        private IEnumerator attackedAnimation()
        {
            float timer = 0f;
            _sr.color = new Color(1, 0, 0);
            while (timer < 1)
            {
                timer += Time.deltaTime*2;
                _sr.color = new Color(1, timer, timer);
                yield return null;
            }
            if (_life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}