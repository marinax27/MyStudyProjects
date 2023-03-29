namespace Console
{
  /// <summary>
  /// Класс, рисующий фигуры в консоли
  /// </summary>
  public class ConsoleShapeDrawer
  {
    /// <summary>
    /// Рисует прямоугольник
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина прямоугольника</param>
    /// <param name="parHeight">Высота прямоугольника</param>
    /// <param name="color">Цвет</param>
    public static void DrawRectangle(int parX, int parY, int parWidth, int parHeight, ConsoleColor color)
    {
      System.Console.BackgroundColor = color;
      for (int i = 0; i < parHeight; i++)
      {
        System.Console.SetCursorPosition(parX, parY + i);
        for (int j = 0; j < parWidth; j++)
        {
          System.Console.Write(' ');
        }
        System.Console.WriteLine();
      }
    }
  }
}
