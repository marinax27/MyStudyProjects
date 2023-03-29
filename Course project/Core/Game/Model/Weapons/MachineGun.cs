using Core.Game.Missile;

namespace Core.Game.Weapons
{
  /// <summary>
  /// Пулемет
  /// </summary>
  public class MachineGun : Weapon
  {
    /// <summary>
    /// Скорость по Х
    /// </summary>
    private const double SPEED_X = 0;
    /// <summary>
    /// Скорость по Y
    /// </summary>
    private const double SPEED_Y = -5;
    /// <summary>
    /// Ширина
    /// </summary>
    private const int WIDTH = 5;
    /// <summary>
    /// Высота
    /// </summary>
    private const int HEIGHT = 20;
    /// <summary>
    /// Смещение по Y
    /// </summary>
    private const int OFFSET_Y = 5;

    /// <summary>
    /// Конструктор пулемета
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parDamage">Урон</param>
    public MachineGun(GameModel parGame, int parDamage) : base (parGame, parDamage)
    {
    }

    /// <summary>
    /// Пулемет стреляет
    /// </summary>
    /// <param name="parAirplane">Самолет</param>
    public override void Shoot(Airplane parAirplane)
    {
      double x1 = parAirplane.X;
      double x2 = parAirplane.X + parAirplane.Width - WIDTH;
      double y = parAirplane.Y - HEIGHT - OFFSET_Y;

      WeaponMissile missileFirst = new WeaponMissile(
        Game, x1, y, WIDTH, HEIGHT, SPEED_X, SPEED_Y, MissileType.MachineGunMissile, Damage);
      WeaponMissile missileSecond = new WeaponMissile(
        Game, x2, y, WIDTH, HEIGHT, SPEED_X, SPEED_Y, MissileType.MachineGunMissile, Damage);

      Game.AddGameObject(missileFirst);
      Game.AddGameObject(missileSecond);
    }
  }
}
