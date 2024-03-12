namespace MatchNumber.GameModule
{
    internal class Translator : ITranslator
    {
        private readonly IMatchGameOptions _options;
        private readonly IGame _game;
        public Translator(IGame game, IMatchGameOptions options)
        {
            _game = game;
            _options = options;
        }

        public string Translate(ReactResult reactResult)
        {
            return reactResult switch {
                ReactResult.Greatings => $"Угадайте число в диапазоне [{_options.MinNumber},{_options.MaxNumber}]. Количество попыток: {_options.AttempCount} ",
                ReactResult.Win => "Победа! Нажмите ВВОД для выхода",
                ReactResult.Lose => $"Поражение...Было загадано число {_game.RightAnswer}",
                ReactResult.Lesser => $"Ваше число меньше. Количество попыток: {_game.Attemp}",
                ReactResult.Greater => $"Ваше число БОЛЬШЕ. Количество попыток: {_game.Attemp}",
                ReactResult.UnknowInput => "Не смог понять число. Попробуйте ещё раз",
                _ => throw new InvalidOperationException(),
            };            
        }
    }
}
