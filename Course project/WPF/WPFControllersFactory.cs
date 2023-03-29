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
using WPF.GameResult.Controller;
using WPF.Help.Controller;
using WPF.Menu.Controller;
using WPF.RecordsTable.Controller;
using WPF.WPFController;

namespace WPF
{
  /// <summary>
  /// Фабрика WPF контроллеров
  /// </summary>
  public class WPFControllersFactory : AbstractControllersFactory
  {

    /// <summary>
    /// Конструктор фабрики WPF контроллеров
    /// </summary>
    public WPFControllersFactory()
    {
    }

    /// <summary>
    /// Создает контроллер игры
    /// </summary>
    /// <returns>Контроллер игры</returns>
    public override GameController CreateGameController()
    {
      GameModel gameModel = new GameModel();
      return new WPFGameController(gameModel);
    }

    /// <summary>
    /// Создает контроллер результата игры
    /// </summary>
    /// <returns>Контроллер результата игры</returns>
    public override GameResultController CreateGameResultController()
    {
      GameResultModel gameEndedScreenModel = new GameResultModel();
      return new WPFGameResultController(gameEndedScreenModel);
    }

    /// <summary>
    /// Создает контроллер справки
    /// </summary>
    /// <returns>Контроллер справки</returns>
    public override HelpController CreateHelpController()
    {
      HelpModel helpModel = new HelpModel();
      return new WPFHelpController(helpModel);
    }

    /// <summary>
    /// Создает контроллер меню
    /// </summary>
    /// <returns>Контроллер меню</returns>
    public override MenuController CreateMenuController()
    {
      MenuModel menuModel = new MenuModel();
      return new WPFMenuController(menuModel);
    }

    /// <summary>
    /// Создает контроллер таблицы рекордов
    /// </summary>
    /// <returns>Контроллер таблицы рекордов</returns>
    public override RecordsTableController CreateRecordsTableController()
    {
      RecordsTableModel recordsModel = new RecordsTableModel();
      return new WPFRecordsTableController(recordsModel);
    }
  }
}
