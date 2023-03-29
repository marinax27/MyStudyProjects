using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core.RecordsTable.Model;
using Core.RecordsTable.View;

namespace WPF.RecordsTable.View
{
  /// <summary>
  /// WPF представление таблицы рекордов
  /// </summary>
  public class WPFRecordsTableView : RecordsTableView
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
    /// Контруктор WPF представления таблицы рекордов
    /// </summary>
    /// <param name="parModel">Модель таблицы рекордов</param>
    public WPFRecordsTableView(RecordsTableModel parModel) : base(parModel)
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
    /// Рисует WPF представление таблицы рекордов
    /// </summary>
    public override void Draw()
    {
      string textInstruction = "для выхода - escape";
      string textHeader = "Рекорды";

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

      List<GameRecord> records = Model.GetRecords();
      for (int i = 0; i < records.Count; i++)
      {
        GameRecord record = records[i];
        TextBlock recordText = new TextBlock();
        recordText.Text = $"{i + 1}  |  {record.PlayerName}  |  {record.Score} (очки)";
        recordText.FontSize = 20;
        recordText.FontFamily = new FontFamily("Comic Sans MS");
        Canvas.SetLeft(recordText, 60);
        Canvas.SetTop(recordText, 130 + 50 * i);
        _canvas.Children.Add(recordText);
      }
    }

    /// <summary>
    /// Запускает WPF представление таблицы рекордов
    /// </summary>
    public override void Start()
    {
      base.Start();
      SetupCanvas();
      Draw();
      _window.Content = _canvas;
    }

    /// <summary>
    /// Останавливает WPF представление таблицы рекордов
    /// </summary>
    public override void Stop()
    {
      _window.Content = null;
      base.Stop();
    }
  }
}
