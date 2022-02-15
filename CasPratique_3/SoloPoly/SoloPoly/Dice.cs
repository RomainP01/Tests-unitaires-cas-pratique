using System;

namespace SoloPoly
{
    public class Dice
    {
        private int[] _faces = new[] {1, 2, 3, 4, 5, 6};

        public int[] Faces => _faces;
        public int Roll()
        {
            Random random = new Random();
            int roll = random.Next(1, 7);
            return _faces[roll-1];
        }
    }
}