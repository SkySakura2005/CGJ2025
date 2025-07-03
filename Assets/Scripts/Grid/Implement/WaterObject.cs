using Bullet;
using Bullet.Implement;
using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    
    public class WaterObject:IObjectType
    {
        public BuffType Type => BuffType.Water;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[3];

        public bool[,] Shape =>new bool[2,1]
        {
            { true },
            { true }
        };


        public void PlayerEffects(GameObject player)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).childCount == 0)
                {
                    GameObject newLife=MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Life"), player.transform.GetChild(i), true);
                    newLife.GetComponent<BulletGenerator>().InitializeGenerator(new WaterBullet(),Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[3],player.transform.GetChild(i).position);
                    break;
                }
            }
        }

        public void RemoveEffects(GameObject player)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).childCount == 1 &&
                    player.transform.GetChild(i).GetComponentInChildren<BulletGenerator>().Type.GetType() ==
                    typeof(WaterBullet))
                {
                    player.transform.GetChild(i).DetachChildren();
                    break;
                }
            }
        }
    }
}