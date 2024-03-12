namespace MatchNumber.GameModule
{
    public interface IGame
    {
        int RightAnswer { get; }
        int Attemp { get; }
        GameState State { get; }

        ReactResult React(string input);
    }
}
