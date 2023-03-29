namespace Core.MVC
{
  /// <summary>
  /// Представление
  /// </summary>
  /// <typeparam name="M">Модель</typeparam>
  public abstract class View<M>
    where M : Model
  {
    /// <summary>
    /// Модель
    /// </summary>
    private readonly M _model;
    /// <summary>
    /// Запущено ли представление
    /// </summary>
    private bool _isStarted = false;

    /// <summary>
    /// Модель
    /// </summary>
    public M Model 
    { 
      get { return _model; } 
    }
    /// <summary>
    /// Запущено ли представление
    /// </summary>
    public bool IsStarted 
    { 
      get { return _isStarted; } 
      set { _isStarted = value; } 
    }
    

    /// <summary>
    /// Конструктор представления
    /// </summary>
    /// <param name="parModel">Модель</param>
    public View(M parModel)
    {
      _model = parModel;
    }

    /// <summary>
    /// Рисует представление
    /// </summary>
    public abstract void Draw();

    /// <summary>
    /// Запускает представление
    /// </summary>
    public virtual void Start()
    {
      if (!_isStarted)
      {
        _isStarted = true;
      }
    }

    /// <summary>
    /// Останавливает представление
    /// </summary>
    public virtual void Stop()
    {
      if (_isStarted)
      {
        _isStarted = false;
      }
    }
  }
}
