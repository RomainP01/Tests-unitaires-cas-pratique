using System;
using Figgle;

namespace SoloPoly
{
    public class IHM
    {
        private readonly IOutputConsole _console;
        private readonly IGameManager _gameManager;
        private readonly IDice _dice;

        public IHM(IOutputConsole console,IGameManager gameManager, IDice dice)
        {
            _console = console;
            _gameManager = gameManager;
            _dice = dice;
        }

        public void Start()
        {
            Player player1 = new Player("Joueur 1");
            Player player2 = new Player("Joueur 2");
            _console.WriteLine(FiggleFonts.Ogre.Render("SoloPoly"));
            _console.WriteLine("Le jeu démarre : ");
            _console.WriteLine("-----------------");
            while (player1.CryptoDevise > 0 && player2.CryptoDevise > 0)
            {
                _console.WriteLine("Au tour du joueur 1 :");
                _gameManager.RollConsequences(player1, _dice.Roll());
                if (player1.CryptoDevise > 0)
                {
                    _console.WriteLine("-----------------");
                    _console.WriteLine("Au tour du joueur 2 :");
                    _gameManager.RollConsequences(player2, _dice.Roll());
                    _console.WriteLine("-----------------");
                }
            }

            if (player1.CryptoDevise<=0)
            {
                _console.WriteLine(FiggleFonts.Ogre.Render("Victoire du joueur 2"));
            }
            else
            {
                _console.WriteLine(FiggleFonts.Ogre.Render("Victoire du joueur 1"));
            }
        }
    }
}