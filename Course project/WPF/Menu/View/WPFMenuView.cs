using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Core.Menu.Model;
using Core.Menu.View;

namespace WPF.Menu.View
{
  /// <summary>
  /// WPF представление меню
  /// </summary>
  public class WPFMenuView : MenuView
  {
    /// <summary>
    /// Ширина кнопки
    /// </summary>
    private const int BUTTON_WIDTH = 180;
    /// <summary>
    /// Высота кнопки
    /// </summary>
    private const int BUTTON_HEIGHT = 45;
    /// <summary>
    /// Расстояние по Y между кнопками меню
    /// </summary>
    private const int Y_BIAS = 100;
    /// <summary>
    /// Начальный Y кнопок меню
    /// </summary>
    private const int Y_START = 200;
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;
    /// <summary>
    /// Элемент Canvas
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// Конструктор WPF представления меню
    /// </summary>
    /// <param name="parModel">Модель меню</param>
    public WPFMenuView(MenuModel parModel) : base(parModel)
    {
      _window = WindowKeeper.Instance.GetWindow();
    }

    /// <summary>
    /// Настраивает элемент Canvas
    /// </summary>
    private void SetupCanvas()
    {
      _canvas = new Canvas();
      _canvas.Width = _window.Width;
      _canvas.Height = _window.Height;
      _canvas.Background = new SolidColorBrush(Colors.LightPink);  
    }

    /// <summary>
    /// Рисует WPF представление меню
    /// </summary>
    public override void Draw()
    {
      _canvas.Children.Clear();
      Core.Menu.MainMenu menu = Model.Menu;

      string textInstruction = "для перемещения - Up/Down, выбора - Enter";
      TextBlock headerTextInstruction = new TextBlock();
      headerTextInstruction.Text = textInstruction;
      headerTextInstruction.FontSize = 15;
      headerTextInstruction.FontFamily = new FontFamily("Comic Sans MS");
      headerTextInstruction.Foreground = new SolidColorBrush(Colors.Linen);
      Canvas.SetRight(headerTextInstruction, 30);
      Canvas.SetTop(headerTextInstruction, 10);
      _canvas.Children.Add(headerTextInstruction);

      string textHeader = "The Battle of Midway";
      TextBlock headerText = new TextBlock();
      headerText.Text = textHeader;
      headerText.FontSize = 35;
      headerText.Foreground = new SolidColorBrush(Colors.Navy);
      headerText.FontWeight = FontWeights.Bold;
      headerText.FontFamily = new FontFamily("Comic Sans MS");
      Canvas.SetLeft(headerText, 70);
      Canvas.SetTop(headerText, 80);
      _canvas.Children.Add(headerText);

      for (int i = 0; i < menu.Items.Count; i++)
      {
        string text = MenuItemTextFormer.GetTitle(menu.GetMenuItemByIndex(i));

        Rectangle button = new Rectangle();
        button.RadiusX = 20;
        button.RadiusY = 20;
        button.Width = BUTTON_WIDTH;
        button.Height = BUTTON_HEIGHT;
        
        if (Model.FocusedIndex == i)
        {
          button.Fill = new SolidColorBrush(Colors.BlueViolet);
        }
        else
        {
          button.Fill = new SolidColorBrush(Colors.DarkMagenta);
        }
        Canvas.SetLeft(button, WPFApplication.WINDOW_WIDTH / 2 - BUTTON_WIDTH / 2);
        Canvas.SetTop(button, Y_START + Y_BIAS * i);
        _canvas.Children.Add(button);

        TextBlock buttonText = new TextBlock();
        buttonText.Text = text;
        buttonText.FontSize = 28;
        buttonText.FontFamily = new FontFamily("Comic Sans MS");
        buttonText.Foreground = new SolidColorBrush(Colors.Linen);
        Canvas.SetLeft(buttonText, WPFApplication.WINDOW_WIDTH / 2 - (16 * text.Length) / 2 );
        Canvas.SetTop(buttonText, 2 + Y_START + Y_BIAS * i);
        _canvas.Children.Add(buttonText);
      }
    }

    /// <summary>
    /// Запускает WPF представление меню
    /// </summary>
    public override void Start()
    {
      base.Start();
      SetupCanvas();
      Draw();
      _window.Content = _canvas;
    }

    /// <summary>
    /// Останавливает WPF представление меню
    /// </summary>
    public override void Stop()
    {
      _window.Content = null;
      base.Stop();
    }
  }
}
