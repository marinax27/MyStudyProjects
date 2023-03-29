using System.Windows;
using WPF;

namespace Console
{
  /// <summary>
  /// Логика взаимодействия для App.xaml
  /// </summary>
  public partial class App : Application
  {
    /// <summary>
    /// Запуск приложения
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      new WPFApplication().Start();
    }
  }
}
