using Enemy.Interface;
using UnityEngine;

namespace Enemy.Implement
{
    public class FireSmile:IEnemyType
    {
        public int MaxLife
        {
            get { return 40; }
        }
        public Sprite[] EnemySprite
        {
            get { return Resources.LoadAll<Sprite>("ArtAssets/Enemy/FireSmile"); }
        }

        public float Velocity
        {
            get{ return 0.8f; }
        }

        public int Hurt
        {
            get { return 1; }
        }
    }
}