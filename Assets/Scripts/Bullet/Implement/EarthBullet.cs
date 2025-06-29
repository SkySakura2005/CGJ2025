using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class EarthBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/EarthBullet");
        public float interval => 0.5f;
        public float size => 1;
        public float fiction => 1;
        public int Hurts => 5;
    }
}