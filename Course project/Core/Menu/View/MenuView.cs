using Core.Menu.Model;

namespace Core.Menu.View
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public abstract class MenuView : MVC.View<MenuModel>
  {
    /// <summary>
    /// Конструктор меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    public MenuView(MenuModel parModel) : base(parModel)
    {
      parModel.NeedRedrawEvent += Redraw;
    }

    /// <summary>
    /// Перерисовывает меню
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
