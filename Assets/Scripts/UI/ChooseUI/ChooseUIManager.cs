using System;
using UnityEngine;

namespace UI.ChooseUI
{
    public class ChooseUIManager:MonoBehaviour
    {
        private float startTime;
        private float times;
        public GameObject ChooseUI;
        private void Start()
        {
            startTime = 0;
            times = 1;
            ChooseUI.SetActive(false);
        }

        private void Update()
        {
            startTime += Time.deltaTime;
            if (startTime >= times * 30)
            {
                ChooseUI.SetActive(true);
                times++;
                Time.timeScale = 0;
            }
        }
    }
}