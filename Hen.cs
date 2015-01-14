//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// hen dairy and egg animal
    /// </summary>
    class Hen : DairyAndEggAnimal
    {
        /// <summary>
        /// create's a hen
        /// </summary>
        public Hen()
        {
            ProductImage = Properties.Resources.hen;
            MarketPrice = numberGenerator.Next(2000, 3001);
            PurchaseCost = 4000;
            BreedingTime = 3;
            UpkeepCost = 2000;
            MaxLifespan = 24;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
