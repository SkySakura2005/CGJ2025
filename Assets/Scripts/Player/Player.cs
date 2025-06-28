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
                    SceneManager.LoadScene(1);
                }
            }
        }

        public void ExecuteObject(IObjectType objectType)
        {
            objectType.PlayerEffects(gameObject);
            
        }
    }
}