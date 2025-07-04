using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Grid;
using Grid.Interface;

namespace UI.ChooseUI
{
    public class ChooseUI:MonoBehaviour
    {
        public Button[] chooseButton;
        public Image[] chooseObjects;
        public ObjectGenerator objectGenerator;
        public GameObject chooseUI;
        
        private IObjectType[] objectTypes;
        
        private void Awake()
        {
            objectTypes = new IObjectType[3];
        }

        private void OnEnable()
        {
            for (int i = 0; i < 3; i++)
            {
                objectTypes[i]=objectGenerator.GenerateRandomObject();
                chooseObjects[i].sprite = objectTypes[i].Sprite;
                chooseObjects[i].rectTransform.sizeDelta = new Vector2(chooseObjects[i].sprite.rect.width, chooseObjects[i].sprite.rect.height);
                int index = i;
                chooseButton[i].onClick.AddListener(() => {
                    objectGenerator.GenerateObject(objectTypes[index]);
                    gameObject.SetActive(false);
                    Time.timeScale = 1;
                });
            }
        }
    }
}