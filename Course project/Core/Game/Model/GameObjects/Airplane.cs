namespace Core.Game
{
  /// <summary>
  /// Самолет игрока
  /// </summary>
  public class Airplane : GameObject
  {
    /// <summary>
    /// Урон молнии
    /// </summary>
    public const int LIGHTNING_DAMAGE = 10;
    /// <summary>
    /// Расход энергии молнией
    /// </summary>
    public const int LIGHTNING_ENERGY_COST = 20;
    /// <summary>
    /// Смещение
    /// </summary>
    public const int OFFSET = 8;
    /// <summary>
    /// Количество кадров неуязвимости
    /// </summary>
    private const int INVULNERABILITY_FRAMES_AMOUNT = 60;
    /// <summary>
    /// Ширина
    /// </summary>
    public const int WIDTH = 30;
    /// <summary>
    /// Высота
    /// </summary>
    public const int HEIGHT = 50;
    /// <summary>
    /// Энергия
    /// </summary>
    public const int ENERGY_AMOUNT = 100;
    /// <summary>
    /// Здоровье
    /// </summary>
    public const int HEALTH_AMOUNT = 100;
    /// <summary>
    /// Здоровье
    /// </summary>
    private int _health;   
    /// <summary>
    /// Энергия
    /// </summary>
    private int _energy;
    /// <summary>
    /// Оружие
    /// </summary>
    private Weapon _weapon;
    /// <summary>
    /// Игровые очки
    /// </summary>
    private volatile int _score;
    /// <summary>
    /// Оставшееся количество кадров неуязвимости
    /// </summary>
    private int _invulnerabilityFrames;

    /// <summary>
    /// Событие использования молнии
    /// </summary>
    public event Action? LightningUsed;

    /// <summary>
    /// Здоровье
    /// </summary>
    public int Health
    {
      get { return _health; }
      set { _health = value; }
    }
    /// <summary>
    /// Энергия
    /// </summary>
    public int Energy
    {
      get { return _energy; }
      set { _energy = value; }
    }
    /// <summary>
    /// Оружие
    /// </summary>
    public Weapon Weapon
    {
      get { return _weapon; }
      set { _weapon = value; }
    }
    /// <summary>
    /// Игровые очки
    /// </summary>
    public int Score
    {
      get { return _score; }
      set { _score = value; }
    }

    /// <summary>
    /// Конструктор самолета игрока
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWeapon">Оружие</param>
    public Airplane(
      GameModel parGame, 
      double parX, 
      double parY, 
      Weapon parWeapon) 
      : base (
          parGame, 
          parX, 
          parY, 
          WIDTH, 
          HEIGHT, 
          0, 
          0)
    {
      Health = HEALTH_AMOUNT;
      Energy = ENERGY_AMOUNT;
      Weapon = parWeapon;
      Score = 0;
      _invulnerabilityFrames = 0;
    }

    /// <summary>
    /// Перемещает самолет вверх
    /// </summary>
    public void MoveUp()
    {
      if (Y > GameModel.SCREEN_TEXT_HEIGHT)
      {
        Y -= OFFSET;
        if (Y < GameModel.SCREEN_TEXT_HEIGHT)
        {
          Y = GameModel.SCREEN_TEXT_HEIGHT;
        }
      }
    }

    /// <summary>
    /// Перемещает самолет вниз
    /// </summary>
    public void MoveDown()
    {
      if (Y + Height < GameModel.SCREEN_HEIGHT)
      {
        Y += OFFSET;
        if (Y + Height > GameModel.SCREEN_HEIGHT)
        {
          Y = GameModel.SCREEN_HEIGHT - HEIGHT;
        }
      }
    }

    /// <summary>
    /// Перемещает самолет вправо
    /// </summary>
    public void MoveRight()
    {
      if (X + WIDTH < GameModel.SCREEN_WIDTH)
      {
        X += OFFSET;
        if (X + WIDTH > GameModel.SCREEN_WIDTH)
        {
          X = GameModel.SCREEN_WIDTH - WIDTH;
        }
      }
    }

    /// <summary>
    /// Перемещает самолет влево
    /// </summary>
    public void MoveLeft()
    {
      if (X > 0)
      {
        X -= OFFSET;
        if (X < 0)
        {
          X = 0;
        }
      }
    }

    /// <summary>
    /// Самолет стреляет
    /// </summary>
    public void Shoot()
    {
      Weapon.Shoot(this);
    }

    /// <summary>
    /// Самолет использует молнию
    /// </summary>
    public void UseLightning()
    {
      if (Energy - LIGHTNING_ENERGY_COST >= 0)
      {
        LightningUsed?.Invoke();
        Energy -= LIGHTNING_ENERGY_COST;
        new Thread(() =>
        {
          Thread.Sleep(500);

          lock (Game.GameObjects)
          {
            foreach (GameObject elGameObject in Game.GameObjects)
            {
              if (elGameObject is EnemyAirplane aircraft)
              {
                aircraft.TakeDamage(LIGHTNING_DAMAGE);
              }
            }
          }

        }).Start();
      } 
    }

    /// <summary>             
    /// Самолет получает урон
    /// </summary>
    /// <param name="parDamage">Урон</param>
    public void TakeDamage(int parDamage)
    {
      if (_invulnerabilityFrames <= 0)
      {
        Health -= parDamage;
        _invulnerabilityFrames = INVULNERABILITY_FRAMES_AMOUNT;
      }
    }

    /// <summary>
    /// Обновляет состояние самолета
    /// </summary>
    public override void Update()
    {
      if (_invulnerabilityFrames > 0)
      {
        _invulnerabilityFrames--;
      }
    }
  }
}
