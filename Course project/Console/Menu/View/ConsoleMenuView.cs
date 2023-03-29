using Core.Menu;
using Core.Menu.Model;
using Core.Menu.View;

namespace Console.Menu.View
{
  /// <summary>
  /// Консольное представление меню
  /// </summary>
  public class ConsoleMenuView : MenuView
  {
    /// <summary>
    /// Ширина кнопки
    /// </summary>
    private const int BUTTON_WIDTH = 20;
    /// <summary>
    /// Высота кнопки
    /// </summary>
    private const int BUTTON_HEIGHT = 3;
    /// <summary>
    /// Расстояние по Y между кнопками
    /// </summary>
    private const int Y_BIAS = 5;
    /// <summary>
    /// Y, от которого начинается отрисовка кнопок
    /// </summary>
    private const int Y_START = 10;

    /// <summary>
    /// Конструктор консольного представления меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    public ConsoleMenuView(MenuModel parModel) : base(parModel)
    {
    }

    /// <summary>
    /// Настраивает окно
    /// </summary>
    public void SetupWindow()
    {
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Clear();
    }

    /// <summary>
    /// Рисует консольное представление меню
    /// </summary>
    public override void Draw()
    {
      string textInstruction = "для перемещения - Up/Down, выбора - Enter";
      System.Console.SetCursorPosition(2, 1);
      System.Console.BackgroundColor = ConsoleColor.Black;
      System.Console.Write(textInstruction);
      string textHeader = "T H E  B A T T L E  O F  M I D W A Y";
      System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - textHeader.Length / 2, 5);
      System.Console.Write(textHeader);

      MainMenu menu = Model.Menu;
      for (int i = 0; i < menu.Items.Count; i++)
      {
        string text = MenuItemTextFormer.GetTitle(menu.GetMenuItemByIndex(i));

        ConsoleColor color;
        if (Model.FocusedIndex == i)
        {
          color = ConsoleColor.Magenta;
        }
        else
        {
          color = ConsoleColor.DarkMagenta;
        }

        ConsoleShapeDrawer.DrawRectangle(System.Console.WindowWidth / 2 - BUTTON_WIDTH / 2, Y_START + Y_BIAS * i, BUTTON_WIDTH, BUTTON_HEIGHT, color);
        System.Console.BackgroundColor = color;
        System.Console.SetCursorPosition(System.Console.WindowWidth / 2 - text.Length / 2, Y_START + Y_BIAS * i + BUTTON_HEIGHT / 2);
        System.Console.Write(text);
      }
    }

    /// <summary>
    /// Запускает консольное представление меню
    /// </summary>
    public override void Start()
    {
      System.Console.Clear();
      SetupWindow();
      Draw();
      base.Start();
    }

    /// <summary>
    /// Останавливает консольное представление меню
    /// </summary>
    public override void Stop()
    {
      base.Stop();
    }
  }
}
