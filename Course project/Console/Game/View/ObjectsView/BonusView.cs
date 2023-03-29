using Core.Game;

namespace Console.Game.View.ObjectsView
{
  /// <summary>
  /// Консольное представление бонуса
  /// </summary>
  public class BonusView : GameObjectView
  {
    /// <summary>
    /// Бонус
    /// </summary>
    public Bonus Bonus
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор консольного представления бонуса
    /// </summary>
    /// <param name="parBonus">Бонус</param>
    public BonusView(Bonus parBonus) : base()
    {
      Bonus = parBonus;
    }

    /// <summary>
    /// Рисует консольное представление бонуса
    /// </summary>
    public override void Draw()
    {
      int x = (int)(Bonus.X / ConsoleGameView.COMPRESSION_X);
      int y = (int)(Bonus.Y / ConsoleGameView.COMPRESSION_Y);
      int width = (Bonus.Width / ConsoleGameView.COMPRESSION_X);
      int height = (Bonus.Height / ConsoleGameView.COMPRESSION_Y);

      if (Bonus.BonusType.Equals(BonusType.Energy))
      {
        FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.Yellow);
      }
      else
      {
        FastConsoleOutput.SetRectangle(x, y, width, height, (int)ConsoleColor.Blue);
      }
    }
  }
}
