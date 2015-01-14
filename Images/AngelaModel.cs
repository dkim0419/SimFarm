/*Angela Xu and Daniel Kim
 * May 15 2014
 * SimFarm allows the user to build products, harvest them and earn money*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    class AngelaModel
    {
        //stores the sharaedvariables
        SharedVariables _variables;

        //gets the shared variables as paramater
        public AngelaModel(SharedVariables variables)
        {
            _variables = variables;
        }

        /// <summary>
        /// checks if the plant is being placed beside animals
        /// if it is, it cannot be placed there
        /// </summary>
        /// <param name="col">col the piece is being placed at</param>
        /// <param name="row">row the piece is being placed at</param>
        /// <returns>returns if the plant is placed</returns>
        public bool PlacePlant(int row, int col)
        {
            //if product is being placed in top left corner it will check surrounding
            if (row == 0 && col == 0)
            {
                if (_variables.Grid[row, col + 1] is Animal || _variables.Grid[row + 1, col] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in bottom left corner it will check surrounding
            else if (row == 0 && col == _variables.NumCols - 1)
            {
                if (_variables.Grid[row, col - 1] is Animal || _variables.Grid[row + 1, col] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in top right corner it will check surrounding
            else if (row == _variables.NumRows - 1 && col == 0)
            {
                if (_variables.Grid[row - 1, col] is Animal || _variables.Grid[row, col + 1] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in bottom right corner it will check surrounding
            else if (row == _variables.NumRows - 1 && col == _variables.NumCols - 1)
            {
                if (_variables.Grid[row, col - 1] is Animal || _variables.Grid[row - 1, col] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in top row it will check surrounding
            else if (row == 0)
            {
                if (_variables.Grid[row, col + 1] is Animal || _variables.Grid[row + 1, col] is Animal || _variables.Grid[row, col - 1] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in bottom row it will check surrounding
            else if (row == _variables.NumRows - 1)
            {
                if (_variables.Grid[row, col + 1] is Animal || _variables.Grid[row - 1, col] is Animal || _variables.Grid[row, col - 1] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in top col it will check surrounding
            else if (col == 0)
            {
                if (_variables.Grid[row, col + 1] is Animal || _variables.Grid[row + 1, col] is Animal || _variables.Grid[row - 1, col] is Animal)
                {
                    return false;
                }
            }

            //if product is being placed in last col it will check surrounding
            else if (col == _variables.NumCols - 1)
            {
                if (_variables.Grid[row, col - 1] is Animal || _variables.Grid[row + 1, col] is Animal || _variables.Grid[row - 1, col] is Animal)
                {
                    return false;
                }
            }

            //if animal is surrounded by plants, it will return false meaning the animal cannot be built there
            else
            {
                if (_variables.Grid[row + 1, col] is Animal || _variables.Grid[row, col + 1] is Animal || _variables.Grid[row - 1, col] is Animal || _variables.Grid[row, col - 1] is Animal)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// checks is animal is surrounded by the same animal
        /// if it is, it will earn 10% quality bonus
        /// </summary>
        /// <param name="row">row the animal is at</param>
        /// <param name="col">col the animal is at</param>
        /// <returns>whether or not it will receive a 10% quality bonus</returns>
        public bool SurroundedBySameAnimals(int row, int col)
        {
            //animal in top left corner
            if (row == 0 && col == 0)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in bottom left corner
            else if (row == 0 && col == _variables.NumCols - 1)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in top right corner
            else if (row == _variables.NumRows - 1 && col == 0)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in bottom right corner
            else if (row == _variables.NumRows - 1 && col == _variables.NumCols - 1)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in top row
            else if (row == 0)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in bottom row
            else if (row == _variables.NumRows - 1)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in first column
            else if (col == 0)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //animal in last column
            else if (col == _variables.NumCols - 1)
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //else animal is not at edge of grid
            else 
            {
                //if animal is surrounded by same animal, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row + 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage || _variables.Grid[row, col - 1].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }
            return false;            
        }

        /// <summary>
        /// checks is plant is surrounded by empty land
        /// if it is, it will earn 25% quality bonus
        /// </summary>
        /// <param name="row">row plant is at</param>
        /// <param name="col">col plant is at</param>
        /// <returns>whether or not it will receive a 25% quality bonus</returns>
        public bool SurroundedByEmptyLand(int row, int col)
        {
            //plant is in top left corner
            if (row == 0 && col == 0)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1] == null && _variables.Grid[row + 1, col] == null)
                {
                    return true;
                }
            }

            //plant is in top right corner
            else if (row == 0 && col == _variables.NumCols - 1)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1] == null && _variables.Grid[row + 1, col] == null)
                {
                    return true;
                }
            }

            //if plant is in botton left corner
            else if (row == _variables.NumRows - 1 && col == 0)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row - 1, col].ProductImage == _variables.Grid[row, col].ProductImage && _variables.Grid[row, col + 1].ProductImage == _variables.Grid[row, col].ProductImage)
                {
                    return true;
                }
            }

            //plant is in bottom right corner
            else if (row == _variables.NumRows - 1 && col == _variables.NumCols - 1)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1] == null || _variables.Grid[row - 1, col] == null)
                {
                    return true;
                }
            }

            //plant is in top row
            else if (row == 0)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1] == null && _variables.Grid[row + 1, col] == null && _variables.Grid[row, col - 1] == null)
                {
                    return true;
                }
            }

            //plant is in bottom row
            else if (row == _variables.NumRows - 1)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1] == null && _variables.Grid[row - 1, col] == null && _variables.Grid[row, col - 1] == null)
                {
                    return true;
                }
            }

            //plant is in first col
            else if (col == 0)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col + 1] == null && _variables.Grid[row + 1, col] == null && _variables.Grid[row - 1, col] == null)
                {
                    return true;
                }
            }

            //plant is in bottom col
            else if (col == _variables.NumCols - 1)
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row, col - 1] == null && _variables.Grid[row + 1, col] == null && _variables.Grid[row - 1, col] == null)
                {
                    return true;
                }
            }

            //plant is not at edge of grid
            else
            {
                //if plant is surrounded by empty land, it will return true meaining it will get a quality bonus
                if (_variables.Grid[row + 1, col] == null && _variables.Grid[row, col + 1] == null && _variables.Grid[row, col - 1] == null && _variables.Grid[row - 1, col] == null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// checks if the animal is being placed beside a plant
        /// if it is, it will not be placed
        /// </summary>
        /// <param name="row">row animal is being placed at</param>
        /// <param name="col">col animal is being placed at</param>
        /// <returns>returns if the animal is placed</returns>
        public bool PlaceAnimal(int row, int col)
        {
            //animal is in top left corner
            if (row == 0 && col == 0)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col + 1] is Plant || _variables.Grid[row + 1, col] is Plant)
                {
                    return false;
                }
            }

            //animal is in top right corner
            else if (row == 0 && col == _variables.NumCols - 1)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col - 1] is Plant || _variables.Grid[row + 1, col] is Plant)
                {
                    return false;
                }
            }

            //animal is in bottom left corner
            else if (row == _variables.NumRows - 1 && col == 0)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row - 1, col] is Plant || _variables.Grid[row, col + 1] is Plant)
                {
                    return false;
                }
            }

            //animal is in bottom right corner
            else if (row == _variables.NumRows - 1 && col == _variables.NumCols - 1)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col - 1] is Plant || _variables.Grid[row - 1, col] is Plant)
                {
                    return false;
                }
            }

            //animal is in the first row
            else if (row == 0)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col + 1] is Plant || _variables.Grid[row + 1, col] is Plant || _variables.Grid[row, col - 1] is Plant)
                {
                    return false;
                }
            }

            //animal is in the last row
            else if (row == _variables.NumRows - 1)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col + 1] is Plant || _variables.Grid[row - 1, col] is Plant || _variables.Grid[row, col - 1] is Plant)
                {
                    return false;
                }
            }

            //animal is in the first col
            else if (col == 0)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col + 1] is Plant || _variables.Grid[row + 1, col] is Plant || _variables.Grid[row - 1, col] is Plant)
                {
                    return false;
                }
            }

            //animal is in the last col
            else if (col == _variables.NumCols - 1)
            {
                //if animal being placed is surrounded by plant, it will return false meaining it will not be placed
                if (_variables.Grid[row, col - 1] is Plant || _variables.Grid[row + 1, col] is Plant || _variables.Grid[row - 1, col] is Plant)
                {
                    return false;
                }
            }

            //animal is not at the edge of the grid
            else
            {
                //if animal is surrounded by plants, it will return false meaning the animal cannot be built there
                if (_variables.Grid[row, col + 1] is Plant || _variables.Grid[row + 1, col] is Plant || _variables.Grid[row - 1, col] is Plant || _variables.Grid[row, col - 1] is Plant)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// creates a new corn
        /// </summary>
        /// <param name="row">row that corn is built at</param>
        /// <param name="col">col that corn is built at</param>
        /// <returns>whether corn was built</returns>
        public bool BuildCorn(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new corn at that grid location
                _variables.Grid[row, col] = new Corn();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new tomato
        /// </summary>
        /// <param name="row">row tomato is built at</param>
        /// <param name="col">col tomato is built at</param>
        /// <returns>whether tomato was built</returns>
        public bool BuildTomato(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new tomato at that grid location
                _variables.Grid[row, col] = new Tomato();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new asparagus
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildAsparagus(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new asparagus at that grid location
                _variables.Grid[row, col] = new Asparagus();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new broccoli
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildBroccoli(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new broccoli at that grid location
                _variables.Grid[row, col] = new Broccoli();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new potato
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildPotato(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new potato at that grid location
                _variables.Grid[row, col] = new Potato();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new sweet potato
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildSweetPotato(int row, int col)
        {
            //stores whether plant can be placed
            bool placePlant = PlacePlant(row, col);

            //checks is plance plant is true
            if (placePlant == true)
            {
                //creates a new sweet potato at that grid location
                _variables.Grid[row, col] = new SweetPotato();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new pork
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildPork(int row, int col)
        {
            //stores whether animal can be placed
            bool placeAnimal = PlaceAnimal(row, col);

            //checks is plance animal is true
            if (placeAnimal == true)
            {
                //creates a new pork at that grid location
                _variables.Grid[row, col] = new Pork();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new chicken
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildChicken(int row, int col)
        {
            //stores whether animal can be placed
            bool placeAnimal = PlaceAnimal(row, col);

            //checks is plance animal is true
            if (placeAnimal == true)
            {
                //creates a new chicken at that grid location
                _variables.Grid[row, col] = new Chicken();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new beef
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildBeef(int row, int col)
        {
            //stores whether animal can be placed
            bool placeAnimal = PlaceAnimal(row, col);

            //checks is plance animal is true
            if (placeAnimal == true)
            {
                //creates a new beef at that grid location
                _variables.Grid[row, col] = new Beef();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new hen
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildHen(int row, int col)
        {
            //stores whether animal can be placed
            bool placeAnimal = PlaceAnimal(row, col);

            //checks is plance animal is true
            if (placeAnimal == true)
            {
                //creates a new hen at that grid location
                _variables.Grid[row, col] = new Hen();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// build a new cow
        /// </summary>
        /// <param name="row">row being built at</param>
        /// <param name="col">col being built at</param>
        /// <returns>whether it was built</returns>
        public bool BuildCow(int row, int col)
        {
            //stores whether animal can be placed
            bool placeAnimal = PlaceAnimal(row, col);

            //checks is plance animal is true
            if (placeAnimal == true)
            {
                //creates a new cow at that grid location
                _variables.Grid[row, col] = new Cow();
                //subtracts the purchase cost of the product
                _variables.Money -= _variables.Grid[row, col].PurchaseCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks if square is empty
        /// </summary>
        /// <param name="row">row square is at</param>
        /// <param name="col">col square is at</param>
        /// <returns>whether square is empty</returns>
        public bool EmptySquare(int row, int col)
        {
            //check if grid at the row and col is empty and returns false
            if (_variables.Grid[row, col] != null)
            {
                return false;
            }

            return true;
        }

    }
}
