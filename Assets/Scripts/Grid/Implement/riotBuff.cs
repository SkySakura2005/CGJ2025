using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class riotBuff : IObjectType
    {
        public BuffType Type => BuffType.Boxing;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Properties/Properties")[/*填正确索引*/1];
        public bool[,] Shape => new bool[2,2]
        {
            {true,true},
            {true,true}
        };

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
