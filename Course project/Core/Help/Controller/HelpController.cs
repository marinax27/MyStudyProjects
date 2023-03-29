using Core.Help.Model;
using Core.Help.View;

namespace Core.Help.Controller
{
  /// <summary>
  /// Контроллер справки
  /// </summary>
  public abstract class HelpController : MVC.Controller<HelpModel, HelpView>
  {
    /// <summary>
    /// Событие возвращения в меню
    /// </summary>
    public event Action? BackToMenuEvent;

    /// <summary>
    /// Конструктор справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    /// <param name="parView">Представление справки</param>
    public HelpController(HelpModel parModel, HelpView parView) : base(parModel, parView)
    {

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
