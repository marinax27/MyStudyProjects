namespace Core.RecordsTable.Model
{
  /// <summary>
  /// Модель таблицы рекордов
  /// </summary>
  public class RecordsTableModel : MVC.Model
  {
    /// <summary>
    /// Событие о необходимости перерисовки
    /// </summary>
    public event Action? NeedRedrawEvent;
    /// <summary>
    /// Рекорды
    /// </summary>
    private List<GameRecord> _records;

    /// <summary>
    /// Вызывает событие о необходимости перерисовки
    /// </summary>
    public void NeedRedraw()
    {
      NeedRedrawEvent?.Invoke();
    }

    /// <summary>
    /// Получает таблицу рекордов
    /// </summary>
    /// <returns>Рекорды</returns>
    public List<GameRecord> GetRecords()
    {
      return _records;
    }

    /// <summary>
    /// Обновляет таблицу рекордов
    /// </summary>
    public void UpdateRecords()
    {
      _records = RecordsTableRepository.GetAllRecords();
    }
  }
}
