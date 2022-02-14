using System;
namespace ExamenGame
{
    public class Heros
    {
        public int PointDeVies { get; private set; }
        public int Score { get; private set; }

        public Heros(int pointDeVies) { PointDeVies = pointDeVies; }

        public void GagneUnCombat() { Score++; }
        public void PerdreUncombat(int nb) { PointDeVies -= nb; }

    }
}
