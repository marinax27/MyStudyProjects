using Microsoft.Win32.SafeHandles;
using System.Text;
using static Console.FastConsole;

namespace Console
{
  /// <summary>
  /// Помощник по работе с быстрым выводом в консоль
  /// </summary>
  public class FastConsoleOutput
  {
    /// <summary>
    /// Дескриптор файла
    /// </summary>
    private static SafeFileHandle _h;
    /// <summary>
    /// Буфер символов
    /// </summary>
    private static CharInfo[] _buf;
    /// <summary>
    /// Прямоугольник
    /// </summary>
    private static SmallRect _rect;
    /// <summary>
    /// Ширина 
    /// </summary>
    private static short _width;
    /// <summary>
    /// Высота
    /// </summary>
    private static short _height;

    /// <summary>
    /// Устанавливает пиксель
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="attribute">Цвет</param>
    public static void SetPixel(int parX, int parY, short attribute)
    {
      if (parX < _width && parY < _height && parX >= 0 && parY >= 0)
      {
        _buf[parY * _width + parX].Attributes = attribute;
        _buf[parY * _width + parX].Char.AsciiChar = 219;
      }
    }

    /// <summary>
    /// Пишет строку
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parAttribute">Цвет</param>
    /// <param name="parStr">Строка</param>
    public static void SetString(int parX, int parY, short parAttribute, string parStr)
    {
      byte[] asciiBytes = Encoding.ASCII.GetBytes(parStr);
      for (int i = 0; i < parStr.Length; i++)
      {
        int x = parX + i;
        if (x < _width && parY < _height && x >= 0 && parY >= 0)
        {
          _buf[parY * _width + x].Attributes = parAttribute;
          _buf[parY * _width + x].Char.AsciiChar = asciiBytes[i];
        }
      }
    }

    /// <summary>
    /// Рисует прямоугольник в буфере
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parAttribute">Цвет</param>
    public static void SetRectangle(int parX, int parY, int parWidth, int parHeight, short parAttribute)
    {
      for (int i = parX; i <= parX + parWidth; i++)
      {
        for (int j = parY; j <= parY + parHeight; j++)
        {
          SetPixel(i, j, parAttribute);
        }
      }
    }

    /// <summary>
    /// Инициализирует
    /// </summary>
    public static void Init()
    {
      _width = ConsoleApplication.WINDOW_WIDTH;
      _height = ConsoleApplication.WINDOW_HEIGHT;
      _h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

      if (!_h.IsInvalid)
      {
        _buf = new CharInfo[_width * _height];
        _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
      }
    }

    /// <summary>
    /// Рисует все символы из буфера в консоли
    /// </summary>
    public static void Draw()
    {
      WriteConsoleOutput(_h, _buf,
                 new Coord() { X = _width, Y = _height },
                 new Coord() { X = 0, Y = 0 },
                 ref _rect);
    }

    /// <summary>
    /// Рисует прямоуголник в буфере
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parColor">Цвет</param>
    public static void DrawRectangle(int parX, int parY, int parWidth, int parHeight, short parColor)
    {
      for (int i = parX; i <= parX + parWidth; i++)
      {
        for (int j = parY; j <= parY + parHeight; j++)
        {
          SetPixel(i, j, parColor);
        }
      }
    }
  }
}
