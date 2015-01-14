//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //broccoli perennial plant
    class Broccoli : PerennialPlant
    {
        /// <summary>
        /// create's a broccoli plant.
        /// </summary>
        public Broccoli()
        {
            ProductImage = Properties.Resources.broccoli;
            MarketPrice = numberGenerator.Next(5000, 12001);
            PurchaseCost = 12000;
            BreedingTime = 2;
            UpkeepCost = 2000;
            MaxLifespan = 3;
            WaitingPeriod = 2;
            AssignQualityRating();
            CanHarvest = false;
            MonthsNotGrowing = -1;
        }
    }
}
