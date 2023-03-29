using Core.Game;

namespace Core.View
{
  /// <summary>
  /// Представление игры
  /// </summary>
  public abstract class GameView : MVC.View<GameModel>
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель</param>
    public GameView(GameModel parModel) : base(parModel)
    {
    }
  }
}
