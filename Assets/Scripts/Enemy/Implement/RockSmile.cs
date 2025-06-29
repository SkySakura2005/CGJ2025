using Enemy.Interface;
using UnityEngine;

namespace Enemy.Implement
{
    public class RockSmile:IEnemyType
    {
        public int MaxLife
        {
            get { return 100; }
        }
        public Sprite[] EnemySprite
        {
            get { return Resources.LoadAll<Sprite>("ArtAssets/Enemy/RockSmile"); }
        }

        public float Velocity
        {
            get{ return 0.6f; }
        }

        public int Hurt
        {
            get { return 1; }
        }
    }
}