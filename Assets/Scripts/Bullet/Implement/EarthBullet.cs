using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class EarthBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/EarthBullet");
        public int Hurts { get; }
    }
}