//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// cow dairy and egg animal
    /// </summary>
    class Cow : DairyAndEggAnimal
    {
        /// <summary>
        /// create's a cow
        /// </summary>
        public Cow()
        {
            ProductImage = Properties.Resources.cow;
            MarketPrice = numberGenerator.Next(3000, 4001);
            PurchaseCost = 30000;
            BreedingTime = 3;
            UpkeepCost = 3000;
            MaxLifespan = 72;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
