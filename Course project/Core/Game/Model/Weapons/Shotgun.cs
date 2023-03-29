using System.Timers;
using Core.Game.Missile;

namespace Core.Game.Weapons
{
  /// <summary>
  /// Дробовик
  /// </summary>
  public class Shotgun : Weapon
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
    private const int WIDTH = 8;
    /// <summary>
    /// Высота
    /// </summary>
    private const int HEIGHT = 8;
    /// <summary>
    /// Смещение по Y
    /// </summary>
    private const int OFFSET_Y = 5;
    /// <summary>
    /// Время дробовика
    /// </summary>
    private const int WEAPON_TIME = 20;

    /// <summary>
    /// Таймер дробовика
    /// </summary>
    public System.Timers.Timer WeaponTimer 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Время дробовика
    /// </summary>
    public int WeaponTime 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор дробовика
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parDamage">Урон</param>
    public Shotgun(GameModel parGame, int parDamage) : base (parGame, parDamage)
    {
      WeaponTimer = new System.Timers.Timer();
      WeaponTime = WEAPON_TIME;
      WeaponTimer.Interval = 1000;
      WeaponTimer.Elapsed += CountDown;
      WeaponTimer.AutoReset = true;
      WeaponTimer.Enabled = true;
    }
    /// <summary>
    /// Отсчитывает время использования дробовика
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CountDown(object? sender, ElapsedEventArgs e)
    {
      WeaponTime--;
      if (WeaponTime <= 0)
      {
        Game.Airplane.Weapon = new MachineGun(Game, 10);
        WeaponTimer.Stop();
      }
    }

    /// <summary>
    /// Дробовик стреляет
    /// </summary>
    /// <param name="parAirplane">Самолет</param>
    public override void Shoot(Airplane parAirplane)
    {
      double x1 = parAirplane.X;
      double x2 = parAirplane.X + parAirplane.Width - WIDTH;
      double x3 = parAirplane.X - 10;
      double x4 = parAirplane.X + parAirplane.Width - WIDTH + 10;
      double y = parAirplane.Y - HEIGHT - OFFSET_Y;

      WeaponMissile missileFirst = new WeaponMissile(
        Game, x1, y, WIDTH, HEIGHT, SPEED_X, SPEED_Y, MissileType.ShotgunMissile, Damage);
      WeaponMissile missileSecond = new WeaponMissile(
        Game, x2, y, WIDTH, HEIGHT, SPEED_X, SPEED_Y, MissileType.ShotgunMissile, Damage);
      WeaponMissile missileThird = new WeaponMissile(
        Game, x3, y - 5, WIDTH, HEIGHT, -5, SPEED_Y, MissileType.ShotgunMissile, Damage);
      WeaponMissile missileForth = new WeaponMissile(
        Game, x4, y - 5, WIDTH, HEIGHT, 5, SPEED_Y, MissileType.ShotgunMissile, Damage);

        Game.AddGameObject(missileFirst);
        Game.AddGameObject(missileSecond);
        Game.AddGameObject(missileThird);
        Game.AddGameObject(missileForth);
    }
  }
}
