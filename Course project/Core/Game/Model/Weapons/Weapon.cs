namespace Core.Game
{
  /// <summary>
  /// Оружие
  /// </summary>
  public abstract class Weapon
  {
    /// <summary>
    /// Модель игры
    /// </summary>
    private GameModel _game;
    /// <summary>
    /// Урон
    /// </summary>
    private int _damage;

    /// <summary>
    /// Модель игры
    /// </summary>
    public GameModel Game
    {
      get { return _game; }
      set { _game = value; }
    }
    /// <summary>
    /// Урон
    /// </summary>
    public int Damage
    {
      get { return _damage; }
      set { _damage = value; }
    }

    /// <summary>
    /// Конструктор оружия
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parDamage">Урон</param>
    public Weapon(GameModel parGame, int parDamage) 
    {
      Game = parGame;
      Damage = parDamage;
    }

    /// <summary>
    /// Оружие стреляет
    /// </summary>
    /// <param name="parAirplane">Самолет</param>
    public abstract void Shoot(Airplane parAirplane);
  }
}
