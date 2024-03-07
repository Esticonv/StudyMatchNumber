using CommandLine;

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
            var gameRunner = new ConsoleGameRunner(new GameModule.MatchGame(options));
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
