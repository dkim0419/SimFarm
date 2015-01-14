//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// Corn is an Annual Plant product
    /// </summary>
    class Corn : AnnualPlant
    {   
        /// <summary>
        /// create's a corn plant.
        /// </summary>
        public Corn()
        {
            ProductImage = Properties.Resources.corn;
            MarketPrice = numberGenerator.Next(5000, 7001);
            PurchaseCost = 500;
            BreedingTime = 2;
            UpkeepCost = 500;
            MaxLifespan = 3;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
