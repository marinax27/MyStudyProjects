namespace Core.Game
{
  /// <summary>
  /// Вражеский самолет
  /// </summary>
  public abstract class EnemyAirplane : GameObject
  {
    /// <summary>
    /// Генератор псевдослучайных чисел
    /// </summary>
    private Random _random = new Random();
    /// <summary>
    /// Функция для описания логики передвижения самолета
    /// </summary>
    public Action MoveFunction 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Здоровье
    /// </summary>
    public int Health 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Урон, наносимый самолету игрока при столкновении
    /// </summary>
    public int BodyDamage 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Очки за уничтожение
    /// </summary>
    public int ScoreForDestroying 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор вражеского самолета
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parSpeedX">Скорость по X</param>
    /// <param name="parSpeedY">Скорость по Y</param>
    /// <param name="parHealth">Здоровье</param>
    /// <param name="parBodyDamage">Урон, наносимый самолету игрока при столкновении</param>
    /// <param name="parScoreForDestroying">Очки за уничтожение</param>
    public EnemyAirplane(
      GameModel parGame, 
      double parX, 
      double parY, 
      int parWidth, 
      int parHeight,
      double parSpeedX, 
      double parSpeedY,
      int parHealth, 
      int parBodyDamage, 
      int parScoreForDestroying) 
      : base(
          parGame, 
          parX, 
          parY, 
          parWidth, 
          parHeight, 
          parSpeedX,
          parSpeedY)
    {
      Health = parHealth;
      BodyDamage = parBodyDamage;
      ScoreForDestroying = parScoreForDestroying;
    }

    /// <summary>
    /// Вражеский самолет получает урон
    /// </summary>
    /// <param name="parDamage">Урон</param>
    public void TakeDamage(int parDamage)
    {
      Health -= parDamage;

      if (Health <= 0)
      {
        Game.RemoveGameObject(this);
        Game.Airplane.Score += ScoreForDestroying;
        if (_random.Next(0, 10) == 0)
        {
          Bonus bonus = new Bonus(Game, X + Width / 2, Y + Height / 2);
          Game.AddGameObject(bonus);
        }
      }
    }
  }
}
