using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GrammerConsole
{
  class ActionBlockFun
  {
    public async void Run()
    {
      var actionBlock = new ActionBlock<int>(async request =>
      {
        var result = await ComplicatedComputation(request);
        Console.WriteLine(result);
      }, new ExecutionDataflowBlockOptions
      {
        BoundedCapacity = 2
      });

      await actionBlock.SendAsync(1); // is processed immediately
      await actionBlock.SendAsync(2); // is accepted immediately, goes into a queue "inside" the ActionBlock


      var wasAccepted = actionBlock.Post(3); //wasAccepted will be true (it's in the queue because BoundedCapacity's default value is Unbounded)            

      actionBlock.Complete();

      try
      {
        await actionBlock.Completion; //blocks here until request 2 throws exception
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.GetType().Name); //Prints InvalidOperationException
      }

    }

    private async Task<int> ComplicatedComputation(int request)
    {
      await Task.Delay(1000);
      if (request == 2)
        throw new Exception("HAHA");

      return request * request;

      
    }
  }
}
