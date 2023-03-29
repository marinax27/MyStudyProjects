using Console.ControllerConsole;
using Console.GameResult.Controller;
using Console.Help.Controller;
using Console.Menu.Controller;
using Console.RecordsTable.Controller;
using Core;
using Core.Controller;
using Core.Game;
using Core.GameResult.Controller;
using Core.GameResult.Model;
using Core.Help.Controller;
using Core.Help.Model;
using Core.Menu.Controller;
using Core.Menu.Model;
using Core.RecordsTable.Controller;
using Core.RecordsTable.Model;

namespace Console
{
  /// <summary>
  /// Фабрика консольных контроллеров
  /// </summary>
  public class ConsoleControllersFactory : AbstractControllersFactory
  {
    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public override GameController CreateGameController()
    {
      return new ConsoleGameController(new GameModel());
    }

    /// <summary>
    /// Создает контроллер результата игры
    /// </summary>
    /// <returns>Контроллер результата игры</returns>
    public override GameResultController CreateGameResultController()
    {
      return new ConsoleGameResultController(new GameResultModel());
    }

    /// <summary>
    /// Создает контроллер справки
    /// </summary>
    /// <returns>Контроллер справки</returns>
    public override HelpController CreateHelpController()
    {
      return new ConsoleHelpController(new HelpModel());
    }

    /// <summary>
    /// Создает контроллер меню
    /// </summary>
    /// <returns>Контроллер меню</returns>
    public override MenuController CreateMenuController()
    {
      return new ConsoleMenuController(new MenuModel());
    }

    /// <summary>
    /// Создает контроллер таблицы рекордов
    /// </summary>
    /// <returns>Контроллер таблицы рекордов</returns>
    public override RecordsTableController CreateRecordsTableController()
    {
      return new ConsoleRecordsTableController(new RecordsTableModel());
    }
  }
}
