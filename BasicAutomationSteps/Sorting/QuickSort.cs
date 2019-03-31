using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAutomationSteps.Sorting
{
    class QuickSort
    {
        public static void quicksort(int [] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
        public static void quickSort(int []  array, int left, int right)
        {
            if(left>=right)
            {
                return;
            }
            int pivot = array[(left + right) / 2];
        }
    }
}
