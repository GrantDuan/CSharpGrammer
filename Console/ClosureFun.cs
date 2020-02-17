using System;
using System.Collections.Generic;
using System.Text;

namespace GrammerConsole
{
  class ClosureFun
  {
    public void Run()
    {
      int maxLength = 0;

      Predicate<string> predicate = item => { maxLength++; Console.WriteLine("maxLength: " + maxLength); return item.Length <= maxLength; };
      IList<string> shortWords = ListUtil.Filter(SampleData.Words, predicate);
      ListUtil.Dump(shortWords);

    }
  }
}
