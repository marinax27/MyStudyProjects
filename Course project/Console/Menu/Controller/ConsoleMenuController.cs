using Console.Menu.View;
using Core.Menu.Controller;
using Core.Menu.Model;

namespace Console.Menu.Controller
{
  /// <summary>
  /// Консольный контроллер меню
  /// </summary>
  public class ConsoleMenuController : MenuController
  {
    /// <summary>
    /// Работает ли считывание клавиш
    /// </summary>
    private bool _isWorking;

    /// <summary>
    /// Конструктор консольного контроллера меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    public ConsoleMenuController(MenuModel parModel) : base(parModel, new ConsoleMenuView(parModel))
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
          case ConsoleKey.UpArrow:
            Model.ChoosePreviousMenuItem();
            break;
          case ConsoleKey.DownArrow:
            Model.ChooseNextMenuItem();
            break;
          case ConsoleKey.Enter:
            Model.Enter();
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
    /// Запускает консольный контроллер меню
    /// </summary>
    public override void Start()
    {
      base.Start();
      ReadKeysStart();
    }

    /// <summary>
    /// Останавливает консольный контроллер меню
    /// </summary>
    public override void Stop()
    {
      ReadKeysStop();
      base.Stop();
    }
  }
}
