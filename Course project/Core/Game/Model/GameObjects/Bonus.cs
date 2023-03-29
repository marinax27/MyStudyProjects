using Core.Game.Weapons;

namespace Core.Game
{
  /// <summary>
  /// Бонус
  /// </summary>
  public class Bonus : GameObject
  {
    /// <summary>
    /// Ширина
    /// </summary>
    public const int WIDTH = 30;
    /// <summary>
    /// Высота
    /// </summary>
    public const int HEIGHT = 30;
    /// <summary>
    /// Скорость по Y
    /// </summary>
    public const double SPEED_Y = 1;
    /// <summary>
    /// Количество кадров неуязвимости
    /// </summary>
    private const int INVULNERABILITY_FRAMES_AMOUNT = 30;
    /// <summary>
    /// Количество энергии, добавляемое при поднятии бонуса
    /// </summary>
    public const int BONUS_ENERGY_AMOUNT = 10;

    /// <summary>
    /// Оставшееся количество кадров неуязвимости
    /// </summary>
    private int _invulnerabilityFrames;
    /// <summary>
    /// Тип бонуса
    /// </summary>
    public BonusType BonusType 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор бонуса
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public Bonus(
      GameModel parGame, 
      double parX, 
      double parY) 
      : base(
          parGame, 
          parX, 
          parY, 
          WIDTH, 
          HEIGHT, 
          0, 
          SPEED_Y)
    {
      BonusType = BonusType.Energy;
      _invulnerabilityFrames = 0;
    }

    /// <summary>
    /// Меняет бонус
    /// </summary>
    public void ToggleBonus()
    {
      if (_invulnerabilityFrames <= 0)
      {
        if (BonusType == BonusType.Shotgun)
        {
          BonusType = BonusType.Energy;
        }
        else
        {
          BonusType = BonusType.Shotgun;
        }
        _invulnerabilityFrames = INVULNERABILITY_FRAMES_AMOUNT;
      } 
    }

    /// <summary>
    /// Обновляет оружие или количество энергии в зависимости от взятого бонуса
    /// </summary>
    public override void Update()
    {
      Y += SpeedY;
      
      if (_invulnerabilityFrames > 0)
      {
        _invulnerabilityFrames--;
      }

      if (CheckCollision(Game.Airplane, this))
      {
        if (BonusType.Equals(BonusType.Shotgun))
        {
          Game.Airplane.Weapon = new Shotgun(Game, 10);
        }
        else if (BonusType.Equals(BonusType.Energy))
        {
          if (Game.Airplane.Energy != 100)
          {
            Game.Airplane.Energy += BONUS_ENERGY_AMOUNT;
          } 
        }
        Game.RemoveGameObject(this);
      }
      if  (Y > GameModel.SCREEN_HEIGHT)
      {
        Game.RemoveGameObject(this);
      }
    }
  }
}
