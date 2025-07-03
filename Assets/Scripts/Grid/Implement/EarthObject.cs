using Bullet;
using Bullet.Implement;
using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class EarthObject:IObjectType
    {
        public BuffType Type => BuffType.Earth;
    
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[2];

        public bool[,] Shape =>new bool[1,1]
        {
            { true }
        };


        public void PlayerEffects(GameObject player)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).childCount == 0)
                {
                    GameObject newLife=MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Life"), player.transform.GetChild(i), true);
                    newLife.GetComponent<BulletGenerator>().InitializeGenerator(new EarthBullet(),Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[2],player.transform.GetChild(i).position);
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
                    typeof(EarthBullet))
                {
                    MonoBehaviour.Destroy(player.transform.GetChild(i).GetChild(0).gameObject);
                    break;
                }
            }
        }
    }
}