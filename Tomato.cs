//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// Tomato is an Annual Plant product
    /// </summary>
    class Tomato : AnnualPlant
    {
        /// <summary>
        /// create's a tomato plant.
        /// </summary>
        public Tomato()
        {
            ProductImage = Properties.Resources.tomato;
            MarketPrice = numberGenerator.Next(15000, 20001);
            PurchaseCost = 2000;
            BreedingTime = 3;
            UpkeepCost = 2000;
            MaxLifespan = 4;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
