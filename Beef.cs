//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //beef meat animal
    class Beef : MeatAnimal
    {
        /// <summary>
        /// create's a beef
        /// </summary>
        public Beef()
        {
            ProductImage = Properties.Resources.beef;
            MarketPrice = numberGenerator.Next(100000, 200001);
            PurchaseCost = 50000;
            BreedingTime = 8;
            UpkeepCost = 5000;
            MaxLifespan = 12;
            AssignQualityRating();
            CanHarvest = false;
        }
    }
}
