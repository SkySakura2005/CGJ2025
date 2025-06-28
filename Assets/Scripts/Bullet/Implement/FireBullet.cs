using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class FireBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/FireBullet");
        public int Hurts { get; }
    }
}