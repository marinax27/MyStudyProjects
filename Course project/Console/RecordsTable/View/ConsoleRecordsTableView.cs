using Core.RecordsTable.Model;
using Core.RecordsTable.View;

namespace Console.RecordsTable.View
{
  /// <summary>
  /// Консольное представление таблицы рекордов
  /// </summary>
  public class ConsoleRecordsTableView : RecordsTableView
  {
    /// <summary>
    /// Начальная координата Y для отрисовки представления
    /// </summary>
    private const int Y_START = 6;
    /// <summary>
    /// Расстояние по Y между пунктами в списке рекордов
    /// </summary>
    private const int Y_BIAS = 3;

    /// <summary>
    /// Конструктор консольного представления таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    public ConsoleRecordsTableView(RecordsTableModel parModel) : base(parModel)
    {
    }

    /// <summary>
    /// Рисует консольное представление таблицы рекордов
    /// </summary>
    public override void Draw()
    {
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Clear();

      string textInstruction = "для выхода - escape";
      System.Console.SetCursorPosition(2, 1);
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Write(textInstruction);

      string textHeader = "Р Е К О Р Д Ы";
      System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - textHeader.Length / 2, 3);
      System.Console.Write(textHeader);

      List<GameRecord> records = Model.GetRecords();
      for (int i = 0; i < records.Count; i++)
      {
        GameRecord record = records[i];
        
        string textRecord = $"{i + 1}  |  {record.PlayerName}  |  {record.Score} (очков)";
        System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - textRecord.Length / 2, Y_START + i * Y_BIAS);
        System.Console.Write(textRecord);
      }
    }

    /// <summary>
    /// Запускает консольное представление таблицы рекордов
    /// </summary>
    public override void Start()
    {
      Draw();
      base.Start();
    }

    /// <summary>
    /// Останавливает консольное представление таблицы рекордов
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      System.Console.Clear();
    }
  }
}
