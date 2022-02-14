using System;
namespace ExamenGame
{
    public class Ihm
    {
        private readonly IConsole _console;
        private readonly ILanceurDeDe _lanceurDeDe;
        private readonly IFournisseurMeteo _fournisseurMeteo;

        public Ihm(IConsole console, ILanceurDeDe lanceurDeDe, IFournisseurMeteo fournisseurMeteo)
        {
            _console = console;
            _lanceurDeDe = lanceurDeDe;
            _fournisseurMeteo = fournisseurMeteo;
        }

        public void Demarre()
        {
            //FauxDe de = new FauxDe();
            var jeu = new Jeu(_fournisseurMeteo);

            _console.EcrireLigne($"Le jeu démarre : PVs : {jeu.Heros.PointDeVies} / Score : {jeu.Heros.Score} ");
            while (jeu.Heros.PointDeVies > 0)
            {
                var resultat = jeu.Tour(_lanceurDeDe.Lance(), _lanceurDeDe.Lance());
                switch (resultat)
                {
                    case Resultat.Gagne:
                        _console.Ecrire($"Le Heros Gagne \n");
                        break;

                    case Resultat.Perdu:
                        _console.Ecrire($"Combat perdu \n");
                        break;
                }

                _console.EcrireLigne($"PVs : {jeu.Heros.PointDeVies} / Score : {jeu.Heros.Score} \n");
            }
        }
    }
}
