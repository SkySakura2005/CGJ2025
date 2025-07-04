using Bullet;
using Bullet.Implement;
using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class GrassObject:IObjectType
    {
        public BuffType Type=>BuffType.Grass;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[0];

        public bool[,] Shape =>new bool[2,2]
        {
            { true, true },
            { true, true }
        };


        public void PlayerEffects(GameObject player)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).childCount == 0)
                {
                    GameObject newLife=MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Life"), player.transform.GetChild(i), true);
                    newLife.GetComponent<BulletGenerator>().InitializeGenerator(new GrassBullet(),Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[0],player.transform.GetChild(i).position);
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
                    typeof(GrassBullet))
                {
                    player.transform.GetChild(i).DetachChildren();
                    break;
                }
            }
        }
    }
}