using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class GrassBullet:IBulletType
    {
        public Sprite sprite=>Resources.Load<Sprite>("ArtAssets/Bullets/GrassBullet");
        public int Hurts { get; }
    }
}