using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrammerConsole
{
  class YieldFun
  {
    public void Run()
    {
      var ints = this.Produce();
      Consume(ints);

      /*      foreach (int i in Produce())
            {
              Console.WriteLine("consume " + i);
            }*/
    }

    private void Consume(IEnumerable<int>  ints)
    {
        foreach (int i in ints)
        {
          Console.WriteLine("consume " + i);
        //Task.Delay(1010);
        }
    }

    private IEnumerable<int> Produce()
    {
      while (true)
      {
        var rnd = new Random();
        var i = rnd.Next(0, 100);
        if (i % 5 == 0)
          yield break;
        Thread.Sleep(1000);
        Console.WriteLine("produce " + i);
        yield return i;
      }
    }
  }
}
