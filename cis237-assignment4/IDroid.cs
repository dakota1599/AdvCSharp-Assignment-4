/*
 DAKOTA SHAPIRO
 CIS 237 MW 3:30PM - 5:45PM
 LAST UPDATED: 10/31/19
 */

using System;

namespace cis237_assignment4
{
    interface IDroid : IComparable //Implementing IComparable so that we can compare droids later on.
    {
        // Method to calculate the total cost of a droid
        void CalculateTotalCost();

        // Property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
