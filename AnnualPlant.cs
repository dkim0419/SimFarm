//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    /// <summary>
    /// Annual Plant class, parent class of Corn and Tomato
    /// Annual Plant is a child class of Product
    /// </summary>
    abstract class AnnualPlant : Plant
    {
        /// <summary>
        /// increase the annual plant's age 
        /// </summary>
        public void UpdateAge()
        {
            MonthsGrowing++;
        }
    }
}
