using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchNumber.GameModule
{
    public class MatchGame : IGame
    {
        readonly Random _rand = new();
        readonly IMatchGameOptions _options;
        readonly int _rightAnswer;
        int _attemp;
        string _input = string.Empty;

        public MatchGame(IMatchGameOptions options)
        {
            _options = options;
            _rightAnswer = _rand.Next(_options.MinNumber, _options.MaxNumber + 1);
            _attemp = _options.AttempCount;
        }

        public void SetInput(string input)
        {
            _input = input;
        }        

        public IEnumerable<string> React()
        {
            yield return $"Угадайте число в диапазоне [{_options.MinNumber},{_options.MaxNumber}]. Количество попыток: {_attemp} ";

            while (_attemp > 0){
                if (int.TryParse(_input, out int userAnswer)){
                    _attemp--;

                    int compareResult = userAnswer.CompareTo(_rightAnswer);

                    yield return compareResult switch {
                        0 => VictoryPath(),
                        < 0 => _attemp switch {
                            > 0 => $"Ваше число меньше. Количество попыток: {_attemp}",
                            _ => $"Ваше число меньше. Поражение... Было загадано число {_rightAnswer}. Нажмите ВВОД для выхода",
                        },
                        _ => _attemp switch {
                            > 0 => $"Ваше число больше. Количество попыток: {_attemp}",
                            _ => $"Ваше число больше. Поражение... Было загадано число {_rightAnswer}. Нажмите ВВОД для выхода",
                        },
                    } ;

                    string VictoryPath()
                    {//не получилось записать последовательность команд в switch expression, поэтому написана локальная функция
                        _attemp = 0;
                        return "Победа! Нажмите ВВОД для выхода";
                    }
                }
                else {
                    yield return "Не смог понять число. Попробуйте ещё раз";
                }
            }
        }
    }
}
