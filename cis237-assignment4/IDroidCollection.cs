/*
 DAKOTA SHAPIRO
 CIS 237 MW 3:30PM - 5:45PM
 LAST UPDATED: 10/31/19
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    interface IDroidCollection
    {
        // Various overloaded Add methods to add a new droid to the collection
        bool Add(string Material, string Color, int NumberOfLanguages);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips);

        // Method to get the data for a droid into a nicely formated string that can be output.
        string GetPrintString();

        // The sort methods to be overriden in the below droid collection class.
        void BucketSort();
        void MergeSort();

    }
}
