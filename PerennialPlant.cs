//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    abstract class PerennialPlant : Plant
    {
        /// <summary>
        /// store the waiting period of the plant, before it can start growing again
        /// </summary>
        protected int _waitingPeriod;

        /// <summary>
        /// get the waiting period of the product, before it can grow again. allow subclasses to set it
        /// </summary>
        public int WaitingPeriod
        {
            get
            {
                return _waitingPeriod;
            }

            protected set
            {
                _waitingPeriod = value;
            }
        }

        /// <summary>
        /// stores the total months the plant hasn't been growing for (during the waiting period after harvesting)
        /// </summary>
        protected int _monthsNotGrowing;

        /// <summary>
        /// get and allow subclassses to set the months the plant wasnt growing
        /// </summary>
        public int MonthsNotGrowing
        {
            get
            {
                return _monthsNotGrowing;
            }

            protected set
            {
                _monthsNotGrowing = value;
            }
        }

        /// <summary>
        /// update the plants info monthly
        /// </summary>
        public override void UpdateMonthly()
        {
            //the product reached the lifespan, commence waiting period before regrowth 
            if (this.MonthsGrowing == this.MaxLifespan)
            {
                //if plant has not been growing for more than its waiting before before regrowth, reset the growing and not growing months values back to 0, to commence regrowth
                if (this.MonthsNotGrowing >= this.WaitingPeriod)
                {
                    this.MonthsNotGrowing = -2;
                    this.MonthsGrowing = -1;
                }

                //increase months not growing by 1
                this.MonthsNotGrowing++;
            }
            //plant still growing, increase its months growing by 1
            else
            {
                this.MonthsGrowing++;
            }
        }
        
    }
}
