using UnityEngine;

namespace Grid.Interface
{
    public interface IObjectType
    {
        BuffType Type { get; }
        Sprite Sprite { get; }
        bool[,] Shape {get;}
        
        void PlayerEffects(GameObject player);
        void RemoveEffects(GameObject player);
    }
}