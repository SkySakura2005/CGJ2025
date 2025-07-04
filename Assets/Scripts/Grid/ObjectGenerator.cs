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
            IObjectType result1=new soapBuff();
            while (result1.Type!=BuffType.Earth&&result1.Type!=BuffType.Fire&&result1.Type!=BuffType.Grass&&result1.Type!=BuffType.Water)
            {
                result1=GenerateRandomObject();
            }
            GenerateObject(result1);
            GenerateObject(GenerateRandomObject());
            GenerateObject(GenerateRandomObject());
        }

        public IObjectType GenerateRandomObject()
        {
            Array values = Enum.GetValues(typeof(BuffType));
            BuffType randomBuffType;
            do
            {
                randomBuffType = (BuffType)values.GetValue(Random.Range(0, values.Length));
            } while (randomBuffType == BuffType.None);

            /*string prefabPath = "Prefab/Object";//路径，需要修改

            GameObject prefab = Resources.Load<GameObject>(prefabPath);

            GameObject newObject = Instantiate(prefab, transform, true);
            newObject.transform.position = new Vector3(
                Random.Range(_coll.bounds.min.x, _coll.bounds.max.x),
                Random.Range(_coll.bounds.min.y, _coll.bounds.max.y)
            );*/
            IObjectType thisType=new riotBuff();
            switch (randomBuffType)
            {
                case BuffType.Shoes:
                    thisType = new shoeBuff();
                    break;
                case BuffType.Soap:
                    thisType = new soapBuff();
                    break;
                case BuffType.Boxing:
                    thisType = new riotBuff();
                    break;
                case BuffType.Sound:
                    thisType = new soundBuff();
                    break;
                case BuffType.Earth:
                    thisType = new EarthObject();
                    break;
                case BuffType.Fire:
                    thisType = new FireObject();
                    break;
                case BuffType.Grass:
                    thisType = new GrassObject();
                    break;
                case BuffType.Water:
                    thisType = new WaterObject();
                    break;
            }
            Debug.Log(thisType);
            //newObject.GetComponent<PackedObject>().InitializeObject(thisType,new Vector3(Random.Range(_coll.bounds.min.x,_coll.bounds.max.x),Random.Range(_coll.bounds.min.y,_coll.bounds.max.y)));
            return thisType;
        }
        public void GenerateObject(IObjectType objectType)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Object"), transform, true);
            newObject.GetComponent<PackedObject>().InitializeObject(objectType,new Vector3(Random.Range(_coll.bounds.min.x,_coll.bounds.max.x),Random.Range(_coll.bounds.min.y,_coll.bounds.max.y)));
        }
    }
}