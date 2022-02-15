using System;

namespace SoloPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Console.WriteLine(dice.Roll());
        }
    }
}