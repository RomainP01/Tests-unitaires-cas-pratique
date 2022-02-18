using System;
using System.Diagnostics;

namespace SoloPoly
{
    public interface IGameManager
    {
        void RollConsequences(Player player, int face);
    }

    public class GameManager : IGameManager
    {
        public void RollConsequences(Player player, int face)
        {
            switch (face)
            {
                case 1:
                    player.CryptoDevise += 200;
                    Console.WriteLine("Vous avez gagné 200CD \n Voici votre solde actuel : " + player.CryptoDevise);
                    break;
                case 2:
                    player.CryptoDevise += 600;
                    Console.WriteLine("Vous avez gagné 600CD \n Voici votre solde actuel : " + player.CryptoDevise);
                    break;
                case 3:
                    player.CryptoDevise -= 1000;
                    Console.WriteLine("Vous avez perdu 1000CD \n Voici votre solde actuel : " + player.CryptoDevise);
                    break;
                case 4:
                    player.CryptoDevise *= 2;
                    Console.WriteLine("Vous avez doublé vos CD \n Voici votre solde actuel : " + player.CryptoDevise);
                    break;
                case 5:
                    player.CryptoDevise /= 2;
                    Console.WriteLine("Vous avez divisé vos CD \n Voici votre solde actuel : " + player.CryptoDevise);
                    break;
                case 6:
                    break;
                default:
                    throw new ArgumentException("Le dé est cassé");
            }
        }
    }
}