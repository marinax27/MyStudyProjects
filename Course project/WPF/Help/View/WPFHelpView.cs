using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core.Help.Model;
using Core.Help.View;

namespace WPF.Help.View
{
  /// <summary>
  /// WPF представление справки
  /// </summary>
  public class WPFHelpView : HelpView
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;
    /// <summary>
    /// Элемент Canvas
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// Конструктор WPF представления справки
    /// </summary>
    /// <param name="parModel">Модель справки</param>
    public WPFHelpView(HelpModel parModel) : base(parModel)
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
      Draw();
    }

    /// <summary>
    /// Рисует WPF представление справки
    /// </summary>
    public override void Draw()
    {
      string textInstruction = "для выхода - escape";
      string textHeader = "Справка";

      TextBlock headerTextInstruction = new TextBlock();
      headerTextInstruction.Text = textInstruction;
      headerTextInstruction.FontSize = 15;
      headerTextInstruction.FontFamily = new FontFamily("Comic Sans MS");
      headerTextInstruction.Foreground = new SolidColorBrush(Colors.Linen);
      Canvas.SetRight(headerTextInstruction, 30);
      Canvas.SetTop(headerTextInstruction, 10);
      _canvas.Children.Add(headerTextInstruction);

      TextBlock headerText = new TextBlock();
      headerText.Text = textHeader;
      headerText.FontSize = 40;
      headerText.Foreground = new SolidColorBrush(Colors.Navy);
      headerText.FontFamily = new FontFamily("Comic Sans MS");
      Canvas.SetLeft(headerText, 160);
      Canvas.SetTop(headerText, 50);
      _canvas.Children.Add(headerText);

      TextBlock helpText = new TextBlock();
      helpText.Text = Model.GetHelpText();
      helpText.TextWrapping = TextWrapping.Wrap;
      helpText.FontFamily = new FontFamily("Comic Sans MS");
      helpText.FontSize = 15;
      helpText.MaxWidth = 400;
      helpText.MaxHeight = 500;
      helpText.TextAlignment = TextAlignment.Justify;
      Canvas.SetLeft(helpText, 50);
      Canvas.SetTop(helpText, 120);
      _canvas.Children.Add(helpText);
    }

    /// <summary>
    /// Запускает WPF представление справки
    /// </summary>
    public override void Start()
    {
      base.Start();
      SetupCanvas();
      _window.Content = _canvas;
    }

    /// <summary>
    /// Останавливает WPF представление справки
    /// </summary>
    public override void Stop()
    {
      _window.Content = null;
      base.Stop();
    }
  }
}
