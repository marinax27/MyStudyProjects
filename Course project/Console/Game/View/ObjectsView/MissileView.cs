using Core.Game.Missile;

namespace Console.Game.View.ObjectsView
{
  /// <summary>
  /// Консольное представление снаряда
  /// </summary>
  public class MissileView : GameObjectView
  {
    /// <summary>
    /// Снаряд
    /// </summary>
    public WeaponMissile Missile 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор консольного представления снаряда
    /// </summary>
    /// <param name="parMissile">Снаряд</param>
    public MissileView(WeaponMissile parMissile) : base()
    {
      Missile = parMissile;
    }

    /// <summary>
    /// Рисует консольное представление снаряда
    /// </summary>
    public override void Draw()
    {
      int x = (int)(Missile.X / ConsoleGameView.COMPRESSION_X);
      int y = (int)(Missile.Y / ConsoleGameView.COMPRESSION_Y);
      int width = (Missile.Width / ConsoleGameView.COMPRESSION_X);
      int height = (Missile.Height / ConsoleGameView.COMPRESSION_Y);
      FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.Red);
    }
  }
}
