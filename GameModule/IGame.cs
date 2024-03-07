using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchNumber.GameModule
{
    public interface IGame
    {
        void SetInput(string input);
        IEnumerable<string> React();
    }
}
