namespace Core.RecordsTable.Model
{
  /// <summary>
  /// Игровой рекорд
  /// </summary>
  public class GameRecord
  {
    /// <summary>
    /// Имя игрока
    /// </summary>
    public string PlayerName 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Очки
    /// </summary>
    public int Score 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор игрового рекорда
    /// </summary>
    /// <param name="parPlayerName">Имя игрока</param>
    /// <param name="parScore">Очки</param>
    public GameRecord(string parPlayerName, int parScore)
    {
      PlayerName = parPlayerName;
      Score = parScore;
    }

    /// <summary>
    /// Получает строку
    /// </summary>
    /// <returns>Строка</returns>
    public override string ToString()
    {
      return $"{PlayerName} {Score}";
    }
  }
}
