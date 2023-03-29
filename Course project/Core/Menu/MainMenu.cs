namespace Core.Menu
{
  /// <summary>
  /// Меню
  /// </summary>
  public class MainMenu
  {
    /// <summary>
    /// Список пунктов меню
    /// </summary>
    private readonly List<MenuItem> _items;

    /// <summary>
    /// Список пунктов меню
    /// </summary>
    public List<MenuItem> Items 
    { 
      get { return _items; } 
    }

    /// <summary>
    /// Конструктор меню
    /// </summary>
    /// <param name="parItems">Пункты меню</param>
    public MainMenu(params MenuItem[] parItems)
    {
      _items = parItems.ToList();
    }

    /// <summary>
    /// Получает пункт меню по индексу
    /// </summary>
    /// <param name="parIndex">Индекс пункта меню</param>
    /// <returns></returns>
    public MenuItem GetMenuItemByIndex(int parIndex)
    {
      return _items[parIndex];
    }
  }
}
