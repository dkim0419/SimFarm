/* Daniel Kim
 * May 28, 2014
 * Model to calculate background tasks of the program such as revenue and chance of disasters
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimFarm
{
    class DanielModel
    {
        //shared variables
        private SharedVariables _variables;
        //create new angela model
        private AngelaModel _model;

        /// <summary>
        /// DanielModel constructor
        /// </summary>
        /// <param name="variables">shared variables between the 2 models</param>
        public DanielModel(SharedVariables variables)
        {
            _variables = variables;
            _model = new AngelaModel(variables);
        }

        //number generator
        Random numberGenerator = new Random();

        //store max age of the farm before game over
        const int MAX_AGE = 600;

        //storing the number that accords with each disaster type.
        const int DROUGHT_DISASTER = 0;
        const int FLOOD_DISASTER = 1;
        const int PEST_DISASTER = 2;
        const int TORNADO_DISASTER = 3;
        const int CRAZY_KIDS_DISASTER = 4;

        //store number of months where user has less than $0
        int monthsWithoutMoney = 0;

        /// <summary>
        /// calculates the revenue of the product when harvesting it, then returns it
        /// </summary>
        /// <param name="row">row of the products location on grid</param>
        /// <param name="col">column of product location on grid</param>
        public void CalculateRevenue(int row, int col)
        {
            //store if the product is a bumper crop
            bool isBumperCrop = BumberCrop();

            //calculate revenue of a harvested plant
            if (_variables.Grid[row, col] is Plant)
            {
                //plant's adjacent surrondings are empty land, increase quality by 25% when calculating the revenue
                if (_model.SurroundedByEmptyLand(row, col) == true)
                {
                    //add 15 to the 1.25 * product quality rate, divide by 25, and then multiply by its market price
                    _variables.Revenue = ((15 + _variables.Grid[row, col].QualityRating * 1.25) / 25) * _variables.Grid[row, col].MarketPrice;

                }

                //calculate revenue with normal quality rating
                else
                {
                    //add 15 to the product quality rate, divide by 25, and then multiply by its market price
                    _variables.Revenue = ((15 + _variables.Grid[row, col].QualityRating) / 25) * _variables.Grid[row, col].MarketPrice;
                }

                //randomly selected as a bumper crop
                if (isBumperCrop == true)
                {
                    //multiply revenue by two
                    _variables.Revenue *= 2;
                }
            }

            //product harvested is an animal
            else if (_variables.Grid[row, col] is Animal)
            {
                //surrounded by an identical animal, increase quality by 10%
                if (_model.SurroundedBySameAnimals(row, col) == true)
                {
                    //add 15 to the 1.1 * product quality rate, divide by 25, and then multiply by its market price
                    _variables.Revenue = ((15 + _variables.Grid[row, col].QualityRating * 1.1) / 25) * _variables.Grid[row, col].MarketPrice;
                }

                //calculate revenue with normal quality rating
                else
                {
                    //add 15 to the product quality rate, divide by 25, and then multiply by its market price
                    _variables.Revenue = ((15 + _variables.Grid[row, col].QualityRating) / 25) * _variables.Grid[row, col].MarketPrice;
                }

                //randomly selected as a bumper crop
                if (isBumperCrop == true)
                {
                    //multiply revenue by two
                    _variables.Revenue *= 2;
                }

            }

            //add the revenue to total money
            _variables.Money += _variables.Revenue;
            //revert the current revenue to 0
            _variables.Revenue = 0;
        }

        /// <summary>
        /// subtract upkeep cost of products on grid
        /// </summary>
        public void SubtractUpkeepCost()
        {
            //loop through the grid and subtract product upkeep costs
            for (int row = 0; row < _variables.NumRows; row++)
            {
                for (int col = 0; col < _variables.NumCols; col++)
                {
                    //product exists at location
                    if (_variables.Grid[row, col] != null)
                    {
                        //if plant is a perennial plant, check if it is dead (during waiting period to start regrowth)
                        if (_variables.Grid[row, col] is PerennialPlant)
                        {
                            //cast the product at location to a perennial plant
                            PerennialPlant plant = (PerennialPlant)_variables.Grid[row, col];

                            //the plant is currently growing (not during waiting period), subtract the upkeep cost
                            if (plant.MonthsNotGrowing == -1 )
                            {
                                //subtract the money
                                _variables.Money -= _variables.Grid[row, col].UpkeepCost;
                            }
                        }

                        else
                        {
                            //subtract the money
                            _variables.Money -= _variables.Grid[row, col].UpkeepCost;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// update product info and farm age
        /// </summary>
        public void UpdateGame()
        {
            //loop through all products on grid
            for (int row = 0; row < _variables.NumRows; row++)
            {
                for (int col = 0; col < _variables.NumCols; col++)
                {
                    //there is a product placed at this location
                    if (_variables.Grid[row, col] != null)
                    {
                        //update the product info
                        _variables.Grid[row, col].UpdateMonthly();
                    }
                }
            }

            //increase age of farm by one
            _variables.AgeOfFarm++;
        }

        /// <summary>
        /// random chance of bumber crop when harvesting
        /// </summary>
        /// <param name="numberGenerator">random number generator</param>
        /// <returns>true: yes bumper crop, false: no bumper crop</returns>
        public bool BumberCrop()
        {
            //numberGenerator gives a number between 0 and 1
            int bumberCrop = numberGenerator.Next(0, 2);

            //numberGenerator returns 1, there is a bumber Crop
            if (bumberCrop == 1)
            {
                return true;
            }

            //no bumber crop
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks whether or not game is over/farm is dead
        /// </summary>
        /// <returns>true for dead, false for alive</returns>
        public bool GameIsOver()
        {
            //user has less than or equal to $0, increase the total months count with negative money
            if (_variables.Money <= 0)
            {
                monthsWithoutMoney++;
            }

            //user has more than $0, months without money = 0
            else if (_variables.Money > 0)
            {
                monthsWithoutMoney = 0;
            }

            //farm is 600mths old, it dies
            if (_variables.AgeOfFarm == MAX_AGE)
            {
                return true;
            }

            //no money for 4 months or more, game over
            else if (monthsWithoutMoney >= 4)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// chance of a disaster, harming/destroying the crops
        /// </summary>
        public void Disaster()
        {
            //stores a number between 1 and 20
            int disasterType = numberGenerator.Next(0, 21);

            //Drought, reduce all product qualities by 3
            if (disasterType == DROUGHT_DISASTER)
            {
                //loops through all the products and reduces the quality by 3
                for (int row = 0; row < _variables.NumRows; row++)
                {
                    for (int col = 0; col < _variables.NumCols; col++)
                    {
                        //there is a product at this location on the grid
                        if (_variables.Grid[row, col] != null)
                        {
                            //quality rating subtracted 3 is still greater than or equal to the min quality value
                            if (_variables.Grid[row, col].QualityRating - 3 >= Product.MIN_QUALITY)
                            {
                                _variables.Grid[row, col].QualityRating -= 3;
                            }

                            //quality rating subtract 3 is smaller than the min quality value.
                            //sets the quality rating of the product to the min quality value
                            else
                            {
                                _variables.Grid[row, col].QualityRating = Product.MIN_QUALITY;
                            }
                        }
                    }
                }
            }

            //Flood: destroys all PLANTS in a random 4x4 space on the grid
            else if (disasterType == FLOOD_DISASTER)
            {
                //choose a random row and column on the grid, that is between 0 and the total rows or cols subtract 4
                int randomRow = numberGenerator.Next(0, _variables.NumRows - 3);
                int randomCol = numberGenerator.Next(0, _variables.NumCols - 3);

                //loop through 4 rows starting from the randomly selected row
                for (int row = randomRow; row <= randomRow + 3; row++)
                {
                    //loop through 4 cols starting from randomly selected col
                    for (int col = randomCol; col <= randomCol + 3; col++)
                    {
                        //product is a plant
                        if (_variables.Grid[row, col] is Plant)
                        {
                            //destroy the plant at that location.
                            _variables.Grid[row, col] = null;
                        }
                    }
                }
            }

            //Pest: destroys all PLANTS in a random 2x2 grid
            else if (disasterType == PEST_DISASTER)
            {
                //choose a random row and column on the grid, that is between 0 and the total rows or cols subtract 2
                int randomRow = numberGenerator.Next(0, _variables.NumRows - 1);
                int randomCol = numberGenerator.Next(0, _variables.NumCols - 1);

                //loop through 4 rows starting from the randomly selected row
                for (int row = randomRow; row <= randomRow + 1; row++)
                {
                    //loop through 4 cols starting from randomly selected col
                    for (int col = randomCol; col <= randomCol + 1; col++)
                    {
                        //product is a plant
                        if (_variables.Grid[row, col] is Plant)
                        {
                            //destroy the plant at that location.
                            _variables.Grid[row, col] = null;
                        }
                    }
                }
            }

            //Tornado: destroys a whole row/column at random
            else if (disasterType == TORNADO_DISASTER)
            {
                //choose a random number between 1 and 0
                int number = numberGenerator.Next(0, 2);

                //store random row/column
                int rowOrCol;

                //if number is 0, choose a random row
                if (number == 0)
                {
                    //random row
                    rowOrCol = numberGenerator.Next(0, _variables.NumRows);

                    //loop through each column of the row to destroy the plant
                    for (int col = 0; col < _variables.NumCols; col++)
                    {
                        //kill the product
                        _variables.Grid[rowOrCol, col] = null;
                    }
                }

                //number is 1, choose a random column
                else
                {
                    //random column
                    rowOrCol = numberGenerator.Next(0, _variables.NumCols);

                    //loop through each row of the column to destroy the plant
                    for (int row = 0; row < _variables.NumRows; row++)
                    {
                        _variables.Grid[row, rowOrCol] = null;
                    }
                }
            }

            //Crazy Kid: destroy a random single acre.
            else if (disasterType == CRAZY_KIDS_DISASTER)
            {
                //choose a random row and column
                int randomRow = numberGenerator.Next(0, _variables.NumRows);
                int randomCol = numberGenerator.Next(0, _variables.NumCols);

                //kill the product at that location
                _variables.Grid[randomRow, randomCol] = null;
            }
        }

        /// <summary>
        /// harvest a crop for sale
        /// </summary>
        /// <param name="col">column of product on grid</param>
        /// <returns>true: available, false: unavailable</returns>
        public void HarvestCrop(int row, int col)
        {
            //add crop's revenue to total revenue of the month   
            CalculateRevenue(row, col);

            //perennial plant: dont remove the plant, start the waiting period
            if (_variables.Grid[row, col] is PerennialPlant)
            {
                //cant harvest plant any longer
                _variables.Grid[row, col].CanHarvest = false;

                //set the growing period to its max lifespan, to simulate death and commence regrowth period.
                _variables.Grid[row, col].MonthsGrowing = _variables.Grid[row, col].MaxLifespan;

                //call to update the product info
                ProductDies(row, col);
            }

            //dairy and egg animal, start re-growing again.
            else if (_variables.Grid[row, col] is DairyAndEggAnimal)
            {
                //cant harvest animal any longer
                _variables.Grid[row, col].CanHarvest = false;

                _variables.Grid[row, col].MonthsGrowing = _variables.Grid[row, col].MaxLifespan;
                ProductDies(row, col);
            }

            //remove the product from _grid
            else
            {
                _variables.Grid[row, col] = null;
            }
        }

        /// <summary>
        /// check if a product is available for harvest
        /// </summary>
        /// <param name="row">row of product on grid</param>
        /// <param name="col">column of product on grid</param>
        /// <returns>true: available, false: unavailable</returns>
        public bool CheckForHarvest(int row, int col)
        {
            //the months that the product has been growing for is greater than or equal to its breeding time, and less than max lifespan
            if (_variables.Grid[row, col].MonthsGrowing >= _variables.Grid[row, col].BreedingTime && _variables.Grid[row, col].MonthsGrowing < _variables.Grid[row, col].MaxLifespan)
            {
                //product is harvestable
                return true;
            }

            //product cannot be harvested
            return false;
        }

        /// <summary>
        /// check whether product is past its lifespan to die
        /// </summary>
        /// <param name="row">row of product location</param>
        /// <param name="col">column of location</param>
        public void ProductDies(int row, int col)
        {
            //product is past its max lifespan
            if (_variables.Grid[row, col].MonthsGrowing >= _variables.Grid[row, col].MaxLifespan)
            {
                //perennial plant: dont remove the plant, start the waiting period
                if (_variables.Grid[row, col] is PerennialPlant)
                {
                    _variables.Grid[row, col].UpdateMonthly();
                }

                //dairy and egg animal, does not die when harvested, but keeps on growing
                else if (_variables.Grid[row, col] is DairyAndEggAnimal)
                {
                    //reset months growing to 0, will start growing again automatically
                    _variables.Grid[row, col].MonthsGrowing = 0;
                }

                //remove product from grid
                else
                {
                    _variables.Grid[row, col] = null;
                }
            }
        }
    }
}
