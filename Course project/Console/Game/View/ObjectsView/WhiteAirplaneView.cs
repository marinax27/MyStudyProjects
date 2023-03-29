using Core.Game;

namespace Console.Game.View.ObjectsView
{
  /// <summary>
  /// Консольное представление белого вражеского самолета
  /// </summary>
  public class WhiteAirplaneView : GameObjectView
  {
    /// <summary>
    /// Белый вражеский самолет
    /// </summary>
    public WhiteAirplane Airplane 
    { 
      get;
      set; 
    }

    /// <summary>
    /// Конструктор консольного представления белого вражеского самолета
    /// </summary>
    /// <param name="parAirplane">Белый самолет</param>
    public WhiteAirplaneView(WhiteAirplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует белый вражеский самолет
    /// </summary>
    public override void Draw()
    {
      int x = (int)(Airplane.X / ConsoleGameView.COMPRESSION_X);
      int y = (int)(Airplane.Y / ConsoleGameView.COMPRESSION_Y);
      int width = (Airplane.Width / ConsoleGameView.COMPRESSION_X);
      int height = (Airplane.Height / ConsoleGameView.COMPRESSION_Y);
      FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.White);
    }
  }
}
