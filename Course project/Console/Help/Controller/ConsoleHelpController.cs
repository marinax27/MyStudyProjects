using Console.Help.View;
using Core.Help.Controller;
using Core.Help.Model;

namespace Console.Help.Controller
{
  /// <summary>
  /// Консольный контроллер справки
  /// </summary>
  public class ConsoleHelpController : HelpController
  {
    /// <summary>
    /// Работает ли считывание клавиш
    /// </summary>
    private bool _isWorking;

    /// <summary>
    /// Конструктор консольного контроллера справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    public ConsoleHelpController(HelpModel parModel) : base(parModel, new ConsoleHelpView(parModel))
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
        }
      } while (_isWorking);
    }

    /// <summary>
    /// Останавлиает считывание клавиш
    /// </summary>
    public void ReadKeysStop()
    {
      _isWorking = false;
    }

    /// <summary>
    /// Запускает консольный контроллер справки
    /// </summary>
    public override void Start()
    {
      base.Start();
      ReadKeysStart();
    }

    /// <summary>
    /// Останавливает консольный контроллер справки
    /// </summary>
    public override void Stop()
    {
      ReadKeysStop();
      base.Stop();
    }
  }
}
