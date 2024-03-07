using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using MatchNumber.GameModule;

namespace MatchNumber
{
    internal class CommandLineOptions : IMatchGameOptions
    {
        [Option(longName:"attemp-count", Default = 2, Required = false, HelpText = "Количество попыток для угадывания")]
        [Value(index:0, Min = 1)]
        public int AttempCount { get; set; }

        [Option(longName: "min-number", Default = 1, Required = false, HelpText = "Наименьшее загаданное число") ]
        [Value(index: 1, Min = 1)]
        public int MinNumber { get; set; }

        [Option(longName: "max-number", Default = 5, Required = false, HelpText = "Наибольшее загаданное число")]
        [Value(index: 2, Min = 1)]
        public int MaxNumber { get; set; }
    }
}
