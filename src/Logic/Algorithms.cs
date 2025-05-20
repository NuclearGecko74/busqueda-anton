using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busqueda_anton.src
{
    public static class Algorithms
    {
        public static int LinearSearch(List<int> list, int target)
        {
            for(int i = 0; i < list.Count(); i++)
            {
                if (list[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearch(List<int> list, int target)
        {
            int low = 0;
            int high = list.Count - 1;

            while(low <= high)
            {
                int middle = low + (high - low) / 2;
                int value = list[middle];

                if (value < target)
                {
                    low = middle + 1;
                }
                else if (value > target)
                {
                    high = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
