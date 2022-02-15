using System;

namespace SoloPoly
{
    public class GameManager
    {
        public void RollConsequences(Player player, int face)
        {
            switch (face)
            {
                case 1:
                    player.CryptoDevise += 200;
                    break;
                case 2:
                    player.CryptoDevise += 600;
                    break;
                case 3:
                    player.CryptoDevise -= 1000;
                    break;
                case 4:
                    player.CryptoDevise *= 2;
                    break;
                case 5:
                    player.CryptoDevise /= 2;
                     break;
                case 6:
                    break;
                default:
                    throw new ArgumentException("Le dé est cassé");

            }
        }
    }
}