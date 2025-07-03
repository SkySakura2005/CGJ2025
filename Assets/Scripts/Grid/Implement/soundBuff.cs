using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class soundBuff : IObjectType
    {
        public BuffType Type => BuffType.Sound;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Properties/Properties")[/*填正确索引*/4];
        public bool[,] Shape => new bool[2,2]
        {
            { true,true },
            { true,true }
        };

        public void PlayerEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().AddSoundBuff();
        }

        public void RemoveEffects(GameObject player)
        {
            player.GetComponent<Player.Player>().RemoveSoundBuff();
        }
    }
}
