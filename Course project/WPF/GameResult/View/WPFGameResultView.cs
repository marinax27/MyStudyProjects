using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core.GameResult.Model;
using Core.GameResult.View;

namespace WPF.GameResult.Model
{
  /// <summary>
  /// WPF представление резульата игры
  /// </summary>
  public class WPFGameResultView : GameResultView
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
    /// Конструктор WPF представления резульата игры
    /// </summary>
    /// <param name="parModel">Модель результата игры</param>
    public WPFGameResultView(GameResultModel parModel) : base(parModel)
    {
      _window = WindowKeeper.Instance.GetWindow();
    }

    /// <summary>
    /// Настраивает элемент Canvas
    /// </summary>
    private void SetupCanvas()
    {
      _window.Dispatcher.Invoke(() =>
      {
        _canvas = new Canvas();
        _canvas.Width = _window.Width;
        _canvas.Height = _window.Height;
        _canvas.Background = new SolidColorBrush(Colors.LightPink);
      });
    }

    /// <summary>
    /// Рисует WPF представление результата игры
    /// </summary>
    public override void Draw()
    {
      _window.Dispatcher.Invoke(() =>
      {
        _canvas.Children.Clear();

        string textInstruction = "для выхода - escape";
        TextBlock headerTextInstruction = new TextBlock();
        headerTextInstruction.FontSize = 15;
        headerTextInstruction.FontFamily = new FontFamily("Comic Sans MS");
        headerTextInstruction.Foreground = new SolidColorBrush(Colors.Linen);
        Canvas.SetLeft(headerTextInstruction, 70);
        Canvas.SetTop(headerTextInstruction, 10);

        string textHeader = "Конец игры";
        TextBlock headerText = new TextBlock();
        headerText.Text = textHeader;
        headerText.FontSize = 40;
        headerText.Foreground = new SolidColorBrush(Colors.Navy);
        headerText.FontFamily = new FontFamily("Comic Sans MS");
        Canvas.SetLeft(headerText, 140);
        Canvas.SetTop(headerText, 50);
        _canvas.Children.Add(headerText);

        TextBlock textEndGame = new TextBlock();
        textEndGame.Text = Model.GetEndText();
        textEndGame.FontSize = 15;
        textEndGame.MaxWidth = 420;
        textEndGame.MaxHeight = 200;
        textEndGame.TextAlignment = TextAlignment.Center;
        textEndGame.TextWrapping = TextWrapping.Wrap;
        Canvas.SetLeft(textEndGame, 90);
        Canvas.SetTop(textEndGame, 150);
        _canvas.Children.Add(textEndGame);

        if (Model.IsRecord)
        {
          TextBlock name = new TextBlock();
          name.Text = Model.Name;
          name.FontSize = 30;
          name.Foreground = new SolidColorBrush(Colors.DarkBlue);
          Canvas.SetLeft(name, 200);
          Canvas.SetTop(name, 300);
          _canvas.Children.Add(name);

          textInstruction += ", для подтверждения имени - enter";
        }
        headerTextInstruction.Text = textInstruction;
        _canvas.Children.Add(headerTextInstruction);
      });
    }

    /// <summary>
    /// Запускает WPF представление результата игры
    /// </summary>
    public override void Start()
    {
      base.Start();
      SetupCanvas();
      Draw();
      _window.Dispatcher.Invoke(() =>
      {
        _window.Content = _canvas;
      });
    }

    /// <summary>
    /// Останавливает WPF представление результата игры
    /// </summary>
    public override void Stop()
    {
      _window.Content = null;
      base.Stop();
    }
  }
}
