using System;
using UnityEngine;

namespace Grid
{
    public class ObjectGenerator:MonoBehaviour
    {
        public float interval;
        public float currentInterval;

        private void Start()
        {
            currentInterval = interval;
        }

        private void Update()
        {
            currentInterval-= Time.deltaTime;
            if (currentInterval <= 0)
            {
                GenerateObject();
                currentInterval = interval;
            }
        }

        private void GenerateObject()
        {
            
        }
    }
}