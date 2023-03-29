namespace Core.MVC
{
  /// <summary>
  /// Контроллер MVC
  /// </summary>
  /// <typeparam name="M">Модель</typeparam>
  /// <typeparam name="V">Представление</typeparam>
  public abstract class Controller<M, V>
    where M : Model
    where V : View<M>
  {
    /// <summary>
    /// Модель
    /// </summary>
    private readonly M _model;
    /// <summary>
    /// Представление
    /// </summary>
    private readonly V _view;

    /// <summary>
    /// Модель
    /// </summary>
    public M Model 
    { 
      get { return _model; } 
    }
    /// <summary>
    /// Представление
    /// </summary>
    public V View 
    { 
      get { return _view; } 
    }

    /// <summary>
    /// Конструктор контроллера MVC 
    /// </summary>
    /// <param name="parModel">Модель</param>
    /// <param name="parView">Представление</param>
    public Controller(M parModel, V parView)
    {
      _model = parModel;
      _view = parView;
    }

    /// <summary>
    /// Запускает контроллер MVC
    /// </summary>
    public virtual void Start()
    {
      _view.Start();
    }

    /// <summary>
    /// Останавливает контроллер MVC
    /// </summary>
    public virtual void Stop()
    {
      _view.Stop();
    }
  }
}
