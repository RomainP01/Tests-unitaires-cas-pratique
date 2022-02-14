using System;
namespace ExamenGame
{
    public interface IConsole
    {
        void Ecrire(string message);
        void EcrireLigne(string message);
    }

    public class ConsoleDeSortie : IConsole
    {
        public void Ecrire(string message)
        {
            Console.Write(message);
        }

        public void EcrireLigne(string message)
        {
            Console.WriteLine(message);
        }
    }
}
