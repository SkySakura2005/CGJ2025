using Enemy.Interface;
using UnityEngine;

namespace Enemy.Implement
{
    public class SmallEnemy:IEnemyType
    {
        public int MaxLife
        {
            get { return 50; }
        }
        public Sprite EnemySprite
        {
            get { return null; }
        }

        public int Velocity
        {
            get{ return 1; }
        }
    }
}