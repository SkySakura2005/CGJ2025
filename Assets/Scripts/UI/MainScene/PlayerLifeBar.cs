using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainScene
{
    public class PlayerLifeBar:MonoBehaviour
    {
        private Image image;
        
        private void Start()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            image.fillAmount = (float)Player.Player.Instance.currentLife / Player.Player.Instance.maxLife;
        }
    }
}