using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.MainScene
{
    public class BackButton:MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(0));
        }
    }
}