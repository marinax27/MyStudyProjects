using System.Text.RegularExpressions;
using Console.GameResult.View;
using Core.GameResult.Controller;
using Core.GameResult.Model;

namespace Console.GameResult.Controller
{
  /// <summary>
  /// Консольный контроллер результата игры
  /// </summary>
  public class ConsoleGameResultController : GameResultController
  {
    /// <summary>
    /// Работает ли считывание клавиш
    /// </summary>
    private bool _isWorking;

    /// <summary>
    /// Конструктор консольного контроллера результата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    public ConsoleGameResultController(GameResultModel parModel) 
      : base(parModel, new ConsoleGameResultView(parModel))
    {
    }

    /// <summary>
    /// Запускает считывание нажатых клавиш в консоли
    /// </summary>
    public void ReadKeysStart()
    {
      _isWorking = true;
      new Thread(() =>
      {
        do
        {
          ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);

          if (keyInfo.Key == ConsoleKey.Escape)
          {
            BackToMenu();
          }

          if (Model.IsRecord)
          {
            if (Regex.IsMatch(keyInfo.KeyChar.ToString(), "^[A-Za-z0-9А-Яа-я-_]$"))
            {
              Model.Name += keyInfo.KeyChar.ToString();
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
              if (Model.Name.Length > 0)
              {
                Model.Name = Model.Name.Remove(Model.Name.Length - 1, 1);
              }
            }

            if (keyInfo.Key == ConsoleKey.Enter)
            {
              if (Model.SaveRecord())
              {
                BackToMenu();
              }
            }
          }
        } while (_isWorking);
      }).Start();
    }

    /// <summary>
    /// Останавливает считывание клавиш
    /// </summary>
    public void ReadKeysStop()
    {
      _isWorking = false;
    }

    /// <summary>
    /// Запускает консольный контроллер результата игры
    /// </summary>
    public override void Start()
    {
      base.Start();
      ReadKeysStart();
    }

    /// <summary>
    /// Останавливает консольный контроллер результата игры
    /// </summary>
    public override void Stop()
    {
      ReadKeysStop();
      base.Stop();
    }
  }
}
