using Core.View;
using Core.Game;
using Core.Game.Missile;
using Console.Game.View.ObjectsView;

namespace Console
{
  /// <summary>
  /// Консольное представление игры
  /// </summary>
  public class ConsoleGameView : GameView
  {
    /// <summary>
    /// Сжатие по X
    /// </summary>
    public const int COMPRESSION_X = 9;
    /// <summary>
    /// Сжатие по Y 
    /// </summary>
    public const int COMPRESSION_Y = 17;
    /// <summary>
    /// Цвет консоли
    /// </summary>
    private ConsoleColor _backColor;
    /// <summary>
    /// Нужно ли отрисовывать
    /// </summary>
    private bool _isNeedDraw;

    /// <summary>
    /// Конструктор консольного представления игры
    /// </summary>
    /// <param name="parModel">Модель игры</param>
    public ConsoleGameView(GameModel parModel) : base(parModel)
    {
    }

    /// <summary>
    /// Инициализирует консольное представление игры
    /// </summary>
    private void ViewInit()
    {
      _backColor = ConsoleColor.Cyan;
      SetWindow();
    }

    /// <summary>
    /// Настраивает окно
    /// </summary>
    private void SetWindow()
    {
    }

    /// <summary>
    /// Начинает отрисовку
    /// </summary>
    private void StartDrawing()
    {
      Model.LightningUsed += LightningDraw;
      _isNeedDraw = true;
      new Thread(Draw).Start();
    }

    /// <summary>
    /// Рисует молнию
    /// </summary>
    private void LightningDraw()
    {
      new Thread(() =>
      {
        for (int i = 0; i < 5; i++)
        {
          _backColor = ConsoleColor.White;
          Thread.Sleep(100);
          _backColor = ConsoleColor.Cyan;
          Thread.Sleep(100);
        }
      }).Start();
    }

    /// <summary>
    /// Рисует карту
    /// </summary>
    public override void Draw()
    {
      FastConsoleOutput.Init();
      while (_isNeedDraw)
      {
        Thread.Sleep(8);
        
        FastConsoleOutput.DrawRectangle(0, 0, ConsoleApplication.WINDOW_WIDTH, ConsoleApplication.WINDOW_HEIGHT, (short)_backColor);
        lock (Model.GameObjects)
        {
          FastConsoleOutput.SetString(0, 0, (int)ConsoleColor.White, "for moving - Up/Down/Right/Left, shoot - Z,");
          FastConsoleOutput.SetString(0, 1, (int)ConsoleColor.White, "lightning - X, exit - escape");

          foreach (GameObject elObject in Model.GameObjects)
          {
            GameObjectView view = GetObjectView(elObject);
            view.Draw();
          }
          FastConsoleOutput.Draw();
        }
      }
    }

    /// <summary>
    /// Получает представление объекта
    /// </summary>
    /// <param name="parObject">Объект</param>
    /// <returns></returns>
    /// <exception cref="Exception">Исключение</exception>
    private GameObjectView GetObjectView(GameObject parObject)
    {
      switch (parObject)
      {
        case Airplane _:
          return new AirplaneView((Airplane)parObject);
        case YellowAirplane _:
          return new YellowAirplaneView((YellowAirplane)parObject);
        case WhiteAirplane _:
          return new WhiteAirplaneView((WhiteAirplane)parObject);
        case WeaponMissile _:
          return new MissileView((WeaponMissile)parObject);
        case Bonus _:
          return new BonusView((Bonus)parObject);
        default:
          throw new Exception("Неизвестный объект для отрисовки!");
      }
    }

    /// <summary>
    /// Запускает консольное представление игры
    /// </summary>
    public override void Start()
    {
      ViewInit();
      StartDrawing();
      base.Start();
    }

    /// <summary>
    /// Останавливает консольное представление игры
    /// </summary>
    public override void Stop()
    {
      Model.LightningUsed -= LightningDraw;
      _isNeedDraw = false;
      System.Console.Clear();
      base.Stop();
    }
  }
}
