using Core.RecordsTable.Model;

namespace Core.RecordsTable
{
  /// <summary>
  /// Репозиторий таблицы рекордов
  /// </summary>
  public class RecordsTableRepository
  {
    /// <summary>
    /// Название файла
    /// </summary>
    private const string FILENAME = "Records.txt";

    /// <summary>
    /// Проверяет установлен ли рекорд
    /// </summary>
    /// <param name="parScore">Очки</param>
    /// <returns>Булево значение</returns>
    public static bool IsRecord(int parScore)
    {
      List<GameRecord> records = GetAllRecords();
      if (records.Count < 10)
      {
        return true;
      }
      foreach (GameRecord record in records)
      {
        if (record.Score < parScore)
        {
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Добавляет новый рекорд
    /// </summary>
    /// <param name="parRecord">Рекорд</param>
    public static void AddRecord(GameRecord parRecord)
    {
      List<GameRecord> records = GetAllRecords();
      records.Add(parRecord);
      SortRecords(records);

      if (records.Count > 10)
      {
        SaveRecords(records.GetRange(0, 10));
      }
      else
      {
        SaveRecords(records);
      }
    }

    /// <summary>
    /// Сохраняет рекорды в файл
    /// </summary>
    /// <param name="parRecords">Рекорды</param>
    public static void SaveRecords(List<GameRecord> parRecords)
    {
      if (!File.Exists(FILENAME))
      {
        File.Create(FILENAME);
      }

      StreamWriter sw = new StreamWriter(FILENAME);
      foreach (GameRecord record in parRecords)
      {
        sw.WriteLine(record.ToString());
      }
      sw.Close();
    }

    /// <summary>
    /// Получает все рекорды
    /// </summary>
    /// <returns>Все рекорды</returns>
    public static List<GameRecord> GetAllRecords()
    {
      List<GameRecord> result = new List<GameRecord>();
      if (!File.Exists(FILENAME))
      {
        File.Create(FILENAME);
        return new List<GameRecord>();
      }
      StreamReader sr = new StreamReader(FILENAME);
      string recordString = sr.ReadLine();
      while (recordString != null)
      {
        string[] splittedRecordString = recordString.Split(' ');
        result.Add(new GameRecord(splittedRecordString[0], int.Parse(splittedRecordString[1])));
        recordString = sr.ReadLine();
      }
      sr.Close();
      return result;
    }

    /// <summary>
    /// Сортирует рекорды по убыванию
    /// </summary>
    /// <param name="parRecords">Рекорды</param>
    private static void SortRecords(List<GameRecord> parRecords)
    {
      parRecords.Sort((GameRecord a, GameRecord b) =>
      {
        return b.Score.CompareTo(a.Score);
      });
    }
  }
}
