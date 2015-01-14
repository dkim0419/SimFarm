//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //sweet potato perennial plant
    class SweetPotato : PerennialPlant
    {
        /// <summary>
        /// create's a sweet potato plant.
        /// </summary>
        public SweetPotato()
        {
            ProductImage = Properties.Resources.sweet_potato;
            MarketPrice = numberGenerator.Next(8000, 10001);
            PurchaseCost = 17000;
            BreedingTime = 2;
            UpkeepCost = 3000;
            MaxLifespan = 3;
            WaitingPeriod = 1;
            AssignQualityRating();
            CanHarvest = false;
            MonthsNotGrowing = -1;
        }
    }
}
