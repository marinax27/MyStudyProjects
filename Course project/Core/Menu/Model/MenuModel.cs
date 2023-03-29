namespace Core.Menu.Model
{
  /// <summary>
  /// Модель меню
  /// </summary>
  public class MenuModel : MVC.Model
  {
    /// <summary>
    /// Событие о необходимости перерисовки
    /// </summary>
    public event Action? NeedRedrawEvent;
    /// <summary>
    /// Событие о нажатии на пункт меню
    /// </summary>
    public event dMainMenuClick? OnMenuClick;

    /// <summary>
    /// Индекс выбранного пункта
    /// </summary>
    private int _focusedIndex = 0;

    /// <summary>
    /// Меню
    /// </summary>
    private readonly MainMenu _menu = new MainMenu
      (
         MenuItem.NewGame,
         MenuItem.RecordsTable,
         MenuItem.Help,
         MenuItem.Exit
       );

    /// <summary>
    /// Индекс выбранного пункта
    /// </summary>
    public int FocusedIndex 
    { 
      get { return _focusedIndex; } 
    }

    /// <summary>
    /// Меню
    /// </summary>
    public MainMenu Menu 
    { 
      get { return _menu; } 
    }

    /// <summary>
    /// Выбирает следующий пункт меню
    /// </summary>
    public void ChooseNextMenuItem()
    {
      if (_focusedIndex < _menu.Items.Count - 1)
      {
        _focusedIndex++;
        NeedRedrawEvent?.Invoke();
      }
    }

    /// <summary>
    /// Выбирает предыдущий пункт меню
    /// </summary>
    public void ChoosePreviousMenuItem()
    {
      if (_focusedIndex > 0)
      {
        _focusedIndex--;
        NeedRedrawEvent?.Invoke();
      }
    }

    /// <summary>
    /// Выделяет пункт меню
    /// </summary>
    /// <param name="parIndex">Индекс пункта меню</param>
    public void FocusMenuItem(int parIndex)
    {
       _focusedIndex = parIndex;
      NeedRedrawEvent?.Invoke();
    }

    /// <summary>
    /// Нажимает на выбранный пункт меню
    /// </summary>
    public void Enter()
    {
      OnMenuClick?.Invoke(_menu.GetMenuItemByIndex(_focusedIndex));
    }

    /// <summary>
    /// Вызывает событие о необходимости перерисовки
    /// </summary>
    public void NeedRedraw()
    {
      NeedRedrawEvent?.Invoke();
    }

    /// <summary>
    /// Делегат на нажатие пункта меню
    /// </summary>
    /// <param name="parSelectedMenuItem">Пункт меню</param>
    public delegate void dMainMenuClick(MenuItem parSelectedMenuItem);
  }
}
