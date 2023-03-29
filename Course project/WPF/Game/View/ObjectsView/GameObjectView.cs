using System.Windows.Controls;

namespace WPF.Game.View.ObjectsView
{
  /// <summary>
  /// WPF представление игрового объекта
  /// </summary>
  public abstract class GameObjectView
  {
    /// <summary>
    /// Рисует WPF представление игрового объекта
    /// </summary>
    /// <param name="parCanvas">Элемент Canvas</param>
    public abstract void Draw(Canvas parCanvas);
  }
}
