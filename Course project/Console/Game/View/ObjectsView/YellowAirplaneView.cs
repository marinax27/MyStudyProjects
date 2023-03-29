using Core.Game;

namespace Console.Game.View.ObjectsView
{
  /// <summary>
  /// Консольное представление желтого вражеского самолета
  /// </summary>
  public class YellowAirplaneView : GameObjectView
  {
    /// <summary>
    /// Желтый вражеский самолет
    /// </summary>
    public YellowAirplane Airplane 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор консольного представления желтого вражеского самолета
    /// </summary>
    /// <param name="parAirplane">Желтый самолет</param>
    public YellowAirplaneView(YellowAirplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует консольное представление желтого вражеского самолета
    /// </summary>
    public override void Draw()
    {
      int x = (int)(Airplane.X / ConsoleGameView.COMPRESSION_X);
      int y = (int)(Airplane.Y / ConsoleGameView.COMPRESSION_Y);
      int width = (Airplane.Width / ConsoleGameView.COMPRESSION_X);
      int height = (Airplane.Height / ConsoleGameView.COMPRESSION_Y);
      FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.Green);
    }
  }
}
