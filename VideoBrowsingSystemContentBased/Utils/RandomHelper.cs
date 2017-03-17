using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Utils
{
  public class RandomHelper
    {

      /// <summary>
      /// Random number [a, b]
      /// </summary>
      /// <param name="a">a</param>
      /// <param name="b">b</param>
      /// <returns></returns>
      public static int RandomAB(int a, int b)
      {
          Random random = new Random();
          return random.Next(b - a) + a;
      }
    }
}
