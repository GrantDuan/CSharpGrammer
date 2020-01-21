using System;

namespace GrammerConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var af = new AsyncFun();
      af.Run();

      Console.Read();
    }
  }
}
