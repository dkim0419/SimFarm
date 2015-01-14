//daniel kim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    //meat animal class
    abstract class MeatAnimal : Animal
    {
        /// <summary>
        /// stores whether the meat animal has been slaughtered for harvesting or not
        /// </summary>
        protected bool _slaughtered = false;

        /// <summary>
        /// gets the slaughtered value, allows subclasses to set it
        /// </summary>
        public bool Slaughtered
        {
            get
            {
                return _slaughtered;
            }

            protected set
            {
                _slaughtered = value;
            }
        }
    }
}
