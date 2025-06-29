using Grid.Interface;
using UnityEngine;

namespace Grid.Implement
{
    public class soundBuff : IObjectType
    {
        public BuffType Type => BuffType.Sound;
        public Sprite Sprite => Resources.LoadAll<Sprite>("ArtAssets/Creatures/Sprites")[/*填正确索引*/3];
        public bool[,] Shape => new bool[1,1] { { true } };

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
