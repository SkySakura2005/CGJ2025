using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemyType
    {
        public int MaxLife { get; }
        public Sprite[] EnemySprite { get; }
        public float Velocity { get; }
        public int Hurt { get; }
    }
}