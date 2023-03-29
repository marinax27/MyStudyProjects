using Core.Menu.Model;
using Core.Menu.View;

namespace Core.Menu.Controller
{
  /// <summary>
  /// Контроллер меню
  /// </summary>
  public class MenuController : MVC.Controller<MenuModel, MenuView>
  {
    /// <summary>
    /// Событие о необходимости перейти к игре
    /// </summary>
    public event Action? NeedGoToGameEvent;
    /// <summary>
    /// Событие о необходимости перейти к справке
    /// </summary>
    public event Action? NeedGoToHelpEvent;
    /// <summary>
    /// Событие о необходимости перейти к таблице рекордов
    /// </summary>
    public event Action? NeedGoToRecordsTableEvent;
    /// <summary>
    /// Событие о необходимости выйти
    /// </summary>
    public event Action? NeedExitEvent;

    /// <summary>
    /// Конструктор меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    /// <param name="parView">Представление меню</param>
    public MenuController(MenuModel parModel, MenuView parView) : base(parModel, parView)
    {
    }

    /// <summary>
    /// Запускает меню
    /// </summary>
    public override void Start()
    {
      Model.OnMenuClick += MenuClickHandler;
      base.Start();
    }

    /// <summary>
    /// Останавливает меню
    /// </summary>
    public override void Stop()
    {
      Model.OnMenuClick -= MenuClickHandler;
      base.Stop();
    }

    /// <summary>
    /// Обрабатывает нажатие на выбранный пункт меню
    /// </summary>
    /// <param name="parSelectedMenuItem">Выбранный пункт меню</param>
    private void MenuClickHandler(MenuItem parSelectedMenuItem)
    {
      switch (parSelectedMenuItem)
      {
        case MenuItem.NewGame:
          NeedGoToGameEvent?.Invoke();
          break;
        case MenuItem.Help:
          NeedGoToHelpEvent?.Invoke();
          break;
        case MenuItem.RecordsTable:
          NeedGoToRecordsTableEvent?.Invoke();
          break;
        case MenuItem.Exit:
          NeedExitEvent?.Invoke();
          break;
      }
    }
  }
}
