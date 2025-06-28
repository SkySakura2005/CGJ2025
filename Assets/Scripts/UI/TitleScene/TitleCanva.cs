using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.TitleScene
{
    public class TitleCanva:MonoBehaviour
    {
        public Button startButton;
        public Button exitButton;
        private void Start()
        {
            startButton.onClick.AddListener(()=>SceneManager.LoadScene(1));
            exitButton.onClick.AddListener(()=>Application.Quit());
        }
    }
}