using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class riotBuff : IObjectType
    {
        public BuffType Type => BuffType.Boxing;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[/*填正确索引*/1];
        public bool[,] Shape => new bool[1,1] { { true } };

        public void PlayerEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().AddRiotBuff();
        }

        public void RemoveEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().RemoveRiotBuff();
        }
    }
}
