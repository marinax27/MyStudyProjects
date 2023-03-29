using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Core.Game.Missile;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление снаряда 
  /// </summary>
  public class MissileView : GameObjectView
  {
    /// <summary>
    /// Снаряд
    /// </summary>
    public WeaponMissile Missile 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор WPF представления снаряда
    /// </summary>
    /// <param name="parMissile">Снаряд</param>
    public MissileView(WeaponMissile parMissile) : base()
    {
      Missile = parMissile;
    }

    /// <summary>
    /// Рисует представление снаряда
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public override void Draw(Canvas parCanvas)
    {
      Rectangle shape = new Rectangle();
      shape.Width = Missile.Width;
      shape.Height = Missile.Height;
      shape.Fill = new SolidColorBrush(Colors.Red);
      Canvas.SetLeft(shape, Missile.X);
      Canvas.SetTop(shape, Missile.Y);
      parCanvas.Children.Add(shape);
    }
  }
}
