using Core.Help.Model;

namespace Core.Help.View
{
  /// <summary>
  /// Представление справки
  /// </summary>
  public abstract class HelpView : MVC.View<HelpModel>
  {
    /// <summary>
    /// Конструктор представления справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    public HelpView(HelpModel parModel) : base(parModel)
    {
      parModel.NeedRedrawEvent += Redraw;
    }

    /// <summary>
    /// Перерисовывает представление справки
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