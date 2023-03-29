using System;
using System.Windows;
using System.Windows.Input;
using Core.Game;
using Core.Controller;

namespace WPF.WPFController
{
  /// <summary>
  /// WPF контроллер игры
  /// </summary>
  public class WPFGameController : GameController
  {
    /// <summary>
    /// Окно
    /// </summary>
    private readonly Window _window;

    /// <summary>
    /// Конструктор WPF контроллера игры
    /// </summary>
    /// <param name="parModel">Модель игры</param>
    public WPFGameController(GameModel parModel) : base(parModel, new WPFGameView(parModel))
    {
      _window = WindowKeeper.Instance.GetWindow();
    }

    /// <summary>
    /// Обрабатывает закрытие окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClose(object? sender, EventArgs e)
    {
      Stop();
    }

    /// <summary>
    /// Обрабатывает нажатие клавиши клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void KeyDownHandler(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case (Key.Up):
          Model.Airplane.MoveUp();
          break;
        case Key.Down:
          Model.Airplane.MoveDown();
          break;
        case Key.Right:
          Model.Airplane.MoveRight();
          break;
        case Key.Left:
          Model.Airplane.MoveLeft();
          break;
        case Key.Escape:
          BackToMenu();
          break;
      }
    }

    /// <summary>
    /// Обрабатывает отпускание клавиши клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Window_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Z:
          Model.Airplane.Shoot();
          break;
        case Key.X:
          Model.Airplane.UseLightning();
          break;
      }
    }

    /// <summary>
    /// Запускает WPF контроллер игры 
    /// </summary>
    public override void Start()
    {
      _window.KeyDown += KeyDownHandler;
      _window.KeyUp += Window_KeyUp;
      _window.Closed += OnClose;
      base.Start();
    }

    /// <summary>
    /// Останавливает WPF контроллер игры
    /// </summary>
    public override void Stop()
    {
      _window.KeyDown -= KeyDownHandler;
      _window.KeyUp -= Window_KeyUp;
      _window.Closed -= OnClose;
      base.Stop();
    }
  }
}
