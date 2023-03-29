using System.Windows;
using System.Windows.Input;
using Core.RecordsTable.Controller;
using Core.RecordsTable.Model;
using WPF.RecordsTable.View;

namespace WPF.RecordsTable.Controller
{
  /// <summary>
  /// WPF контроллер таблицы рекордов
  /// </summary>
  public class WPFRecordsTableController : RecordsTableController
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF контроллера таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    public WPFRecordsTableController(RecordsTableModel parModel) : 
      base(parModel, new WPFRecordsTableView(parModel))
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
    /// Запускает WPF контроллер таблицы рекордов
    /// </summary>
    public override void Start()
    {
      _window.KeyDown += KeyDownHandler;
      base.Start();
    }

    /// <summary>
    /// Останавливает WPF контроллер таблицы рекордов
    /// </summary>
    public override void Stop()
    {
      _window.KeyDown -= KeyDownHandler;
      base.Stop();
    }
  }
}
