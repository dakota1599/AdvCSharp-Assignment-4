/*
 DAKOTA SHAPIRO
 CIS 237 MW 3:30PM - 5:45PM
 LAST UPDATED: 10/31/19
 */


using System;

namespace cis237_assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            // Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            // Display the main greeting for the program
            userInterface.DisplayGreeting();

            // Display the main menu for the program
            userInterface.DisplayMainMenu();

            // Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            // While the choice is not equal to 3, continue to do work with the program
            while (choice != 5)
            {
                // Test which choice was made
                switch (choice)
                {
                    // Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    // Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;

                    // Choose to Sort List by Type
                    case 3:
                        droidCollection.BucketSort();

                        //Printing back out the newly ordered list.
                        Console.WriteLine("\n[List Sorted by Droid Type]");
                        break;
                    // Choose to Sort List by Total Cost
                    case 4:
                        droidCollection.MergeSort();

                        //Printing back out the newly ordered list.
                        Console.WriteLine("\n[List Sorted by Total Cost]");
                        break;
                }
                // Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }
        }
    }
}
