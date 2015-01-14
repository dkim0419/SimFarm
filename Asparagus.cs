//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //asparagus perennial plant
    class Asparagus:PerennialPlant
    {
        /// <summary>
        /// create's a asparagus plant.
        /// </summary>
        public Asparagus()
        {
            ProductImage = Properties.Resources.asparagus;
            MarketPrice = numberGenerator.Next(15000, 20001);
            PurchaseCost = 15000;
            BreedingTime = 2;
            UpkeepCost = 3000;
            MaxLifespan = 3;
            WaitingPeriod = 2;
            AssignQualityRating();
            CanHarvest = false;
            MonthsNotGrowing = -1;
        }
    }
}
