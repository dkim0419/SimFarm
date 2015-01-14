//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// pork meat animal
    /// </summary>
    class Pork : MeatAnimal
    {
        /// <summary>
        /// create's a pork
        /// </summary>
        public Pork()
        {
            ProductImage = Properties.Resources.pork;
            MarketPrice = numberGenerator.Next(40000, 60001);
            PurchaseCost = 20000;
            BreedingTime = 3;
            UpkeepCost = 2000;
            MaxLifespan = 6;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
