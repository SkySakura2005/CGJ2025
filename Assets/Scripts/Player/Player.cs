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