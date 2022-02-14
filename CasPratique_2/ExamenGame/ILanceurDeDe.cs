using System;
namespace ExamenGame
{
    public interface ILanceurDeDe
    {
        int Lance();
    }

    public class De : ILanceurDeDe
    {
        private Random random;

        public De() { random = new Random(); }
        public int Lance() { return random.Next(1, 7); }
    }

    public class FauxDe : ILanceurDeDe
    {
        private readonly int[] _listeDeJets;
        private int _compteur;

        public FauxDe()
        {
            _listeDeJets = new[]
            {4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6, 4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6};
            _compteur = 0;
        }

        public int Lance()
        {
            int tirage = _listeDeJets[_compteur];
            _compteur++;
            return tirage;
        }
    }

}
