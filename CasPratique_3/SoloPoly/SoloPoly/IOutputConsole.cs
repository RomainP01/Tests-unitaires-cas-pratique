using System;

namespace SoloPoly
{
    public interface IOutputConsole
    {
        void WriteLine(string message);
    }
    public class OutputConsole:IOutputConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}