using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.GameOverScene
{
    public class GameOverCanva:MonoBehaviour
    {
        public Button backButton;
        
        private CanvasGroup canvasGroup;
        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            StartCoroutine(FadeIn());
            backButton.onClick.AddListener(()=>SceneManager.LoadScene(0));
            
        }

        public IEnumerator FadeIn()
        {
            canvasGroup.alpha = 0;
            float alpha = 0;
            while (alpha<1)
            {
                canvasGroup.alpha = alpha;
                alpha+=Time.deltaTime;
                yield return null;
            }
            Time.timeScale = 0;
        }
    }
}