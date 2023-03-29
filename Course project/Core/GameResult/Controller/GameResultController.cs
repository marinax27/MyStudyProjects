using Core.GameResult.Model;
using Core.GameResult.View;
using Core.MVC;

namespace Core.GameResult.Controller
{
  /// <summary>
  /// Контроллер результата игры
  /// </summary>
  public class GameResultController : Controller<GameResultModel, GameResultView>
  {
    /// <summary>
    /// Событие возвращения в меню
    /// </summary>
    public event Action? BackToMenuEvent;

    /// <summary>
    /// Конструктор контроллера результата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    /// <param name="parView">Представление результата игры</param>
    public GameResultController(GameResultModel parModel, GameResultView parView) : base(parModel, parView)
    {
    }

    /// <summary>
    /// Устанавливает результат игры
    /// </summary>
    /// <param name="parScore">Очки</param>
    public void SetGameResult(int parScore)
    {
      Model.Score = parScore;
      Model.SetIsRecord();
    }

    /// <summary>
    /// Возвращает в меню
    /// </summary>
    public void BackToMenu()
    {
      BackToMenuEvent?.Invoke();
    }
  }
}
