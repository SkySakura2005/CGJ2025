using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class WaterBullet:IBulletType
    {
        public Sprite sprite => Resources.Load<Sprite>("ArtAssets/Bullets/WaterBullet");
        
        public int Hurts { get; }
    }
}