using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.Game;
using Core.Game.Weapons;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление самолета игрока
  /// </summary>
  public class AirplaneView : GameObjectView
  {
    /// <summary>
    /// Изображение игрока самолета
    /// </summary>
    private static ImageBrush _airplaneImage = 
      new ImageBrush(new BitmapImage(new Uri("Airplane.png", UriKind.Relative)));

    /// <summary>
    /// Самолет игрока
    /// </summary>
    public Airplane Airplane 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор WPF представления самолета игрока
    /// </summary>
    /// <param name="parAirplane">Самолет игрока</param>
    public AirplaneView(Airplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует самолет игрока
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public override void Draw(Canvas parCanvas)
    {
      DrawShape(parCanvas);
      DrawHealth(parCanvas);
      DrawEnergy(parCanvas);
      DrawScore(parCanvas);
      DrawWeaponTimer(parCanvas);
    }

    /// <summary>
    /// Рисует таймер оружия
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    private void DrawWeaponTimer(Canvas parCanvas)
    {
      if (Airplane.Weapon is Shotgun shotgun)
      {
        TextBlock bonusTimeText = new TextBlock();
        bonusTimeText.Text = shotgun.WeaponTime.ToString();
        bonusTimeText.FontSize = 15;
        bonusTimeText.FontFamily = new FontFamily("Comic Sans MS");
        bonusTimeText.Foreground = new SolidColorBrush(Colors.DarkBlue);
        bonusTimeText.FontWeight = FontWeights.Bold;
        Canvas.SetLeft(bonusTimeText, 20);
        Canvas.SetTop(bonusTimeText, GameModel.SCREEN_HEIGHT - 70);
        parCanvas.Children.Add(bonusTimeText);

        TextBlock bonusTimeInscription = new TextBlock();
        bonusTimeInscription.Text = "ТАЙМЕР";
        bonusTimeInscription.FontSize = 10;
        bonusTimeInscription.FontFamily = new FontFamily("Comic Sans MS");
        bonusTimeInscription.Foreground = new SolidColorBrush(Colors.DarkBlue);
        bonusTimeInscription.FontWeight = FontWeights.Bold;
        Canvas.SetLeft(bonusTimeInscription, 20);
        Canvas.SetTop(bonusTimeInscription, GameModel.SCREEN_HEIGHT - 80);
        parCanvas.Children.Add(bonusTimeInscription);
      }
    }

    /// <summary>
    /// Рисует очки
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    private void DrawScore(Canvas parCanvas)
    {
      TextBlock scoreText = new TextBlock();
      scoreText.Text = Airplane.Score.ToString();
      scoreText.FontSize = 15;
      scoreText.FontFamily = new FontFamily("Comic Sans MS");
      scoreText.Foreground = new SolidColorBrush(Colors.DarkGreen);
      scoreText.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(scoreText, 20);
      Canvas.SetTop(scoreText, GameModel.SCREEN_TEXT_HEIGHT + 10);
      parCanvas.Children.Add(scoreText);

      TextBlock scoreInscription = new TextBlock();
      scoreInscription.Text = "ОЧКИ";
      scoreInscription.FontSize = 10;
      scoreInscription.FontFamily = new FontFamily("Comic Sans MS");
      scoreInscription.Foreground = new SolidColorBrush(Colors.DarkGreen);
      scoreInscription.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(scoreInscription, 20);
      Canvas.SetTop(scoreInscription, GameModel.SCREEN_TEXT_HEIGHT + 30);
      parCanvas.Children.Add(scoreInscription);
    }

    /// <summary>
    /// Рисует энергию
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    private void DrawEnergy(Canvas parCanvas)
    {
      TextBlock energyText = new TextBlock();
      energyText.Text = Airplane.Energy.ToString();
      energyText.FontSize = 15;
      energyText.FontFamily = new FontFamily("Comic Sans MS");
      energyText.Foreground = new SolidColorBrush(Colors.LimeGreen);
      energyText.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(energyText, GameModel.SCREEN_WIDTH - 70);
      Canvas.SetTop(energyText, GameModel.SCREEN_HEIGHT - 70);
      parCanvas.Children.Add(energyText);

      TextBlock energyInscription = new TextBlock();
      energyInscription.Text = "ЭНЕРГИЯ";
      energyInscription.FontSize = 10;
      energyInscription.FontFamily = new FontFamily("Comic Sans MS");
      energyInscription.Foreground = new SolidColorBrush(Colors.LimeGreen);
      energyInscription.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(energyInscription, GameModel.SCREEN_WIDTH - 80);
      Canvas.SetTop(energyInscription, GameModel.SCREEN_HEIGHT - 80);
      parCanvas.Children.Add(energyInscription);
    }

    /// <summary>
    /// Рисует здоровье
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    private void DrawHealth(Canvas parCanvas)
    {
      TextBlock healthText = new TextBlock();
      healthText.Text = Airplane.Health.ToString();
      healthText.FontSize = 15;
      healthText.FontFamily = new FontFamily("Comic Sans MS");
      healthText.Foreground = new SolidColorBrush(Colors.DarkRed);
      healthText.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(healthText, GameModel.SCREEN_WIDTH - 70);
      Canvas.SetTop(healthText, GameModel.SCREEN_TEXT_HEIGHT + 10);
      parCanvas.Children.Add(healthText);

      TextBlock healthInscription = new TextBlock();
      healthInscription.Text = "ЗДОРОВЬЕ";
      healthInscription.FontSize = 10;
      healthInscription.FontFamily = new FontFamily("Comic Sans MS");
      healthInscription.Foreground = new SolidColorBrush(Colors.DarkRed);
      healthInscription.FontWeight = FontWeights.Bold;
      Canvas.SetLeft(healthInscription, GameModel.SCREEN_WIDTH - 80);
      Canvas.SetTop(healthInscription, GameModel.SCREEN_TEXT_HEIGHT + 30);
      parCanvas.Children.Add(healthInscription);
    }

    /// <summary>
    /// Рисует форму самолета игрока
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    private void DrawShape(Canvas parCanvas)
    {
      Rectangle shape = new Rectangle();
      shape.Width = Airplane.Width;
      shape.Height = Airplane.Height;
      shape.Fill = _airplaneImage;
      Canvas.SetLeft(shape, Airplane.X);
      Canvas.SetTop(shape, Airplane.Y);
      parCanvas.Children.Add(shape);
    }
  }
}
