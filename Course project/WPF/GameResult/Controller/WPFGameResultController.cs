using Core.GameResult.Controller;
using Core.GameResult.Model;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WPF.GameResult.Model;

namespace WPF.GameResult.Controller
{
  /// <summary>
  /// WPF контроллер результата игры
  /// </summary>
  public class WPFGameResultController : GameResultController
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF контроллера результата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    public WPFGameResultController(GameResultModel parModel) : 
      base(parModel, new WPFGameResultView(parModel))
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

      if (Model.IsRecord)
      {
        if (Regex.IsMatch(e.Key.ToString(), "^[A-Z]$"))
        {
          Model.Name += e.Key.ToString();
        }
        if (e.Key == Key.Back)
        {
          if (Model.Name.Length > 0)
          {
            Model.Name = Model.Name.Remove(Model.Name.Length - 1, 1);
          }
        }

        if (e.Key == Key.Enter)
        {
          if (Model.SaveRecord())
          {
            BackToMenu();
          }
        }
      }
    }

    /// <summary>
    /// Запускает WPF контроллер результата игры
    /// </summary>
    public override void Start()
    {
      _window.KeyDown += KeyDownHandler;
      base.Start();
    }

    /// <summary>
    /// Останавливает WPF контроллер результата игры
    /// </summary>
    public override void Stop()
    {
      _window.KeyDown -= KeyDownHandler;
      base.Stop();
    }
  }
}
