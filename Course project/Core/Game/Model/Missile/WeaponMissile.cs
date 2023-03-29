namespace Core.Game.Missile
{
  /// <summary>
  /// Снаряд
  /// </summary>
  public class WeaponMissile : GameObject
  {
    /// <summary>
    /// Тип снаряда
    /// </summary>
    private MissileType _missileType;
    /// <summary>
    /// Урон
    /// </summary>
    private int _damage;

    /// <summary>
    /// Тип снаряда
    /// </summary>
    public MissileType MissileType
    {
      get { return _missileType; }
      set { _missileType = value; }
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
    /// Конструктор снаряда
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parSpeedX">Скорость по X</param>
    /// <param name="parSpeedY">Скорость по Y</param>
    /// <param name="parMissileType">Тип снаряда</param>
    /// <param name="parDamage">Урон</param>
    public WeaponMissile(
      GameModel parGame, 
      double parX, 
      double parY, 
      int parWidth,
      int parHeight, 
      double parSpeedX, 
      double parSpeedY, 
      MissileType parMissileType,
      int parDamage)
      : base(
          parGame, 
          parX, 
          parY,
          parWidth,
          parHeight, 
          parSpeedX, 
          parSpeedY)
    {
      MissileType = parMissileType;
      Damage = parDamage;
    }

    /// <summary>
    /// Обновляет состояния снаряда
    /// </summary>
    public override void Update()
    {
      X += SpeedX;
      Y += SpeedY;

      if (MissileType.Equals(MissileType.EnemyMissile))
      {
        if (CheckCollision(Game.Airplane, this))
        {
          Game.RemoveGameObject(this);
          Game.Airplane.TakeDamage(Damage); 
        }
      }
      else
      {
        foreach (GameObject elGameObject in Game.GameObjects)
        {
          if (elGameObject is EnemyAirplane enemyAirplane)
          {
            if (CheckCollision(enemyAirplane, this))
            {
              enemyAirplane.TakeDamage(Damage);
              Game.RemoveGameObject(this);
            }
          }
          else if (elGameObject is Bonus bonus)
          {
            if (CheckCollision(bonus, this))
            {
              bonus.ToggleBonus();
              Game.RemoveGameObject(this);
            }
          }
        }
      }
      if (Y + Height <= GameModel.SCREEN_TEXT_HEIGHT 
        || Y >= GameModel.SCREEN_HEIGHT 
        || X > GameModel.SCREEN_WIDTH 
        || X + Width < 0)
      {
        Game.RemoveGameObject(this);
      }
    }
  }
}
