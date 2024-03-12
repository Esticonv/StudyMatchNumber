using CommandLine;
using MatchNumber.IO;

namespace MatchNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }
        private static void Run(CommandLineOptions options)
        {
            var game = new GameModule.MatchGame(options);
            var gameRunner = new GameRunner(
                game, 
                new GameModule.Translator(game, options), 
                inputReader: new ConsoleInputReader(), 
                outputWriter: new ConsoleOutputWriter());
            gameRunner.Run();
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach(var error in errs) {
                Console.WriteLine(error.ToString()!);
            }
        }        
    }
}
