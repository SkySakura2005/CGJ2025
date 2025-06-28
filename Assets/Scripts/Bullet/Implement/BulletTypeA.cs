using Bullet.Interface;
using UnityEngine;

namespace Bullet.Implement
{
    public class BulletTypeA:IBulletType
    {
        public Sprite sprite { get; }
        public int Hurts { get; }
    }
}