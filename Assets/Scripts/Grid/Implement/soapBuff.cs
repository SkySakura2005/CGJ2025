using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class soapBuff : IObjectType
    {
        public BuffType Type => BuffType.Soap;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[/*填正确索引*/2];
        public bool[,] Shape => new bool[1,1] { { true } };

        public void PlayerEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().AddSoapBuff();
        }

        public void RemoveEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().RemoveSoapBuff();
        }
    }
}
