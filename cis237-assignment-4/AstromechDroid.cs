using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class AstromechDroid : UtilityDroid
    {
        // Protected constant for the cost per ship. Children can access this too.
        protected decimal COST_PER_SHIP = 45.00m;

        // Class level variables unique to this class. Set as protected so children classes can access them.
        protected bool hasFireExtinguisher;
        protected int numberOfShips;

        // Constructor that uses the Base Constuctor to do most of the work.
        public AstromechDroid(string Material, string Color,
            bool HasToolbox, bool HasComputerConnection, bool HasArm, bool HasFireExtinquisher, int NumberOfShips) :
            base(Material, Color, HasToolbox, HasComputerConnection, HasArm)
        {
            // Set the Droid Cost
            MODEL_COST = 200.00m;
            // Assign the values for the constructor that are not handled by the base constructor
            this.hasFireExtinguisher = HasFireExtinquisher;
            this.numberOfShips = NumberOfShips;
        }

        // Overridden method to calculate the cost of options. Uses the base class to do some of the calculations
        protected override decimal CalculateCostOfOptions()
        {
            decimal optionsCost = 0;

            optionsCost += base.CalculateCostOfOptions();

            if (hasFireExtinguisher)
            {
                optionsCost += COST_PER_OPTION;
            }

            return optionsCost;
        }

        // Protected virtual method that can be overriden in child classes.
        // Caclulates the cost of ships.
        protected virtual decimal CalculateCostOfShips()
        {
            return COST_PER_SHIP * numberOfShips;
        }

        // Overriden method to calculate the total cost. Uses work from the base class to achive the answer.
        public override void CalculateTotalCost()
        {
            this.CalculateBaseCost();

            this.totalCost = this.baseCost + MODEL_COST + this.CalculateCostOfOptions() + this.CalculateCostOfShips();
        }

        protected override string GetModelName()
        {
            return "Astromech";
        }

        // Overriden ToString method to output the information for this droid. Uses work done in the base class
        public override string ToString()
        {
            return
                base.ToString() +
                "Has Fire Extinguisher: " + this.hasFireExtinguisher + Environment.NewLine +
                "Number Of Ships: " + this.numberOfShips + Environment.NewLine;
        }
    }
}
