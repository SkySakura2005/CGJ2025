using Enemy.Interface;
using UnityEngine;

namespace Enemy.Implement
{
    public class GreenSmile:IEnemyType
    {
        public int MaxLife
        {
            get { return 20; }
        }
        public Sprite[] EnemySprite
        {
            get { return Resources.LoadAll<Sprite>("ArtAssets/Enemy/GreenSmile"); }
        }

        public float Velocity
        {
            get{ return 1; }
        }

        public int Hurt
        {
            get { return 1; }
        }
    }
}