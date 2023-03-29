using Core.Controller;
using Core.GameResult.Controller;
using Core.Help.Controller;
using Core.Menu.Controller;
using Core.RecordsTable.Controller;

namespace Core
{
  /// <summary>
  /// Фабрика контроллеров
  /// </summary>
  public abstract class AbstractControllersFactory
  {
    /// <summary>
    /// Создает контроллер меню
    /// </summary>
    /// <returns>Контроллер меню</returns>
    public abstract MenuController CreateMenuController();
    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public abstract GameController CreateGameController();
    /// <summary>
    /// Создает контроллер таблицы рекордов
    /// </summary>
    /// <returns>Контроллер таблицы рекордов</returns>
    public abstract RecordsTableController CreateRecordsTableController();
    /// <summary>
    /// Создает контроллер справки
    /// </summary>
    /// <returns>Контроллер справки</returns>
    public abstract HelpController CreateHelpController();
    /// <summary>
    /// Создает контроллер результата игры
    /// </summary>
    /// <returns>Контроллер результата игры</returns>
    public abstract GameResultController CreateGameResultController();
  }
}
