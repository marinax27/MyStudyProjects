using Core.GameResult.Model;
using Core.GameResult.View;

namespace Console.GameResult.View
{
  /// <summary>
  /// Консольное представление результата игры
  /// </summary>
  public class ConsoleGameResultView : GameResultView
  {
    /// <summary>
    /// Координата X для начала отрисовки
    /// </summary>
    private const int X_START = 5;
    /// <summary>
    /// Координата Y для начала отрисовки
    /// </summary>
    private const int Y_START = 10;

    /// <summary>
    /// Конструктор консольного представления результата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    public ConsoleGameResultView(GameResultModel parModel) : base(parModel)
    {
    }

    /// <summary>
    /// Настраивает окно 
    /// </summary>
    public void SetupWindow()
    {
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Clear();
      InitialDraw();
      Draw();
    }

    /// <summary>
    /// Инициализирует начальную отрисовку при запуске
    /// </summary>
    private void InitialDraw()
    {
      string helpText = Model.GetEndText();
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

      string textHeader = "К О Н Е Ц   И Г Р Ы";
      System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - textHeader.Length / 2, 4);
      System.Console.Write(textHeader);

      string textInstruction = "для выхода - escape";
      System.Console.BackgroundColor = ConsoleColor.Black;
      if (Model.IsRecord)
      {
        string name = Model.Name;
        System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - name.Length / 2, System.Console.WindowHeight / 2);
        System.Console.Write(name);
        textInstruction += ", для подтверждения имени - enter";
      }
      System.Console.SetCursorPosition(2, 1);
      System.Console.Write(textInstruction);
    }

    /// <summary>
    /// Рисует введенное имя победившего игрока
    /// </summary>
    public override void Draw()
    {
      if (Model.IsRecord)
      {
        System.Console.SetCursorPosition(0, System.Console.WindowHeight / 2);
        for (int i = 0; i < System.Console.WindowWidth; i++)
        {
          System.Console.Write(' ');
        }
        string name = Model.Name;

        System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - name.Length / 2, System.Console.WindowHeight / 2);
        System.Console.Write(name);
      }
    }

    /// <summary>
    /// Запускает консольное представление результата игры
    /// </summary>
    public override void Start()
    {
      SetupWindow();
      base.Start();
    }

    /// <summary>
    /// Останавливает консольное представление результата игры
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      System.Console.Clear();
    }
  }
}
