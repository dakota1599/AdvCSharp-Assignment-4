using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        // Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;




        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];

            //Hard coded in droids for testing and what not.
            droidCollection[0] = new JanitorDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, false);
            droidCollection[1] = new ProtocolDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, 5);
            droidCollection[2] = new UtilityDroid(Droid.Materials.Quadranium, Droid.Colors.Blue, true, false, true);
            droidCollection[3] = new ProtocolDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, 5);
            droidCollection[4] = new JanitorDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, false);
            droidCollection[5] = new JanitorDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, false);
            droidCollection[6] = new AstromechDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, 10);
            droidCollection[7] = new ProtocolDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, 5);
            droidCollection[8] = new UtilityDroid(Droid.Materials.Quadranium, Droid.Colors.Blue, true, false, true);
            droidCollection[9] = new AstromechDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, 10);
            droidCollection[10] = new JanitorDroid(Droid.Materials.Carbonite, Droid.Colors.Blue,true, true, true, true, false);
            droidCollection[11] = new AstromechDroid(Droid.Materials.Carbonite, Droid.Colors.Blue, true, true, true, true, 10);



            // Set length of collection to 0
            lengthOfCollection = 12;
        }

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                // Increase the length of the collection
                lengthOfCollection++;
                // Return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            // Return the completed string
            return returnString;
        }

        public void BucketSort() {
            //Creating the stacks for each of the droid types.
            GenericStack<IDroid> astroStack = new GenericStack<IDroid>();
            GenericStack<IDroid> janStack = new GenericStack<IDroid>();
            GenericStack<IDroid> proStack = new GenericStack<IDroid>();
            GenericStack<IDroid> utilStack = new GenericStack<IDroid>();

            //Creating the queue that all the droids will be in.
            GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

            //For looping through the array of droids.
            for (int i = 0; i < droidCollection.Length; i++) {
                //If the index of the collection is null, the loop ends.
                if (droidCollection[i] == null)
                {
                    i = droidCollection.Length;
                }
                else {
                    //The following checks to see if the current index of the collection is
                    //one of the four droid types. It then places them in their respective
                    //stacks.
                    if (droidCollection[i] is AstromechDroid)
                    {
                        astroStack.Push(droidCollection[i]);
                    }
                    else if (droidCollection[i] is JanitorDroid)
                    {
                        janStack.Push(droidCollection[i]);
                    }
                    else if (droidCollection[i] is UtilityDroid)
                    {
                        utilStack.Push(droidCollection[i]);
                    }
                    else {
                        proStack.Push(droidCollection[i]);
                    }
                }
            }

            //This will hold the size for each stack since their sizes decrease with each
            //call of Pop().
            int sizeHold = astroStack.Size;

            //All four of the stacks are then emptied into the queue using for loops.
            for (int i = 0; i < sizeHold; i++) {
                droidQueue.Enqueue(astroStack.Pop());
            }
            sizeHold = janStack.Size;
            for (int i = 0; i < sizeHold; i++) {
                droidQueue.Enqueue(janStack.Pop());
            }
            sizeHold = utilStack.Size;
            for (int i = 0; i < sizeHold; i++) {
                droidQueue.Enqueue(utilStack.Pop());
            }
            sizeHold = proStack.Size;
            for (int i = 0; i < sizeHold; i++) {
                droidQueue.Enqueue(proStack.Pop());
            }

            //Now adding all the stuff from the queue back into the original collection.
            for (int i = 0; i < lengthOfCollection; i++) {
                droidCollection[i] = droidQueue.Dequeue();
            }

           

        }
    }
}
