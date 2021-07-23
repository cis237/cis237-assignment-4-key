// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
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
            // Set length of collection to 0
            lengthOfCollection = 0;
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
                // Return false
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

        /// <summary>
        /// Public method to Sort the droids into categories using a modified bucket sort
        /// </summary>
        public void SortIntoCategories()
        {
            // Create a generic stack for each type of droid, and pass in the droid type as the generic that will
            // come through on the stack class as T.
            GenericStack<ProtocolDroid> protocolStack = new GenericStack<ProtocolDroid>();
            GenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
            GenericStack<JanitorDroid> janitorStack = new GenericStack<JanitorDroid>();
            GenericStack<AstromechDroid> astromechStack = new GenericStack<AstromechDroid>();

            // Create a queue to hold the droids as we pop them off the stack.
            GenericQueue<IDroid> categorizedDroidQueue = new GenericQueue<IDroid>();

            // For each IDroid in the droidCollection
            foreach (IDroid droid in this.droidCollection)
            {
                // If the droid is not null we want to process it. If it is null we will go to the else
                if (droid != null)
                {
                    // The testing of the droids must occur in this order. It must be done in the order of
                    // most specific droid to least specific.

                    // If we were to test a droid that IS of type Astromech against Utility BEFORE we test against
                    // Astromech, it would pass and be put into the Utility stack and not the Astromech. That is why it
                    // is important to test from most specific to least.

                    // If the droid is an Astromech, push it on the astromech stack
                    if (droid is AstromechDroid)
                    {
                        astromechStack.Push((AstromechDroid)droid);
                    }
                    // Else if it is a JanitorDroid, push it on the janitor stack
                    else if (droid is JanitorDroid)
                    {
                        janitorStack.Push((JanitorDroid)droid);
                    }
                    // Do for Utility
                    else if (droid is UtilityDroid)
                    {
                        utilityStack.Push((UtilityDroid)droid);
                    }
                    // Do for Protocol
                    else if (droid is ProtocolDroid)
                    {
                        protocolStack.Push((ProtocolDroid)droid);
                    }
                }
                // The droid we are trying to consider is null, break out of the loop.
                else
                {
                    break;
                }
            }

            // Now that the droids are all in thier respective stacks we can do the work
            // of poping them off of the stacks and adding them to the queue.
            // It is required that they be popped off from each stack in this order so that they have
            // the correct order going into the queue.

            // This is a primer pop. It gets the first droid off the stack, which could be null if the stack is empty
            AstromechDroid currentAstromechDroid = astromechStack.Pop();
            // While the droid that is popped off is not null
            while (currentAstromechDroid != null)
            {
                // Add the popped droid to the queue.
                categorizedDroidQueue.Enqueue(currentAstromechDroid);
                // Pop off the next droid for the loop test
                currentAstromechDroid = astromechStack.Pop();
            }

            // See above method for Astromech. It is the same except for Janitor
            JanitorDroid currentJanitorDroid = janitorStack.Pop();
            while (currentJanitorDroid != null)
            {
                categorizedDroidQueue.Enqueue(currentJanitorDroid);
                currentJanitorDroid = janitorStack.Pop();
            }

            // See above method for Astromech. It is the same except for Utility
            UtilityDroid currentUtilityDroid = utilityStack.Pop();
            while (currentUtilityDroid != null)
            {
                categorizedDroidQueue.Enqueue(currentUtilityDroid);
                currentUtilityDroid = utilityStack.Pop();
            }

            // See above method for Astromech. It is the same except for Protocol
            ProtocolDroid currentProtocolDroid = protocolStack.Pop();
            while (currentProtocolDroid != null)
            {
                categorizedDroidQueue.Enqueue(currentProtocolDroid);
                currentProtocolDroid = protocolStack.Pop();
            }

            // Now that the droids have all been removed from the stacks and put into the queue
            // we need to dequeue them all and put them back into the original array.

            // Set a int counter to 0.
            int counter = 0;

            // This is a primer dequeue that will get the first droid out of the queue.
            IDroid iDroid = categorizedDroidQueue.Dequeue();
            // While the dequeued droid is not null.
            while (iDroid != null)
            {
                // Add the droid to the droid collection using the int counter as the index
                this.droidCollection[counter] = iDroid;
                // Increment the counter
                counter++;
                // Dequeue the next droid off the queue so it can be used in the while condition
                iDroid = categorizedDroidQueue.Dequeue();
            }

            // Set the length of the collection to the value of the counter. It should be the same, but in case it changed.
            this.lengthOfCollection = counter;
        }


        /// <summary>
        /// Public method to sort the droids by the Total Cost. It uses the merge sort class to sort them.
        /// since each droid implements the IComparable interface, we can use polymorphism to send the droids
        /// into the merge sorter even though the merge sort takes in an array of IComparable.
        /// </summary>
        public void SortByTotalCost()
        {
            // Create a new merge sorter class.
            MergeSorter mergeSorter = new MergeSorter();
            // Make sure that CalculateTotalCost gets called on each droid before sorting
            foreach (Droid droid in droidCollection)
            {
                if (droid != null)
                {
                    droid.CalculateTotalCost();
                }
            }
            // Call the sort method on the Merge sorter instance and pass it both the
            // array to sort, and the length of valid droids in the array.
            mergeSorter.Sort(this.droidCollection, this.lengthOfCollection);
        }
    }
}
