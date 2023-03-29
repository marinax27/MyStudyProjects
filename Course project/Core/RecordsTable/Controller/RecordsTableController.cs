using Core.RecordsTable.Model;
using Core.RecordsTable.View;

namespace Core.RecordsTable.Controller
{
  /// <summary>
  /// Контроллер таблицы рекордов
  /// </summary>
  public abstract class RecordsTableController : MVC.Controller<RecordsTableModel, RecordsTableView>
  {
    /// <summary>
    /// Событие возвращения в меню
    /// </summary>
    public event Action? BackToMenuEvent;

    /// <summary>
    /// Конструктор таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    /// <param name="parView">Представление таблицы рекордов</param>
    public RecordsTableController(
      RecordsTableModel parModel, 
      RecordsTableView parView) 
      : base
      (parModel, 
       parView)
    {
    }

    /// <summary>
    /// Запускает контроллер таблицы рекордов
    /// </summary>
    public override void Start()
    {
      Model.UpdateRecords();
      base.Start();
    }

    /// <summary>
    /// Возвращает в меню
    /// </summary>
    public void BackToMenu()
    {
      BackToMenuEvent?.Invoke();
    }
  }
}
