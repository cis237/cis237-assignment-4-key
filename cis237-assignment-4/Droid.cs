﻿// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    abstract class Droid : IDroid
    {
        // Constant for Droid Cost. Must be a static variable vs const so it can be assigned to
        // in the constructor of child classes.
        protected static decimal MODEL_COST;

        // Some protected variables for the class
        protected string material;
        protected string color;

        protected decimal baseCost;
        protected decimal totalCost;

        // Create a inner class for the sole purpose of acting like a collection of constants
        public sealed class Materials
        {
            private Materials() { }
            public const string Carbonite = "Carbonite";
            public const string Vanadium = "Vanadium";
            public const string Quadranium = "Quadranium";
            public const string Tears_Of_A_Jedi = "Tears Of A Jedi";
        }

        // Create a inner class for the sole purpose of acting like a collection of constants
        public sealed class Colors
        {
            private Colors() { }
            public const string White = "White";
            public const string Red = "Red";
            public const string Green = "Green";
            public const string Blue = "Blue";
        }

        // The public property for TotalCost
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        // Constructor that takes the main 2 parameters shared amongst all 4 instanceable types of droids
        public Droid(string Material, string Color)
        {
            this.material = Material;
            this.color = Color;
        }

        // Virtual method that can be overridden in the derived classes if needed.
        // This implementation calculates the cost based on the material used for the droid
        protected virtual void CalculateBaseCost()
        {
            baseCost = this.getMaterialCost() + this.getColorCost();
        }

        // Abstract method that MUST be overriden in the derived class to calculate the total cost
        public abstract void CalculateTotalCost();

        // Overriden toString method that will return a string representing the basic information for any droid
        public override string ToString()
        {
            return "Material: " + this.material + Environment.NewLine +
                    "Color: " + this.color + Environment.NewLine;
        }

        // Have to implement the CompareTo function because Droid implements IDroid, and IDroid implements IComparable
        public int CompareTo(Object obj)
        {
            // If the obj that is passed in is null, just return 1. Unable to compare
            if (obj == null)
            {
                return 1;
            }

            // Cast the obj to a droid.
            Droid droid = (Droid)obj;

            // Check to see if the droid is null. Perhaps the cast will fail and droid will be null.
            if (droid != null)
            {
                // Do the comparison. Rather than doing the work of returning -1, 0, or 1
                // I just delegated the work to the CompareTo method of decimal
                return this.TotalCost.CompareTo(droid.TotalCost);
            }
            // Else, the droid is null, so the droid that was passed in must not have been a droid.
            // Throw an exception stating so.
            else
            {
                throw new ArgumentException("Object is not a Droid");
            }
        }

        // Method to get the cost of a certain material.
        private decimal getMaterialCost()
        {
            decimal materialCost;

            switch (this.material)
            {
                case Materials.Carbonite:
                    materialCost = 100.00m;
                    break;

                case Materials.Vanadium:
                    materialCost = 120.00m;
                    break;

                case Materials.Quadranium:
                    materialCost = 150.00m;
                    break;

                case Materials.Tears_Of_A_Jedi:
                    materialCost = 200.00m;
                    break;

                default:
                    materialCost = 50.00m;
                    break;
            }

            return materialCost;
        }

        // Method to get the cost of a ceratin color.
        private decimal getColorCost()
        {
            decimal colorCost;

            switch (this.color)
            {
                case Colors.White:
                    colorCost = 10.00m;
                    break;

                case Colors.Red:
                    colorCost = 20.00m;
                    break;

                case Colors.Green:
                    colorCost = 40.00m;
                    break;

                case Colors.Blue:
                    colorCost = 50.00m;
                    break;

                default:
                    colorCost = 5.00m;
                    break;
            }

            return colorCost;
        }
    }
}
