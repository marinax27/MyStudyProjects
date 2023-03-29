using Core.RecordsTable;
using Core.RecordsTable.Model;

namespace Core.GameResult.Model
{
  /// <summary>
  /// Модель результата игры
  /// </summary>
  public class GameResultModel : MVC.Model
  {
    /// <summary>
    /// Имя игрока
    /// </summary>
    private string _name;
    /// <summary>
    /// Очки
    /// </summary>
    private int _score;

    /// <summary>
    /// Событие о необходимости перерисовки
    /// </summary>
    public event Action? NeedRedrawEvent;

    /// <summary>
    /// Имя игрока
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        if (value.Length <= 15)
        {
          _name = value;
          NeedRedrawEvent?.Invoke();
        }
      }
    }
    /// <summary>
    /// Очки
    /// </summary>
    public int Score 
    { 
      get { return _score; } 
      set { _score = value; } 
    }

    /// <summary>
    /// Поставлен ли рекорд
    /// </summary>
    public bool IsRecord 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Устанавливает свойство поставлен ли рекорд 
    /// </summary>
    public void SetIsRecord()
    {
      IsRecord = RecordsTableRepository.IsRecord(Score);
      if (IsRecord)
      {
        Name = "Игрок";
      }
    }

    /// <summary>
    /// Получает текст, который выводится в конце игры
    /// </summary>
    /// <returns>Текст, который выводится в конце игры</returns>
    public string GetEndText()
    {
      string text = "";
      if (IsRecord)
      {
        text += $"Количество набранных очков: {Score}.\nВы установили рекорд! Введите имя ниже.";
      }
      else
      {
        text +=  $"Количество набранных очков: {Score}.\nВы не установили рекорд. Попробуйте еще раз!";
      }
      return text;
    }

    /// <summary>
    /// Сохраняет рекорд
    /// </summary>
    /// <returns>Булево значение</returns>
    public bool SaveRecord()
    {
      if (IsRecord && Name.Length > 0)
      {
        GameRecord gameRecord = new GameRecord(Name, Score);
        RecordsTableRepository.AddRecord(gameRecord);
        return true;
      }
      return false;
    }
  }
}
