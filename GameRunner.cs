using MatchNumber.GameModule;
using MatchNumber.IO;

namespace MatchNumber
{
    internal class GameRunner
    {
        private readonly IGame _game;
        private readonly ITranslator _translator;
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;

        public GameRunner(IGame game, ITranslator translator, IInputReader inputReader, IOutputWriter outputWriter)
        {
            _game = game;
            _translator = translator;
            _inputReader = inputReader;
            _outputWriter = outputWriter;
        }

        public void Run()
        {
            _outputWriter.WriteLine(_translator.Translate(_game.React("Run game")));

            while (_game.State != GameState.End) {
                _outputWriter.WriteLine(_translator.Translate(_game.React(_inputReader.ReadLine()!)));
            }
        }
    }
}
