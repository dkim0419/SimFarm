/* Daniel Kim
 * May 20, 2014
 * Product class: Parent class of all products
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimFarm
{
    /// <summary>
    /// Parent class for all products
    /// </summary>
    abstract class Product
    {
        //min quality rating of all products
        public const int MIN_QUALITY = 1;

        /// <summary>
        /// store whether or not product is available to harvest
        /// </summary>
        protected bool _canHarvest;
        /// <summary>
        /// get the bool of can harvest, allow program to set it
        /// </summary>
        public bool CanHarvest
        {
            get
            {
                return _canHarvest;
            }

            set
            {
                _canHarvest = value;
            }
        }

        /// <summary>
        /// store the product's image
        /// </summary>
        protected Image _productImage;
        /// <summary>
        /// get the product's image. subclasses are allowed to set it
        /// </summary>
        public Image ProductImage
        {
            get
            {
                return _productImage;
            }

            protected set
            {
                _productImage = value;
            }
        }

        /// <summary>
        /// store the purchase cost of the product
        /// </summary>
        protected int _purchaseCost;
        /// <summary>
        /// Get the product's purchase cost. allows subclasses to set it
        /// </summary>
        public int PurchaseCost
        {
            get
            {
                return _purchaseCost;
            }

            protected set
            {
                _purchaseCost = value;
            }
        }

        /// <summary>
        /// store the breeding time of the product
        /// </summary>
        protected int _breedingTime;
        /// <summary>
        /// get the product's breeding time. allows subclasses to set it
        /// </summary>
        public int BreedingTime
        {
            get
            {
                return _breedingTime;
            }

            protected set
            {
                _breedingTime = value;
            }
        }

        /// <summary>
        /// store the market price of the product
        /// </summary>
        protected int _marketPrice;
        /// <summary>
        /// get the market price of the product. allows subclasses to set it
        /// </summary>
        public int MarketPrice
        {
            get
            {
                return _marketPrice;
            }

            protected set
            {
                _marketPrice = value;
            }
        }

        /// <summary>
        /// store the upkeep cost of the product
        /// </summary>
        protected int _upkeepCost;
        /// <summary>
        /// get the upkeep cost of the product. allows subclasses to set it
        /// </summary>
        public int UpkeepCost
        {
            get
            {
                return _upkeepCost;
            }

            protected set
            {
                _upkeepCost = value;
            }
        }
        /// <summary>
        /// store the quality rating of the product
        /// </summary>
        protected double _qualityRating;
        /// <summary>
        /// get the quality rating of the product, allows program to set it
        /// </summary>
        public double QualityRating
        {
            get
            {
                return _qualityRating;
            }

            set
            {
                _qualityRating = value;
            }
        }

        /// <summary>
        /// store the months alive of the product
        /// </summary>
        protected int _monthsGrowing;
        /// <summary>
        /// get the months alive of the product. allows subclasses to set it
        /// </summary>
        public int MonthsGrowing
        {
            get
            {
                return _monthsGrowing;
            }

            set
            {
                _monthsGrowing = value;
            }
        }

        /// <summary>
        /// store the max lifespan of the product
        /// </summary>
        protected int _maxLifespan;
        /// <summary>
        /// get the max lifespan of the product, allows subclasses to set it
        /// </summary>
        public int MaxLifespan
        {
            get
            {
                return _maxLifespan;
            }

            protected set
            {
                _maxLifespan = value;
            }
        }

        /// <summary>
        /// Random number generator used for generating quality rating and market price
        /// It is static, so only 1 variable is created for ALL instances of Animal
        /// </summary>
        protected static Random numberGenerator = new Random();

        /// <summary>
        /// adds one month to total months growing
        /// </summary>
        public virtual void UpdateMonthly()
        {
            this.MonthsGrowing++;
        }

        /// <summary>
        /// assigns random quality rating to each product
        /// </summary>
        public void AssignQualityRating()
        {
            this.QualityRating = numberGenerator.Next(1, 11);
        }
    }
}
