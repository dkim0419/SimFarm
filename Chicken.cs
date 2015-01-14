using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //create a chicken meat animal
    class Chicken:MeatAnimal
    {
        /// <summary>
        /// create's a chicken
        /// </summary>
        public Chicken()
        {
            ProductImage = Properties.Resources.chicken;
            MarketPrice = numberGenerator.Next(10000, 12001);
            PurchaseCost = 4000;
            BreedingTime = 4;
            UpkeepCost = 1000;
            MaxLifespan = 8;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
