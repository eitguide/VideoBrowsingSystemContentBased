using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Utils
{
  public class RandomHelper
    {
      public static int RandomAB(int a, int b)
      {
          Random random = new Random();
          return random.Next(b - a) + a;
      }
    }
}
