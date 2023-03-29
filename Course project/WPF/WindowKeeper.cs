using System;
using System.Windows;

namespace WPF
{
  /// <summary>
  /// Хранитель окон
  /// </summary>
  public class WindowKeeper
  {
    /// <summary>
    /// Корректирующее смещение для ширины
    /// </summary>
    private const int CORRECTIVE_OFFSET_WIDTH = 16;
    /// <summary>
    /// Корректирующее смещение для высоты
    /// </summary>
    private const int CORRECTIVE_OFFSET_HEIGHT = 39;

    /// <summary>
    /// Хранитель сущности
    /// </summary>
    private static readonly Lazy<WindowKeeper> instanceHolder =
        new Lazy<WindowKeeper>(() => new WindowKeeper());

    /// <summary>
    /// Окно
    /// </summary>
    private Window _window;

    /// <summary>
    /// Конструктор хранителя окон
    /// </summary>
    private WindowKeeper()
    {
      _window = new Window();
      _window.Width = WPFApplication.WINDOW_WIDTH + CORRECTIVE_OFFSET_WIDTH;
      _window.Height = WPFApplication.WINDOW_HEIGHT + CORRECTIVE_OFFSET_HEIGHT;
      _window.ResizeMode = ResizeMode.NoResize;
      _window.Title = "The Battle of Midway";
      _window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    /// <summary>
    /// Сущность
    /// </summary>
    public static WindowKeeper Instance
    {
      get { return instanceHolder.Value; }
    }

    /// <summary>
    /// Получает окно
    /// </summary>
    /// <returns></returns>
    public Window GetWindow()
    {
      return _window;
    }
  }
}
