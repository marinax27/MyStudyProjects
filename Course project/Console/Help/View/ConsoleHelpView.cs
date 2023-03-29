using Core.Help.Model;
using Core.Help.View;

namespace Console.Help.View
{
  /// <summary>
  /// Консольное представление справки
  /// </summary>
  public class ConsoleHelpView : HelpView
  {
    /// <summary>
    /// Координата X для начала отрисовки
    /// </summary>
    private const int X_START = 6;
    /// <summary>
    /// Координата Y для начала отрисовки
    /// </summary>
    private const int Y_START = 5;

    /// <summary>
    /// Конструктор консольного представления справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    public ConsoleHelpView(HelpModel parModel) : base(parModel)
    {
    }

    /// <summary>
    /// Рисует консольное представление справки
    /// </summary>
    public override void Draw()
    {
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Clear();

      string textInstruction = "для выхода - escape";
      System.Console.SetCursorPosition(2, 1);
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Write(textInstruction);

      string textHeader = "С П Р А В К А";
      System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - textHeader.Length / 2, 3);
      System.Console.Write(textHeader);

      string helpText = Model.GetHelpText();
      System.Console.SetCursorPosition(X_START, Y_START);
      int y = 0;
      int x = 0;
      for (int i = 0; i < helpText.Length; i++)
      {
        if (helpText[i] == '\n')
        {
          x = 0;
          y += 2;
          System.Console.SetCursorPosition(X_START, Y_START + y);
          continue;
        }

        if (x >= System.Console.WindowWidth - X_START * 2)
        {
          x = 0;
          y++;
          System.Console.SetCursorPosition(X_START, Y_START + y);
        }

        System.Console.Write(helpText[i]);
        x++;
      }
    }

    /// <summary>
    /// Запускает консольное представление справки
    /// </summary>
    public override void Start()
    {
      Draw();
      base.Start();
    }

    /// <summary>
    /// Останавливает консольное представление справки
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      System.Console.Clear();
    }
  }
}
