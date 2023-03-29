using Core.GameResult.Model;

namespace Core.GameResult.View
{
  /// <summary>
  /// Представление результата игры
  /// </summary>
  public abstract class GameResultView : MVC.View<GameResultModel>
  {
    /// <summary>
    /// Конструктор представления результата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    public GameResultView(GameResultModel parModel) : base(parModel)
    {
      parModel.NeedRedrawEvent += Redraw;
    }

    /// <summary>
    /// Перерисовывает представление результата игры
    /// </summary>
    private void Redraw()
    {
      if (IsStarted)
      {
        Draw();
      }
    }
  }
}
