namespace MatchNumber.GameModule
{
    public interface IMatchGameOptions
    {
        public int AttempCount { get; set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
    }
}
