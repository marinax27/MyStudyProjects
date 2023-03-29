using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.Game;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление бонуса
  /// </summary>
  public class BonusView : GameObjectView
  {
    /// <summary>
    /// Изображение бонусного оружия
    /// </summary>
    private static ImageBrush _missileImage = 
      new ImageBrush(new BitmapImage(new Uri("missile_bonus.png", UriKind.Relative)));
    /// <summary>
    /// Изображение бонусной энергии
    /// </summary>
    private static ImageBrush _energyImage = 
      new ImageBrush(new BitmapImage(new Uri("energy_bonus.png", UriKind.Relative)));

    /// <summary>
    /// Бонус
    /// </summary>
    public Bonus Bonus 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор WPF представления бонуса
    /// </summary>
    /// <param name="parBonus">Бонус</param>
    public BonusView(Bonus parBonus) : base()
    {
      Bonus = parBonus;
    }

    /// <summary>
    /// Рисует бонус
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public override void Draw(Canvas parCanvas)
    {
      Rectangle shape = new Rectangle();
      shape.Width = Bonus.Width;
      shape.Height = Bonus.Height;
      if (Bonus.BonusType.Equals(BonusType.Shotgun))
      {
        shape.Fill = _missileImage;
      }
      else
      {
        shape.Fill = _energyImage;
      }
      Canvas.SetLeft(shape, Bonus.X);
      Canvas.SetTop(shape, Bonus.Y);
      parCanvas.Children.Add(shape);
    }
  }
}
