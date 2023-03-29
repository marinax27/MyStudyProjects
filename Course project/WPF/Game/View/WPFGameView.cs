using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core.View;
using Core.Game;
using Core.Game.Missile;
using WPF.Game.View.ObjectsView;
using System;
using System.Collections.Generic;

namespace WPF
{
  /// <summary>
  /// WPF представление игры
  /// </summary>
  public class WPFGameView : GameView
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
    /// Нужно ли отрисовывать
    /// </summary>
    private bool _isNeedDraw;

    /// <summary>
    /// Конструктор WPF представления игры
    /// </summary>
    /// <param name="parModel">Модель игры</param>
    public WPFGameView(GameModel parModel) : base(parModel)
    {
      _window = WindowKeeper.Instance.GetWindow();
    }

    /// <summary>
    /// Рисует молнию
    /// </summary>
    private void LightningDraw()
    {

      new Thread(() =>
      {
        int millisecondsTimeout = 100;
        int flickCount = 3;
        for (int i = 0; i < flickCount; i++)
        {
          _window.Dispatcher.Invoke(() =>
          {
            _canvas.Background = new SolidColorBrush(Colors.White);
          });
          
          Thread.Sleep(millisecondsTimeout);
          _window.Dispatcher.Invoke(() =>
          {
            _canvas.Background = new SolidColorBrush(Colors.Cyan);
          });
          Thread.Sleep(millisecondsTimeout);
        }
      }).Start();  
    }

    /// <summary>
    /// Инициализирует WPF представление игры
    /// </summary>
    private void ViewInit()
    {
      SetWindow();
    }

    /// <summary>
    /// Настраивает окно
    /// </summary>
    private void SetWindow()
    {
      _canvas = new Canvas();
      _canvas.Width = WPFApplication.WINDOW_WIDTH;
      _canvas.Height = WPFApplication.WINDOW_HEIGHT;
      _canvas.Background = new SolidColorBrush(Colors.Cyan);
      _window.Content = _canvas;
    }

    /// <summary>
    /// Начинает отрисовку
    /// </summary>
    private void StartDrawing()
    {
      Model.LightningUsed += LightningDraw;
      _isNeedDraw = true;
      new Thread(Draw).Start();
    }

    /// <summary>
    /// Рисует карту
    /// </summary>
    public override void Draw()
    {
      while (_isNeedDraw)
      {
        Thread.Sleep(8);
        _window.Dispatcher.Invoke(() =>
        {
          _canvas.Children.Clear();
          DrawTextInstruction();

          List<GameObject> gameObjectsClone = new List<GameObject>(Model.GameObjects);

          foreach (GameObject elObject in gameObjectsClone)
          {
            GameObjectView view = GetObjectView(elObject);
            view.Draw(_canvas);
          }

        });
      }
    }

    /// <summary>
    /// Рисует инструкцию по управлению игрой
    /// </summary>
    private void DrawTextInstruction()
    {
      string textInstruction = "для перемещения - Up/Down/Right/Left, выстрела - Z, молнии - X, выхода - escape";
      TextBlock headerTextInstruction = new TextBlock();
      headerTextInstruction.Text = textInstruction;
      headerTextInstruction.FontSize = 15;
      headerTextInstruction.TextWrapping = TextWrapping.Wrap;
      headerTextInstruction.MaxWidth = 400;
      headerTextInstruction.FontFamily = new FontFamily("Comic Sans MS");
      headerTextInstruction.Foreground = new SolidColorBrush(Colors.BlueViolet);
      Canvas.SetRight(headerTextInstruction, 40);
      Canvas.SetTop(headerTextInstruction, 10);
      _canvas.Children.Add(headerTextInstruction);
    }

    /// <summary>
    /// Получает WPF представление объекта
    /// </summary>
    /// <param name="parObject">Объект</param>
    /// <returns>Представление объекта</returns>
    /// <exception cref="Exception">Исключение</exception>
    private GameObjectView GetObjectView(GameObject parObject)
    {
      switch (parObject)
      {
        case Airplane _:
          return new AirplaneView((Airplane)parObject);
        case YellowAirplane _:
          return new YellowAirplaneView((YellowAirplane)parObject);
        case WhiteAirplane _:
          return new WhiteAirplaneView((WhiteAirplane)parObject);
        case WeaponMissile _:
          return new MissileView((WeaponMissile)parObject);
        case Bonus _:
          return new BonusView((Bonus)parObject);
        default:
          throw new Exception("Неизвестный объект для отрисовки!");
      }
    }

    /// <summary>
    /// Запускает WPF представление игры
    /// </summary>
    public override void Start()
    {
      ViewInit();
      StartDrawing();
      base.Start();
    }

    /// <summary>
    /// Останавливает WPF представление игры
    /// </summary>
    public override void Stop()
    {
      _window.Dispatcher.Invoke(() =>
      {
        _window.Content = null;
      });
      Model.LightningUsed -= LightningDraw;
      _isNeedDraw = false;
      base.Stop();
    }
  }
}
