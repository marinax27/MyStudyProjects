using Core;

namespace Console
{
  /// <summary>
  /// Консольное приложение
  /// </summary>
  public class ConsoleApplication : MainApplication
  {
    /// <summary>
    /// Ширина окна
    /// </summary>
    public const int WINDOW_WIDTH = 60;
    /// <summary>
    /// Высота окна
    /// </summary>
    public const int WINDOW_HEIGHT = 40;

    /// <summary>
    /// Конструктор консольного приложения
    /// </summary>
    public ConsoleApplication() : base (new ConsoleControllersFactory())
    {
      ConfigureWindow();
    }

    /// <summary>
    /// Конфигурирует окно консольного приложения
    /// </summary>
    private void ConfigureWindow()
    {
      System.Console.WindowHeight = WINDOW_HEIGHT;
      System.Console.WindowWidth = WINDOW_WIDTH;
      System.Console.ForegroundColor = ConsoleColor.White;
      System.Console.CursorVisible = false;
      NeedExitEvent += () =>
      {
        System.Console.Clear();
      };
    }
  }
}
