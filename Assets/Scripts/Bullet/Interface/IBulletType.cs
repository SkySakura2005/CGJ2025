
using UnityEngine;

namespace Bullet.Interface
{
    public interface IBulletType
    {
        public Sprite sprite { get; }
        public float interval { get; }
        public float size { get; }
        public float fiction { get; }
        public int Hurts { get; }
    }
}