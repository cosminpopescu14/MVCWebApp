using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Alg
{
    //Quicksort algorithm. Hoare partition scheme
    public class Qsort
    {
        // array partition
        public static int Partition(int[] array, int left, int right)
        {
            int _left = left;
            int _rigth = right;
            int temp, i, j;
            int pivot = array[_left];
            i = _left - 1;
            j = _rigth + 1;
            
            while (true)
            {
                do
                {
                    j--;
                } while (array[j] > pivot);

                do
                {
                    i++;
                } while (array[i] < pivot);

                if (i < j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
                else
                    return j;
            }
            
        }

        /**
            parameter - array to sort
            returns a sorted array
        **/
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(array, left, right);
                QuickSort(array, left, p);
                QuickSort(array, p + 1, right);
            }
        }
    }
}