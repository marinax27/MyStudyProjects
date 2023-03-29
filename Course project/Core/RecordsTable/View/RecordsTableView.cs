using Core.RecordsTable.Model;

namespace Core.RecordsTable.View
{
  /// <summary>
  /// Представление таблицы рекордов
  /// </summary>
  public abstract class RecordsTableView : MVC.View<RecordsTableModel>
  {
    /// <summary>
    /// Конструктор представления таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    public RecordsTableView(RecordsTableModel parModel) : base(parModel)
    {
      parModel.NeedRedrawEvent += Redraw;
    }

    /// <summary>
    /// Перерисовывает представление таблицы рекордов
    /// </summary>
    private void Redraw()
    {
      if (IsStarted)
      {
        Draw();
      }
    }
  }
}
