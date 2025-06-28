using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.GameOverScene
{
    public class GameOverCanva:MonoBehaviour
    {
        public Button restartButton;
        public Button exitButton;
        private void Start()
        {
            restartButton.onClick.AddListener(()=>SceneManager.LoadScene(1));
            exitButton.onClick.AddListener(()=>Application.Quit());
        }
    }
}