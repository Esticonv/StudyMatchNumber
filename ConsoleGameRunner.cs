using MatchNumber.GameModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchNumber
{
    internal class ConsoleGameRunner
    {
        readonly IGame _game;

        public ConsoleGameRunner(IGame game)
        {
            _game = game;
        }

        public void Run()
        {
            foreach (var reaction in _game.React()) {
                Console.WriteLine(reaction);
                _game.SetInput(Console.ReadLine() ?? string.Empty);
            }
        }
    }
}
