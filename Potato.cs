//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //potato perennial plant
    class Potato:PerennialPlant
    {
        /// <summary>
        /// create's a potato plant.
        /// </summary>
        public Potato()
        {
            ProductImage = Properties.Resources.potato;
            MarketPrice = numberGenerator.Next(6000, 8001);
            PurchaseCost = 10000;
            BreedingTime = 3;
            UpkeepCost = 1000;
            MaxLifespan = 4;
            WaitingPeriod = 1;
            AssignQualityRating();
            CanHarvest = false;
            MonthsNotGrowing = -1;
        }
    }
}
