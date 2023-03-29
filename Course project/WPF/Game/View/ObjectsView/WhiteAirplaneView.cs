using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.Game;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление белого вражеского самолета
  /// </summary>
  public class WhiteAirplaneView : GameObjectView
  {
    /// <summary>
    /// Изображение белого вражеского самолета
    /// </summary>
    private static ImageBrush _airplaneImage = 
      new ImageBrush(new BitmapImage(new Uri("white_airplane.png", UriKind.Relative)));

    /// <summary>
    /// Белый вражеский самолет
    /// </summary>
    public WhiteAirplane Airplane 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор WPF представления белого вражеского самолета
    /// </summary>
    /// <param name="parAirplane">Самолет</param>
    public WhiteAirplaneView(WhiteAirplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует белый вражеский самолет
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public override void Draw(Canvas parCanvas)
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
