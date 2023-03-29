namespace Core.Game
{
  /// <summary>
  /// Игровой объект
  /// </summary>
  public abstract class GameObject
  {
    /// <summary>
    /// Модель игры
    /// </summary>
    private GameModel _game;
    /// <summary>
    /// Координа Х
    /// </summary>
    private double _x;
    /// <summary>
    /// Координата Y
    /// </summary>
    private double _y;
    /// <summary>
    /// Ширина
    /// </summary>
    private int _width;
    /// <summary>
    /// Высота
    /// </summary>
    private int _height;
    /// <summary>
    /// Скорость по Х
    /// </summary>
    private double _speedX;
    /// <summary>
    /// Скорость по Y
    /// </summary>
    private double _speedY;

    /// <summary>
    /// Модель игры
    /// </summary>
    public GameModel Game
    {
      get { return _game; }
      set { _game = value; }
    }
    /// <summary>
    /// Координа Х
    /// </summary>
    public double X
    {
      get { return _x; }
      set { _x = value; }
    }
    /// <summary>
    /// Координата Y
    /// </summary>
    public double Y
    {
      get { return _y; }
      set { _y = value; }
    }
    /// <summary>
    /// Ширина
    /// </summary>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }
    /// <summary>
    /// Высота
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }
    /// <summary>
    /// Скорость по Х
    /// </summary>
    public double SpeedX
    {
      get { return _speedX; }
      set { _speedX = value; }
    }
    /// <summary>
    /// Скорость по Y
    /// </summary>
    public double SpeedY
    {
      get { return _speedY; }
      set { _speedY = value; }
    }

    /// <summary>
    /// Конструктор игрового объекта
    /// </summary>
    /// <param name="parGame">Модель игры</param>
    /// <param name="parX">Координата Х</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parSpeedX">Скорость по X</param>
    /// <param name="parSpeedY">Скорость по Y</param>
    public GameObject(
      GameModel parGame, 
      double parX, 
      double parY, 
      int parWidth, 
      int parHeight, 
      double parSpeedX, 
      double parSpeedY)
    {
      Game = parGame;
      X = parX;
      Y = parY;
      Width = parWidth;
      Height = parHeight;
      SpeedX = parSpeedX;
      SpeedY = parSpeedY;
    }

    /// <summary>
    /// Проверяет столкновение двух объектов
    /// </summary>
    /// <param name="parObj1">Первый объект</param>
    /// <param name="parObj2">Второй объект</param>
    /// <returns>Булево значение</returns>
    public static bool CheckCollision(GameObject parObj1, GameObject parObj2)
    {
      if (Math.Min(parObj1.X + parObj1.Width, parObj2.X + parObj2.Width) - Math.Max(parObj1.X, parObj2.X) >= 0
       && Math.Min(parObj1.Y + parObj1.Height, parObj2.Y + parObj2.Height) - Math.Max(parObj1.Y, parObj2.Y) >= 0)
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Обновляет состояние объекта
    /// </summary>
    public abstract void Update();
  }
}
