namespace Core.Menu.Model
{
  /// <summary>
  /// Формирователь текста для пунктов меню
  /// </summary>
  public class MenuItemTextFormer
  {
    /// <summary>
    /// Получает текст для пункта меню
    /// </summary>
    /// <param name="parMenuItem">Пункт меню</param>
    /// <returns>Текст</returns>
    /// <exception cref="NotImplementedException">Исключение</exception>
    public static string GetTitle(MenuItem parMenuItem)
    {
      switch(parMenuItem)
      {
        case MenuItem.NewGame:
          return "Новая игра";
        case MenuItem.RecordsTable:
          return "Рекорды";
        case MenuItem.Help:
          return "Справка";
        case MenuItem.Exit:
          return "Выход";
        default: throw new NotImplementedException();
      }
    }
  }
}
