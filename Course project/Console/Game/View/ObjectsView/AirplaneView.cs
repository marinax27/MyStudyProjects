using Core.Game;
using Core.Game.Weapons;

namespace Console.Game.View.ObjectsView
{
  /// <summary>
  /// Консольное представление самолета игрока
  /// </summary>
  public class AirplaneView : GameObjectView
  {
    /// <summary>
    /// Самолет игрока
    /// </summary>
    public Airplane Airplane 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор консольного представления самолета игрока
    /// </summary>
    /// <param name="parAirplane">Самолет игрока</param>
    public AirplaneView(Airplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует консольное представление самолета игрока
    /// </summary>
    public override void Draw()
    {
      int x = (int)(Airplane.X / ConsoleGameView.COMPRESSION_X);
      int y = (int)(Airplane.Y / ConsoleGameView.COMPRESSION_Y);
      int width = (Airplane.Width / ConsoleGameView.COMPRESSION_X);
      int height = (Airplane.Height / ConsoleGameView.COMPRESSION_Y);
      FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.Red);

      int xText = 3;
      int yText = 8;
      FastConsoleOutput.SetString(xText, yText, (int)ConsoleColor.Blue, Airplane.Score.ToString());
      FastConsoleOutput.SetString(xText-1, yText+1, (int)ConsoleColor.Blue, "score");

      xText = ConsoleApplication.WINDOW_WIDTH - 5;
      yText = 8;
      FastConsoleOutput.SetString(xText, yText, (int)ConsoleColor.Red, Airplane.Health.ToString());
      FastConsoleOutput.SetString(xText-2, yText+1, (int)ConsoleColor.Red, "health");

      xText = ConsoleApplication.WINDOW_WIDTH - 5;
      yText = ConsoleApplication.WINDOW_HEIGHT - 2;
      FastConsoleOutput.SetString(xText, yText, (int)ConsoleColor.Yellow, Airplane.Energy.ToString());
      FastConsoleOutput.SetString(xText-2, yText-1, (int)ConsoleColor.Yellow, "energy");

      if (Airplane.Weapon is Shotgun shotgun)
      {
        xText = 3;
        yText = ConsoleApplication.WINDOW_HEIGHT - 2;
        FastConsoleOutput.SetString(xText, yText, (int)ConsoleColor.White, shotgun.WeaponTime.ToString());
        FastConsoleOutput.SetString(xText-1, yText-1, (int)ConsoleColor.White, "timer");
      }
    }
  }
}
