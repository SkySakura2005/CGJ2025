using System;
using Bullet.Implement;
using Grid.Implement;
using Grid.Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Grid
{
    public class ObjectGenerator:MonoBehaviour
    {
        private BoxCollider2D _coll;
        private void Start()
        {
            _coll = GetComponent<BoxCollider2D>();
            GenerateRandomObject();
        }

        private void GenerateRandomObject()
        {
            
        }
        public void GenerateObject(IObjectType objectType)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Object"), transform, true);
            newObject.GetComponent<PackedObject>().InitializeObject(objectType,new Vector3(Random.Range(_coll.bounds.min.x,_coll.bounds.max.x),Random.Range(_coll.bounds.min.y,_coll.bounds.max.y)));
        }
    }
}