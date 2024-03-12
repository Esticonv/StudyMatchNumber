namespace MatchNumber.GameModule
{
    public class MatchGame : IGame
    {
        private readonly int _rightAnswer;
        private int _attemp;
        private GameState _gameState = GameState.NotStarted;

        public int RightAnswer => _rightAnswer;
        public int Attemp => _attemp;
        public GameState State => _gameState;

        public MatchGame(IMatchGameOptions options)
        {
            _rightAnswer = new Random().Next(options.MinNumber, options.MaxNumber + 1);
            _attemp = options.AttempCount;
        }

        public ReactResult React(string input)
        {
            switch (_gameState) {
                case GameState.NotStarted:
                    _gameState = GameState.Run;
                    return ReactResult.Greatings;
                case GameState.Run:
                    if(_attemp > 0) {
                        if (int.TryParse(input, out int userAnswer)){
                            _attemp--;

                            int compareResult = userAnswer.CompareTo(_rightAnswer);
                            if (compareResult == 0) {
                                _gameState = GameState.End;
                                return ReactResult.Win;
                            }
                            else if (compareResult > 0) {
                                if (_attemp == 0) {
                                    _gameState = GameState.End;
                                    return ReactResult.Lose;
                                }
                                else return ReactResult.Greater;
                            }
                            else {
                                if (_attemp == 0) {
                                    _gameState = GameState.End;
                                    return ReactResult.Lose;
                                }
                                else return ReactResult.Lesser;
                            }
                        };
                        return ReactResult.UnknowInput;
                    }
                    break;
            }
            throw new InvalidOperationException("Not should be here");
        }
    }
}
