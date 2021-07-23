// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;

namespace cis237_assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            // Create a few droids to put into the list so that they do not NEED to be made through the UI
            droidCollection.Add(Droid.Materials.Carbonite, Droid.Colors.White, 12);
            droidCollection.Add(Droid.Materials.Vanadium, Droid.Colors.Red, true, true, true);
            droidCollection.Add(Droid.Materials.Quadranium, Droid.Colors.Blue, true, true, true, true, true);
            droidCollection.Add(Droid.Materials.Tears_Of_A_Jedi, Droid.Colors.Green, true, true, false, true, 80);
            droidCollection.Add(Droid.Materials.Tears_Of_A_Jedi, Droid.Colors.Blue, 22);
            droidCollection.Add(Droid.Materials.Quadranium, Droid.Colors.Red, false, false, false, false, true);
            droidCollection.Add(Droid.Materials.Vanadium, Droid.Colors.White, true, true, false);
            droidCollection.Add(Droid.Materials.Carbonite, Droid.Colors.Green, false, true, false, true, 150);
            droidCollection.Add(Droid.Materials.Carbonite, Droid.Colors.Green, false, true, true, true, true);
            droidCollection.Add(Droid.Materials.Vanadium, Droid.Colors.White, true, false, true);
            droidCollection.Add(Droid.Materials.Quadranium, Droid.Colors.Red, true, false, false, true, 100);
            droidCollection.Add(Droid.Materials.Tears_Of_A_Jedi, Droid.Colors.Blue, false, true, false, true, true);

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

                    // Print in categorical order
                    case 3:
                        droidCollection.SortIntoCategories();
                        userInterface.DisplaySortCategoriesSuccessMessage();
                        break;

                    // Print in total cost order
                    case 4:
                        droidCollection.SortByTotalCost();
                        userInterface.DisplaySortTotalCostSuccessMessage();
                        break;
                }
                // Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }
        }
    }
}
