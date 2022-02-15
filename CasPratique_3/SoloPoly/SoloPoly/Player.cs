namespace SoloPoly
{
    public class Player
    {
        private string _pseudo;
        private int _cryptoDevise = 1000;

        public int CryptoDevise
        {
            get => _cryptoDevise;
            set => _cryptoDevise = value;
        }
    }
}