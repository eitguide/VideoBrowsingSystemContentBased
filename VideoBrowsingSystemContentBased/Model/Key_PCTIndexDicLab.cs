using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class Key_PCTIndexDicLab
    {
        public double L { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public string region { get; set; }

        public Key_PCTIndexDicLab(double _L, double _a, double _b, string _region)
        {
            L = _L;
            a = _a;
            b = _b;
            region = _region;
        }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Key_PCTIndexDicLab keyForCompare = (Key_PCTIndexDicLab)obj;
            return (L == keyForCompare.L) && (a == keyForCompare.a) && (b == keyForCompare.b) && (region == keyForCompare.region);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
