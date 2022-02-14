using System;
using static ExamenGame.Jeu;

namespace ExamenGame
{
    public interface IFournisseurMeteo
    {
        Meteo QuelleEstLaMeteo();
    }

    public class FournisseurMeteo : IFournisseurMeteo
    {
        private readonly Random _random;
        public FournisseurMeteo()
        {
            _random = new Random();
        }

        public Meteo QuelleEstLaMeteo()
        {
            var result = _random.Next(0, 21);
            if (result < 10) return Meteo.Soleil;
            if (result < 20) return Meteo.Pluie;
            return Meteo.Tempete;
        }
    }
}
