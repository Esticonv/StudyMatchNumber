
namespace MatchNumber.IO
{
    internal class ConsoleInputReader : IInputReader
    {
        public Func<string> ReadLine => Console.ReadLine!;
    }
}
