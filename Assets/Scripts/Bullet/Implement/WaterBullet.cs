using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class WaterBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/WaterBullet");
        public float interval => 0.5f;
        public float size => 2;
        public float fiction => 0.8f;

        public int Hurts => 2;
    }
}