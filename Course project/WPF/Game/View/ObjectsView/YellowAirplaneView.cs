using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.Game;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление желтого вражеского самолета
  /// </summary>
  public class YellowAirplaneView : GameObjectView
  {
    /// <summary>
    /// Изображение желтого вражеского самолета
    /// </summary>
    private static ImageBrush _aircraftImage = 
      new ImageBrush(new BitmapImage(new Uri("yellow_airplane.png", UriKind.Relative)));

    /// <summary>
    /// Желтый вражеский самолет
    /// </summary>
    public YellowAirplane Airplane 
    { 
      get; 
      set; 
    }

    /// <summary>
    /// Конструктор WPF представления желтого вражеского самолета
    /// </summary>
    /// <param name="parAirplane">Самолет</param>
    public YellowAirplaneView(YellowAirplane parAirplane) : base()
    {
      Airplane = parAirplane;
    }

    /// <summary>
    /// Рисует желтый вражеский самолет
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public override void Draw(Canvas parCanvas)
    {
      Rectangle shape = new Rectangle();
      shape.Width = Airplane.Width;
      shape.Height = Airplane.Height;
      shape.Fill = _aircraftImage;
      Canvas.SetLeft(shape, Airplane.X);
      Canvas.SetTop(shape, Airplane.Y);
      parCanvas.Children.Add(shape);
    }
  }
}
