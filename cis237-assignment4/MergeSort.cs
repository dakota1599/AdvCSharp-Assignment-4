/*
 DAKOTA SHAPIRO
 CIS 237 MW 3:30PM - 5:45PM
 LAST UPDATED: 10/31/19
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class MergeSort
    {
        // The following are the overloaded sort methods

        /// <summary>
        /// Public version of sort for being accessed by the outside.  Sets up all the necessary
        /// variables for use in the private sort.
        /// </summary>
        /// <param name="a"></param>
        public void Sort(IComparable[] a) {
            IComparable[] aux = new IComparable[a.Length];
            Sort(a, aux, 0, a.Length - 1);
        }

        /// <summary>
        /// Private version of sort for splitting the arrays into smaller and smaller "arrays"
        /// so they can be processed by the merge method.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="aux"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private void Sort(IComparable[] a, IComparable[] aux, int lo, int hi) {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        //************************************************************************

        
        /// <summary>
        /// This method is for easily comparing the two array indexes in the merge method.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }


        /// <summary>
        /// The merge method is where the arrays are actually sorted.  It is called for
        /// each division of the original array.  From the one to one arrays all the way back
        /// to one split array.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="aux"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi) {

            //To copy a to aux.
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];

            //For merging back into a.
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }


    }
}
