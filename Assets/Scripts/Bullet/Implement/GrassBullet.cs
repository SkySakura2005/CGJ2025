using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class GrassBullet:IBulletType
    {
        public Sprite sprite=>Resources.Load<Sprite>("ArtAssets/Bullets/GrassBullet");
        public float interval => 0.8f;
        public float size => 1.5f;
        public float fiction => 0.6f;
        public int Hurts => 2;
    }
}