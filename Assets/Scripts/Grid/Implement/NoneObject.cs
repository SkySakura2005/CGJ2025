using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class NoneObject:IObjectType
    {
        public BuffType Type => BuffType.None;

        public Sprite Sprite
        {
            get
            {
                return null;
            }
        }

        public bool[,] Shape
        {
            get
            {
                return null;
            }
        }

        public void PlayerEffects(GameObject player)
        {
            
        }
    }
}