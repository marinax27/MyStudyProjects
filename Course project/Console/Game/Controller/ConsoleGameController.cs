using Core.Game;
using Core.Controller;

namespace Console.ControllerConsole
{
  /// <summary>
  /// Консольный контроллер игры
  /// </summary>
  public class ConsoleGameController : GameController
  {
    /// <summary>
    /// Работает ли считывание клавиш
    /// </summary>
    private bool _isWorking;

    /// <summary>
    /// Конструктор консольного контроллера игры
    /// </summary>
    /// <param name="parModel">Модель игры</param>
    public ConsoleGameController(GameModel parModel) : base(parModel, new ConsoleGameView(parModel))
    {
    }

    /// <summary>
    /// Запускает считывание нажатых клавиш в консоли
    /// </summary>
    public void ReadKeysStart()
    {
      _isWorking = true;
      do
      {
        ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);
        switch (keyInfo.Key)
        {
          case ConsoleKey.Escape:
            BackToMenu();
            break;
          case ConsoleKey.Z:
            Model.Airplane.Shoot();
            break;
          case ConsoleKey.X:
            Model.Airplane.UseLightning();
            break;
          case ConsoleKey.LeftArrow:
            Model.Airplane.MoveLeft();
            break;
          case ConsoleKey.RightArrow:
            Model.Airplane.MoveRight();
            break;
          case ConsoleKey.UpArrow:
            Model.Airplane.MoveUp();
            break;
          case ConsoleKey.DownArrow:
            Model.Airplane.MoveDown();
            break;
        }
      } while (_isWorking); 
    }

    /// <summary>
    /// Останавливает считывание клавиш 
    /// </summary>
    public void ReadKeysStop()
    {
      _isWorking = false;
    }

    /// <summary>
    /// Запускает консольный контроллер игры
    /// </summary>
    public override void Start()
    {
      base.Start();
      ReadKeysStart();
    }

    /// <summary>
    /// Останавливает консольный контроллер игры
    /// </summary>
    public override void Stop()
    {
      ReadKeysStop();
      base.Stop();
    }
  }
}
