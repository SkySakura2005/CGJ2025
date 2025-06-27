using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemyType
    {
        public int MaxLife { get; }
        public Sprite EnemySprite { get; }
        public int Velocity { get; }
    }
}