using System.Windows;
using Core;

namespace WPF
{
  /// <summary>
  /// WPF приложение
  /// </summary>
  public class WPFApplication : MainApplication
  {
    /// <summary>
    /// Ширина окна
    /// </summary>
    public const int WINDOW_WIDTH = 500;
    /// <summary>
    /// Высота окна
    /// </summary>
    public const int WINDOW_HEIGHT = 700;

    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF приложения
    /// </summary>
    public WPFApplication() : base(new WPFControllersFactory())
    {
      _window = WindowKeeper.Instance.GetWindow();
      ConfigureWindow();
    }

    /// <summary>
    /// Конфигурирует окно приложения
    /// </summary>
    private void ConfigureWindow()
    {
      NeedExitEvent += () => _window.Close();
    }

    /// <summary>
    /// Запускает WPF приложение
    /// </summary>
    public override void Start()
    {
      _window.Show();
      base.Start();
    }
  }
}
