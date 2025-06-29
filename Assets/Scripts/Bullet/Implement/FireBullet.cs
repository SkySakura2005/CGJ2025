using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class FireBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/FireBullet");
        public float interval => 0.6f;
        public float size => 1;
        public float fiction => 1.3f;
        public int Hurts => 10;
    }
}