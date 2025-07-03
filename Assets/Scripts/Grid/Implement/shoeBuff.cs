using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class shoeBuff : IObjectType
    {
        public BuffType Type => BuffType.Shoes;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Properties/Properties")[/*填正确索引*/2];
        public bool[,] Shape => new bool[1,2] { { true,true } };

        public void PlayerEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().AddShoeBuff();
        }

        public void RemoveEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().RemoveShoeBuff();
        }
    }
}
