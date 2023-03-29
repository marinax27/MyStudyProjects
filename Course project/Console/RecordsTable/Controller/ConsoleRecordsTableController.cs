using Console.RecordsTable.View;
using Core.RecordsTable.Controller;
using Core.RecordsTable.Model;

namespace Console.RecordsTable.Controller
{
  /// <summary>
  /// Консольный контроллер таблицы рекордов
  /// </summary>
  public class ConsoleRecordsTableController : RecordsTableController
  {
    /// <summary>
    /// Работает ли считывание клавиш
    /// </summary>
    private bool _isWorking;

    /// <summary>
    /// Конструктор консольного контроллера таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    public ConsoleRecordsTableController(RecordsTableModel parModel) 
      : base(parModel, new ConsoleRecordsTableView(parModel))
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
    /// Останавливает считывание клавиш
    /// </summary>
    public void ReadKeysStop()
    {
      _isWorking = false;
    }

    /// <summary>
    /// Запускает консольный контроллер таблицы рекордов
    /// </summary>
    public override void Start()
    {
      base.Start();
      ReadKeysStart();
    }

    /// <summary>
    /// Останавливает консольный контроллер таблицы рекордов
    /// </summary>
    public override void Stop()
    {
      ReadKeysStop();
      base.Stop();
    }
  }
}
