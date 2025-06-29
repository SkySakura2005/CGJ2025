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
            GenerateObject(new FireObject());
            GenerateObject(new WaterObject());
            GenerateObject(new EarthObject());
            GenerateObject(new GrassObject());
        }

        public void GenerateRandomObject()
        {
            Array values = Enum.GetValues(typeof(BuffType));
            BuffType randomBuffType;
            do
            {
                randomBuffType = (BuffType)values.GetValue(Random.Range(0, values.Length));
            } while (randomBuffType == BuffType.None);

            string prefabPath = "";//路径，需要修改

            GameObject prefab = Resources.Load<GameObject>(prefabPath);

            GameObject newObject = Instantiate(prefab, transform, true);
            newObject.transform.position = new Vector3(
                Random.Range(_coll.bounds.min.x, _coll.bounds.max.x),
                Random.Range(_coll.bounds.min.y, _coll.bounds.max.y)
            );
        }
        public void GenerateObject(IObjectType objectType)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Object"), transform, true);
            newObject.GetComponent<PackedObject>().InitializeObject(objectType,new Vector3(Random.Range(_coll.bounds.min.x,_coll.bounds.max.x),Random.Range(_coll.bounds.min.y,_coll.bounds.max.y)));
        }
    }
}