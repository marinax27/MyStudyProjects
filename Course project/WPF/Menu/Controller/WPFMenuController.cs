using System.Windows;
using System.Windows.Input;
using Core.Menu.Controller;
using Core.Menu.Model;
using WPF.Menu.View;

namespace WPF.Menu.Controller
{
  /// <summary>
  /// WPF контроллер меню
  /// </summary>
  public class WPFMenuController : MenuController
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF контроллера меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    public WPFMenuController(MenuModel parModel) : base (parModel, new WPFMenuView(parModel))
    {
      _window = WindowKeeper.Instance.GetWindow();
    }

    /// <summary>
    /// Обрабатывает нажатие клавиши клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void KeyDownHandler(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Enter:
          Model.Enter();
          break;
        case Key.Up:
          Model.ChoosePreviousMenuItem();
          break;
        case Key.Down:
          Model.ChooseNextMenuItem();
          break;
      }
    }

    /// <summary>
    /// Запускает WPF контроллер меню
    /// </summary>
    public override void Start()
    {
      _window.KeyDown += KeyDownHandler;
      base.Start();
    }

    /// <summary>
    /// Останаливает WPF контроллер меню
    /// </summary>
    public override void Stop()
    {
      _window.KeyDown -= KeyDownHandler;
      base.Stop();
    }
  }
}
