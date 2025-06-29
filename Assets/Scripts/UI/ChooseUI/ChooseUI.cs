using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Grid;

namespace UI.ChooseUI
{
    public class ChooseUI:MonoBehaviour
    {
        public Button chooseButton;
        public ObjectGenerator objectGenerator;
        public GameObject chooseUI;
        private void Start()
        {
            chooseButton.onClick.AddListener(() => {
                objectGenerator.GenerateRandomObject();
                gameObject.SetActive(false);
            });
        }
    }
}