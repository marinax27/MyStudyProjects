namespace Core.Game
{
  /// <summary>
  /// Зеленый вражеский самолет
  /// </summary>
  public class YellowAirplane : EnemyAirplane
  {
    /// <summary>
    /// Ширина
    /// </summary>
    public const int WIDTH = 10;
    /// <summary>
    /// Высота
    /// </summary>
    public const int HEIGHT = 20;
    /// <summary>
    /// Скорость по X
    /// </summary>
    public const double SPEED_X = 0.5;
    /// <summary>
    /// Скорость по Y
    /// </summary>
    public const int SPEED_Y = 0;
    /// <summary>
    /// Здоровье
    /// </summary>
    public const int HEALTH = 10;
    /// <summary>
    /// Урон, наносимый самолету игрока при столкновении
    /// </summary>
    public const int BODY_DAMAGE = 10;
    /// <summary>
    /// Очки за уничтожение
    /// </summary>
    public const int SCORE_FOR_DESTROYING = 5;

    /// <summary>
    /// Конструктор зеленого самолета
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public YellowAirplane(
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
    }

    /// <summary>
    /// Обновляет состояние зеленого вражеского самолета
    /// </summary>
    public override void Update()
    {
      MoveFunction();
      if (CheckCollision(this, Game.Airplane))
      {
        Game.Airplane.TakeDamage(BodyDamage);
      }
      if (X > GameModel.SCREEN_WIDTH || X + Width < 0)
      {
        Game.RemoveGameObject(this);
      }
    }
  }
}
