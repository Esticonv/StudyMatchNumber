using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchNumber.GameModule
{
    public interface IMatchGameOptions
    {
        public int AttempCount { get; set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
    }
}
