using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrammerConsole
{
  class TaskException
  {
    public void Run()
    {
     WaitTaskThrowException();
    }

    private void TaskThrowException()
    {
      /*below  exception doesn't crash app*/
      Task.Run(() => throw new Exception("haha"));

      Console.WriteLine("app contine after delegate of task throw exception");


      //throw new Exception("fdsa");
    }

    private void WaitTaskThrowException()
    {
       Task t = Task.Run(() => throw new Exception("exception in delegate of task"));
      try { 
      //below line of codes throw throw exception
      t.Wait();
      }
      catch(AggregateException ae)
      {
        Console.WriteLine(ae.InnerException.Message);
      }
      Console.WriteLine("app contine after delegate of task throw exception");


      //throw new Exception("fdsa");
    }
  }
}
