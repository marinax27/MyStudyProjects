using System.Windows;
using System.Windows.Input;
using Core.Help.Controller;
using Core.Help.Model;
using WPF.Help.View;

namespace WPF.Help.Controller
{
  /// <summary>
  /// WPF контроллер справки
  /// </summary>
  public class WPFHelpController : HelpController
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF контроллера справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    public WPFHelpController(HelpModel parModel) : base(parModel, new WPFHelpView(parModel))
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
      if (e.Key == Key.Escape)
      {
        BackToMenu();
      }
    }

    /// <summary>
    /// Запускает WPF контроллер справки
    /// </summary>
    public override void Start()
    {
      _window.KeyDown += KeyDownHandler;
      base.Start();
    }

    /// <summary>
    /// Останавливает WPF контроллер справки
    /// </summary>
    public override void Stop()
    {
      _window.KeyDown -= KeyDownHandler;
      base.Stop();
    }
  }
}
