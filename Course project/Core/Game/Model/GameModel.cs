using Core.MVC;
using Core.Game.Weapons;

namespace Core.Game
{
  /// <summary>
  /// Модель игры
  /// </summary>
  public class GameModel : Model
  {
    /// <summary>
    /// Ширина окна
    /// </summary>
    public const int SCREEN_WIDTH = 500;
    /// <summary>
    /// Высота окна
    /// </summary>
    public const int SCREEN_HEIGHT = 700;
    /// <summary>
    /// Высота текстовой информации
    /// </summary>
    public const int SCREEN_TEXT_HEIGHT = 50;
    /// <summary>
    /// Список игровых объектов
    /// </summary>
    private static List<GameObject> _gameObjects;
    /// <summary>
    /// Самолет игрока
    /// </summary>
    private static Airplane _airplane;
    /// <summary>
    /// Генератор случайных чисел
    /// </summary>
    private Random _random = new Random();

    /// <summary>
    /// Запущена ли игра
    /// </summary>
    private bool _isPlaying;

    /// <summary>
    /// Событие завершения игры
    /// </summary>
    public event dGameFinished? GameFinished;
    /// <summary>
    /// Событие использования молнии 
    /// </summary>
    public event Action? LightningUsed;
    /// <summary>
    /// Событие остановки игры
    /// </summary>
    public event Action? GameStopped;

    /// <summary>
    /// Список игровых объектов
    /// </summary>
    public List<GameObject> GameObjects
    {
      get { return _gameObjects; }
      set { _gameObjects = value; }
    }

    /// <summary>
    /// Самолет игрока
    /// </summary>
    public Airplane Airplane
    {
      get { return _airplane; }
      set { _airplane = value; }
    }

    /// <summary>
    /// Конструктор модели игры
    /// </summary>
    public GameModel()
    {
      GameObjects = new List<GameObject>();
    }


    /// <summary>
    /// Инициализирует модель игры
    /// </summary>
    public void Init()
    {
      GameObjects.Clear();
      MachineGun machineGun = new MachineGun(this, 10);

      Airplane = new Airplane(this, 200, 400, machineGun);
      Airplane.LightningUsed += () => LightningUsed?.Invoke();
      AddGameObject(Airplane);

      StartGenerateEnemies();
    }

    /// <summary>
    /// Запускает генерацию вражеских самолетов
    /// </summary>
    private void StartGenerateEnemies()
    {
      new Thread(() =>
      {
        int waveCount = 3;
        bool isContinue = true;
        GameStopped += () => isContinue = false;
        GameFinished += (_) => isContinue = false;
        while (isContinue)
        {
          new Thread(() =>
          {
            for (int i = 0; i < waveCount / 3; i++)
            {
              WhiteAirplane whiteAirplane = new WhiteAirplane(this, 0, _random.Next(SCREEN_TEXT_HEIGHT, SCREEN_HEIGHT - WhiteAirplane.HEIGHT));
              if (_random.Next(0, 2) == 0)
              {
                whiteAirplane.X = SCREEN_WIDTH - whiteAirplane.Width;
                whiteAirplane.SpeedX = -whiteAirplane.SpeedX;
              }

              whiteAirplane.MoveFunction = () =>
              {
                whiteAirplane.X += whiteAirplane.SpeedX;
              };
              AddGameObject(whiteAirplane);
              Thread.Sleep(1500);
              if (!isContinue)
              {
                break;
              }
            }
          }).Start();

          new Thread(() =>
          {
            int offset = _random.Next(15, 45);
            bool isLeft = _random.Next(0, 2) == 0;
            
            for (int i = 0; i < waveCount; i++)
            {
              YellowAirplane yellowAirplane = new YellowAirplane(this, 0, 0);
              if (isLeft)
              {
                yellowAirplane.X = SCREEN_WIDTH - yellowAirplane.Width;
                yellowAirplane.SpeedX = -yellowAirplane.SpeedX;
              }

              yellowAirplane.MoveFunction = () =>
              {
                yellowAirplane.X += yellowAirplane.SpeedX;
                yellowAirplane.Y = SCREEN_HEIGHT - (Math.Pow(yellowAirplane.X / 8 - offset, 2) + 50);
              };
              AddGameObject(yellowAirplane);
              Thread.Sleep(900);
              if (!isContinue)
              {
                break;
              }
            }
          }).Start();
          Thread.Sleep(8000 + 700 * (waveCount));
          waveCount++;
        }
      }).Start();
    }

    /// <summary>
    /// Начинает игру
    /// </summary>
    public void Start()
    {
      Init();
      _isPlaying = true;
      Thread thread = new Thread(() =>
      {
        while (_isPlaying)
        {
          lock (GameObjects)
          {
            foreach (GameObject elGameObject in GameObjects)
            {
              elGameObject.Update();
            }
          }

          if (Airplane.Health <= 0)
          {
            GameFinished?.Invoke(Airplane.Score);
            break;
          }
          Thread.Sleep(15);
        }
      });
      thread.Start();
    }

    /// <summary>
    /// Останавливает игру
    /// </summary>
    public void Stop()
    {
      _isPlaying = false;
      GameStopped?.Invoke();
    }

    /// <summary>
    /// Добавляет объект
    /// </summary>
    /// <param name="parGameObject">Игровой объект</param>
    public void AddGameObject(GameObject parGameObject)
    {
      new Thread(() =>
      {
        lock (GameObjects)
        {
          GameObjects.Add(parGameObject);
        }
      }).Start();  
    }

    /// <summary>
    /// Удаляет объект
    /// </summary>
    /// <param name="parGameObject">Игровой объект</param>
    public void RemoveGameObject(GameObject parGameObject)
    {
      new Thread(() =>
      {
        lock (GameObjects)
        {
          GameObjects.Remove(parGameObject);
        }
      }).Start();
    }

    /// <summary>
    /// Завершает игру
    /// </summary>
    public void End()
    {
      GameFinished?.Invoke(Airplane.Score);
    }

    /// <summary>
    /// Делегат на завершение игры
    /// </summary>
    /// <param name="parScore">Очки</param>
    public delegate void dGameFinished(int parScore);
  }
}
