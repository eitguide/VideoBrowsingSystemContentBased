using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Utils
{
    public class SortingHelper
    {
        public static List<int> SortAsc(List<double> inputList)
        {
            List<int> listSortedIndex = new List<int>();
            for (int i = 0; i < inputList.Count; i++)
                listSortedIndex.Add(i);

            {
                int j, i;
                int n = inputList.Count;
                for (i = 0; i < n - 1; i++)
                {
                    int iMin = i;

                    // skip NaN
                    while (iMin < n-1 && double.IsNaN(inputList[listSortedIndex[iMin]]))
                        iMin++;

                    for (j = iMin + 1; j < n; j++)
                    {
                        if (inputList[listSortedIndex[j]] < inputList[listSortedIndex[iMin]])
                        {
                            iMin = j;
                        }
                    }

                    if (iMin != i)
                    {
                        int temp = listSortedIndex[i];
                        listSortedIndex[i] = listSortedIndex[iMin];
                        listSortedIndex[iMin] = temp;
                    }
                }
            }

            return listSortedIndex.Count == 0 ? null : listSortedIndex;
        }
    }
}
