namespace MatchNumber.IO
{
    internal interface IInputReader
    {
        Func<string> ReadLine { get; }
    }
}
