namespace Core.Help.Model
{
  /// <summary>
  /// Модель справки
  /// </summary>
  public class HelpModel : MVC.Model
  {
    /// <summary>
    /// Событие о необходимости перерисовки
    /// </summary>
    public event Action? NeedRedrawEvent;

    /// <summary>
    /// Текст спрваки
    /// </summary>
    private readonly string _text = Properties.Resources.HelpText;

    /// <summary>
    /// Получает текст справки
    /// </summary>
    /// <returns>Текст</returns>
    public string GetHelpText()
    {
      return _text;
    }

    /// <summary>
    /// Вызывает событие о необходимости перерисовки
    /// </summary>
    public void NeedRedraw()
    {
      NeedRedrawEvent?.Invoke();
    }
  }
}
