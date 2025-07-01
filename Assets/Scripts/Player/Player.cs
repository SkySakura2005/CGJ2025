using System;
using Grid;
using Grid.Interface;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Player
{
    public class Player:MonoBehaviour
    {
        public int maxLife;
        public int currentLife;

        public GameObject gameOverCanvas;
        
        public static Player Instance;
        
        private SpriteRenderer _sr;
        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            currentLife = maxLife;
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector2 minPosition=new Vector2();
            float minLength=float.MaxValue;
            foreach (var enemy in EnemyGenerator.Enemies)
            {
                if ((enemy.transform.position - transform.position).magnitude <= minLength)
                {
                    minPosition=enemy.transform.position;
                    minLength = (enemy.transform.position - transform.position).magnitude;
                }
            }

            if (EnemyGenerator.Enemies.Count > 0)
            {
                _sr.flipX=minPosition.x>transform.position.x;
            }
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                currentLife -= other.GetComponent<Enemy.Enemy>().Hurt;
                if (currentLife <= 0)
                {
                    
                    gameOverCanvas.SetActive(true);
                }
            }
        }

        public void ExecuteObject(IObjectType objectType)
        {
            objectType.PlayerEffects(gameObject);
            
        }

        public void RemoveObject(IObjectType objectType)
        {
            objectType.RemoveEffects(gameObject);
        }

        public int ShoeBuffCount { get; private set; }
        public int RiotBuffCount { get; private set; }
        public int SoapBuffCount { get; private set; }
        public int SoundBuffCount { get; private set; }

        public void AddShoeBuff() => ShoeBuffCount++;
        public void RemoveShoeBuff() { if (ShoeBuffCount > 0) ShoeBuffCount--; }

        public void AddRiotBuff() => RiotBuffCount++;
        public void RemoveRiotBuff() { if (RiotBuffCount > 0) RiotBuffCount--; }

        public void AddSoapBuff() => SoapBuffCount++;
        public void RemoveSoapBuff() { if (SoapBuffCount > 0) SoapBuffCount--; }

        public void AddSoundBuff() => SoundBuffCount++;
        public void RemoveSoundBuff() { if (SoundBuffCount > 0) SoundBuffCount--; }
    }
}