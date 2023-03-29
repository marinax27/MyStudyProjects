using Core.Controller;
using Core.GameResult.Controller;
using Core.Help.Controller;
using Core.Menu.Controller;
using Core.RecordsTable.Controller;

namespace Core
{
  /// <summary>
  /// Приложение
  /// </summary>
  public class MainApplication
  {
    /// <summary>
    /// Контроллер меню
    /// </summary>
    private readonly MenuController _menuController;
    /// <summary>
    /// Контроллер игры
    /// </summary>
    private readonly GameController _gameController;
    /// <summary>
    /// Контроллер таблицы рекордов
    /// </summary>
    private readonly RecordsTableController _recordsTableController;
    /// <summary>
    /// Контроллер справки
    /// </summary>
    private readonly HelpController _helpController;
    /// <summary>
    /// Контроллер результата игры
    /// </summary>
    private readonly GameResultController _gameResultController;

    /// <summary>
    /// Событие о необходимость выйти
    /// </summary>
    public event Action? NeedExitEvent;

    /// <summary>
    /// Конструктор приложения
    /// </summary>
    /// <param name="parFactory">Фабрика контроллеров</param>
    public MainApplication(AbstractControllersFactory parFactory)
    {
      _menuController = parFactory.CreateMenuController();
      _gameController = parFactory.CreateGameController();
      _recordsTableController = parFactory.CreateRecordsTableController();
      _helpController = parFactory.CreateHelpController();
      _gameResultController = parFactory.CreateGameResultController();
      Init();
    }

    /// <summary>
    /// Инициализирует приложение
    /// </summary>
    private void Init()
    {
      InitMenuController();
      InitGameController();
      InitRecordsTableController();
      InitHelpController();
      InitGameResultController();
    }

    /// <summary>
    /// Инициализирует контроллер меню
    /// </summary>
    private void InitMenuController()
    {
      _menuController.NeedGoToGameEvent += () =>
      {
        _menuController.Stop();
        _gameController.Start();
      };
      _menuController.NeedGoToHelpEvent += () =>
      {
        _menuController.Stop();
        _helpController.Start();
      };
      _menuController.NeedGoToRecordsTableEvent += () =>
      {
        _menuController.Stop();
        _recordsTableController.Start();
      };
      _menuController.NeedExitEvent += () =>
      {
        _menuController.Stop();
        NeedExitEvent?.Invoke();
      };
    }

    /// <summary>
    /// Инициализирует контроллер игры
    /// </summary>
    private void InitGameController()
    {
      _gameController.GameFinished += (parScore) =>
      {
        _gameController.Stop();
        _gameResultController.SetGameResult(parScore);
        _gameResultController.Start();   
      };
      _gameController.BackToMenuEvent += () =>
      {
        _gameController.Stop();
        _menuController.Start();
      };
    }

    /// <summary>
    /// Инициализирует контроллер таблицы рекордов
    /// </summary>
    private void InitRecordsTableController()
    {
      _recordsTableController.BackToMenuEvent += () =>
      {
        _recordsTableController.Stop();
        _menuController.Start();
      };
    }

    /// <summary>
    /// Инициализирует контроллер справки
    /// </summary>
    private void InitHelpController()
    {
      _helpController.BackToMenuEvent += () =>
      {
        _helpController.Stop();
        _menuController.Start();
      };
    }

    /// <summary>
    /// Инициализирует контроллер результата игры
    /// </summary>
    private void InitGameResultController()
    {
      _gameResultController.BackToMenuEvent += () =>
      {
        _gameResultController.Stop();
        _menuController.Start();
      };
    }

    /// <summary>
    /// Запускает приложение
    /// </summary>
    public virtual void Start()
    {
       _menuController.Start();
    }
  }
}
