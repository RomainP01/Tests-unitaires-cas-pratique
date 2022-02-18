using System;

namespace SoloPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            IHM ihm = new IHM(new OutputConsole() , new GameManager(), new Dice());
            ihm.Start();
        }
    }
}