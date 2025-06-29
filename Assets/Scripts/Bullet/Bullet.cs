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
            var player = Player.Player.Instance;
            float speedBuff = 1 + 0.1f * player.ShoeBuffCount;
            float hurtBuff = 1 + 0.2f * player.RiotBuffCount;
            float dragBuff = 1 - 0.07f * player.SoapBuffCount;
            float scaleBuff = 1 + 0.2f * player.SoundBuffCount;

            _initSpeed = 10 * speedBuff;
            _rb.velocity = (enemyPosition-playerPosition).normalized * _initSpeed;
            _sr.sprite = type.sprite;
            hurts = Mathf.RoundToInt(type.Hurts * hurtBuff);//四舍五入一下，看情况需不需要
            _rb.drag = Mathf.Max(_rb.drag * dragBuff, 0.01f);
            transform.localScale = Vector3.one * scaleBuff;
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