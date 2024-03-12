namespace MatchNumber.IO
{
    internal class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
