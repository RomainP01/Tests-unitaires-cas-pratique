using System;
namespace ExamenGame
{
    public class Jeu
    {
        public Heros Heros { get; }
        private readonly IFournisseurMeteo _fournisseurMeteo;

        public Jeu(IFournisseurMeteo fournisseurMeteo)
        {
            Heros = new Heros(15);
            _fournisseurMeteo = fournisseurMeteo;
        }

        public Resultat Tour(int deHeros, int deMonstre)
        {
            if (GagneLeCombat(deHeros, deMonstre))
            {
                Heros.GagneUnCombat();
                return Resultat.Gagne;
            }
            else
            {
                var temps = _fournisseurMeteo.QuelleEstLaMeteo();
                if (temps == Meteo.Tempete) Heros.PerdreUncombat(2 * (deMonstre - deHeros));
                else Heros.PerdreUncombat(deMonstre - deHeros);
                return Resultat.Perdu;
            }
        }

        private bool GagneLeCombat(int de1, int de2)
        {
            return de1 >= de2;
        }

        public enum Meteo { Soleil, Pluie, Tempete }

    }
}
