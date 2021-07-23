// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class MergeSorter
    {
        // Private auxilary array that will be used to do the merge sort
        private IComparable[] auxilary;

        /// <summary>
        /// public sort method that is the entry point for sorting
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="Length">Length of valid entries in the array. (Non null)</param>
        public void Sort(IComparable[] array, int Length)
        {
            // Set up the auxilary array and make it the size of the valid spots in the array to sort
            auxilary = new IComparable[Length];
            // Call the private sort method which is also the recursive call
            sort(array, 0, Length - 1);
        }

        /// <summary>
        /// private sort method that will be called recursively
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="lo">Lowest index to sort</param>
        /// <param name="hi">Highest index to sort</param>
        private void sort(IComparable[] array, int lo, int hi)
        {
            // If the hi is <= the low, we are down to a single element sub array.
            // Time to return. This is the base case for the recursive call.
            if (hi <= lo)
            {
                return;
            }

            // Calculate the mid point. Note that the mid point for the sub array might not be between
            // zero and some other number. That's why we are adding the low back into the calculation.
            int mid = lo + (hi - lo) / 2;

            // Make recursive call to sort the left side
            sort(array, lo, mid);
            // Make recursive call to sort the right side
            sort(array, mid + 1, hi);
            // Merge the two sorted halfs together into a sorted whole.
            merge(array, lo, mid, hi);
        }

        /// <summary>
        /// Merge function for taking two sorted sub-arrays and merging them together into sorted order.
        /// </summary>
        /// <param name="array">array to sort that contains both sub arrays</param>
        /// <param name="lo">Low index</param>
        /// <param name="mid">Midpoint, which will be the high for the left sub-array</param>
        /// <param name="hi">High index, which will be the high for the right sub-array</param>
        private void merge(IComparable[] array, int lo, int mid, int hi)
        {
            // Set the i index that will be used to walk through the left half to the low that is passed in.
            int i = lo;
            // Set the j index that will be used to walk through the right half to the mid point + 1.
            int j = mid + 1;

            // Loop through all indicies and copy the data to the auxilary array
            for (int k = lo; k <= hi; k++)
            {
                auxilary[k] = array[k];
            }

            // Loop from low to hi using a seperate variable than the i and j that
            // mark the current index in the sub-arrays
            for (int k = lo; k <= hi; k++)
            {
                // If i index is greater than the mid point, than the only elements left are those in the right sub-array
                if (i > mid)
                {
                    // Copy the right array current index element to the finished array
                    // and increment the index counter for the right sub-array
                    array[k] = auxilary[j++];
                }
                // If j is greater than the hi point, than the only elements left are those in the right sub-array
                else if (j > hi)
                {
                    // Copy the left array current index element to the finished array
                    // and increment the index counter for the left sub-array
                    array[k] = auxilary[i++];
                }
                // If both indicies are valid, need to compare the two elements to see which one is smaller.
                // If the compare to returns -1, we want to move the right sub-array element
                else if (auxilary[j].CompareTo(auxilary[i]) < 0)
                {
                    // Do the same as above to move the correct element to the finished array
                    array[k] = auxilary[j++];
                }
                // Else we need to move the other element
                else
                {
                    // Do the same as above to move the correct element to the finished array
                    array[k] = auxilary[i++];
                }
            }
        }
    }
}
