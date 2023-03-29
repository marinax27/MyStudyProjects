using Core.View;
using Core.Game;

namespace Core.Controller
{
  /// <summary>
  /// Контроллер игры
  /// </summary>
  public abstract class GameController : MVC.Controller<GameModel, GameView>
  {
    /// <summary>
    /// Событие завершения игры
    /// </summary>
    public event dGameFinished? GameFinished;
    /// <summary>
    /// Событие возвращения в меню
    /// </summary>
    public event Action? BackToMenuEvent;

    /// <summary>
    /// Конструктор контроллера игры
    /// </summary>
    /// <param name="parModel">Модель</param>
    /// <param name="parView">Представление</param>
    public GameController(GameModel parModel, GameView parView) : base(parModel, parView)
    {
      Model.GameFinished += (parScore) =>
      {
        GameFinished?.Invoke(parScore);
      };
    }

    /// <summary>
    /// Возвращает в меню
    /// </summary>
    public void BackToMenu()
    {
       BackToMenuEvent?.Invoke();
    }

    /// <summary>
    /// Запускает контроллер игры
    /// </summary>
    public override void Start()
    {
      base.Start();
      Model.Start();
    }

    /// <summary>
    /// Останавливает контроллер игры
    /// </summary>
    public override void Stop()
    {
      Model.Stop();
      base.Stop();
    }

    /// <summary>
    /// Делегат на окончание игры
    /// </summary>
    /// <param name="parScore">Очки</param>
    public delegate void dGameFinished(int parScore);
  }
}
