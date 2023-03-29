using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Console
{
  /// <summary>
  /// Средства для работы с быстрым выводом в консоль
  /// </summary>
  public class FastConsole
  {
    /// <summary>
    /// Координата
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
      public short X;
      public short Y;

      public Coord(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    };

    /// <summary>
    /// Объединение символов ASCII и Unicode
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
      [FieldOffset(0)] public char UnicodeChar;
      [FieldOffset(0)] public byte AsciiChar;
    }

    /// <summary>
    /// Информация о символе
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
      [FieldOffset(0)] public CharUnion Char;
      [FieldOffset(2)] public short Attributes;
    }

    /// <summary>
    /// Прямоугольник
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
      public short Left;
      public short Top;
      public short Right;
      public short Bottom;
    }

    /// <summary>
    /// Создает файл
    /// </summary>
    /// <param name="fileName">Название файла</param>
    /// <param name="fileAccess">Доступ к файлу</param>
    /// <param name="fileShare"></param>
    /// <param name="securityAttributes">Атрибуты безопасности</param>
    /// <param name="creationDisposition"></param>
    /// <param name="flags">Флаги</param>
    /// <param name="template">Шаблон</param>
    /// <returns>Дескриптор файла</returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern SafeFileHandle CreateFile(
    string fileName,
    [MarshalAs(UnmanagedType.U4)] uint fileAccess,
    [MarshalAs(UnmanagedType.U4)] uint fileShare,
    IntPtr securityAttributes,
    [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
    [MarshalAs(UnmanagedType.U4)] int flags,
    IntPtr template);

    /// <summary>
    /// Выводит в консоль
    /// </summary>
    /// <param name="hConsoleOutput"></param>
    /// <param name="lpBuffer"></param>
    /// <param name="dwBufferSize"></param>
    /// <param name="dwBufferCoord"></param>
    /// <param name="lpWriteRegion"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteConsoleOutput(
      SafeFileHandle hConsoleOutput,
      CharInfo[] lpBuffer,
      Coord dwBufferSize,
      Coord dwBufferCoord,
      ref SmallRect lpWriteRegion);

  }
}
