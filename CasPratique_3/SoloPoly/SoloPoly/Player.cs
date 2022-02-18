namespace SoloPoly
{
    public class Player
    {
        private string _pseudo;
        public int CryptoDevise { get; set; } = 1000;

        public Player(string pseudo)
        {
            _pseudo = pseudo;
        }
        
    }
}