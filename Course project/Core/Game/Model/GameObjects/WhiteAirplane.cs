using Core.Game.Missile;

namespace Core.Game
{
  /// <summary>
  /// Белый вражеский самолет
  /// </summary>
  public class WhiteAirplane : EnemyAirplane
  {
    /// <summary>
    /// Ширина
    /// </summary>
    public const int WIDTH = 30;
    /// <summary>
    /// Высота
    /// </summary>
    public const int HEIGHT = 60;
    /// <summary>
    /// Скорость по X
    /// </summary>
    public const double SPEED_X = 0.7;
    /// <summary>
    /// Скорость по Y
    /// </summary>
    public const int SPEED_Y = 0;
    /// <summary>
    /// Здоровье
    /// </summary>
    public const int HEALTH = 40;
    /// <summary>
    /// Урон, наносимый самолету игрока при столкновении
    /// </summary>
    public const int BODY_DAMAGE = 15;
    /// <summary>
    /// Очки за уничтожение
    /// </summary>
    public const int SCORE_FOR_DESTROYING = 20;
    /// <summary>
    /// Начальное количество кадров перед выстрелом
    /// </summary>
    public const int FRAMES_BEFORE_SHOOT_AMOUNT = 120;
    /// <summary>
    /// Смещение по Y
    /// </summary>
    private const int OFFSET_Y = 5;
    /// <summary>
    /// Урон снаряда
    /// </summary>
    private const int MISSILE_DAMAGE = 10;
    /// <summary>
    /// Количество кадров перед выстрелом
    /// </summary>
    private int _framesBeforeShoot;

    /// <summary>
    /// Конструктор белого вражеского самолета
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public WhiteAirplane(
      GameModel parGame, 
      double parX, 
      double parY) 
      : base(
          parGame, 
          parX, 
          parY, 
          WIDTH, 
          HEIGHT, 
          SPEED_X, 
          SPEED_Y, 
          HEALTH, 
          BODY_DAMAGE, 
          SCORE_FOR_DESTROYING)
    {
      _framesBeforeShoot = FRAMES_BEFORE_SHOOT_AMOUNT;
    }

    /// <summary>
    /// Белый вражеский самолет стреляет
    /// </summary>
    private void Shoot()
    {
      double x = X + Width / 2;
      double y = Y + HEIGHT + OFFSET_Y;
      WeaponMissile missle = new WeaponMissile(
        Game, x, y, 10, 10, 0, 1, MissileType.EnemyMissile, MISSILE_DAMAGE);
      Game.AddGameObject(missle);
    }

    /// <summary>
    /// Проверяет возможность выстрелить
    /// </summary>
    private void CheckShoot()
    {
      if (_framesBeforeShoot > 0)
      {
        _framesBeforeShoot--;
      }
      else
      {
        _framesBeforeShoot = FRAMES_BEFORE_SHOOT_AMOUNT;
        Shoot();
      }
    }

    /// <summary>
    /// Обновляет состояние белого вражеского самолета
    /// </summary>
    public override void Update()
    {
      MoveFunction();
      CheckShoot();
      if (CheckCollision(this, Game.Airplane))
      {
        Game.Airplane.TakeDamage(BodyDamage);
      }
      if (X > GameModel.SCREEN_WIDTH || X + WIDTH < 0)
      {
        Game.RemoveGameObject(this);
      }
    }
  }
}
