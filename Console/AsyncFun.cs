using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrammerConsole
{
  class AsyncFun
  {
    public async void Run()
    {
      Console.WriteLine("begin");

      //what's the difference of await startnew sync method and await startnew async method?
      //await Task.Factory.StartNew(LongTimeTask);
      await Task.Factory.StartNew(LongTimeTaskAsync);
      Console.WriteLine("end");
    }

    public void LongTimeTask()
    {
      Console.WriteLine("async task begin");
      Task.Delay(1000);
      Console.WriteLine("async task end");
    }


    public async void LongTimeTaskAsync()
    {
      Console.WriteLine("async task begin");
      await Task.Delay(1000);
      Console.WriteLine("async task end");
    }
  }
}
