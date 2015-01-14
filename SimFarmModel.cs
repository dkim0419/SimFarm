using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimFarm
{
    class SimFarmModel
    {
        //stores DanielModel
        DanielModel model1;
        //stores AngelaModel
        AngelaModel model2;
        //stores Shared Variables
        SharedVariables variables;

        /// <summary>
        /// SimFarmModel Constructor
        /// </summary>
        /// <param name="rows">num of rows</param>
        /// <param name="cols">num of cols</param>
        public SimFarmModel(int rows, int cols)
        {
            variables = new SharedVariables(rows, cols);
            model1 = new DanielModel(variables);
            model2 = new AngelaModel(variables);
        }

        /// <summary>
        /// get the age of the farm
        /// </summary>
        public int AgeOfFarm
        {
            get
            {
                return variables.AgeOfFarm;
            }
        }

        /// <summary>
        /// get money of the farm
        /// </summary>
        public double GetMoney
        {
            get
            {
                return variables.Money;
            }
        }

        /// <summary>
        /// updates the game
        /// </summary>
        public void UpdateGame()
        {
            model1.UpdateGame();
        }

        /// <summary>
        /// subtract upkeep cost of products
        /// </summary>
        public void SubtractUpkeepCost()
        {
            model1.SubtractUpkeepCost();
        }

        /// <summary>
        /// checks whether location piece is being placed at is empty
        /// </summary>
        /// <param name="row">row piece is being placed at</param>
        /// <param name="col">col piece is being placed at</param>
        /// <returns>whether the square is empty</returns>
        public bool EmptySquare(int row, int col)
        {
            return model2.EmptySquare(row, col);
        }

        /// <summary>
        /// builds a new corn
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildCorn(int row, int col)
        {
            return model2.BuildCorn(row, col);
        }

        /// <summary>
        /// builds a new tomato
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildTomato(int row, int col)
        {
            return model2.BuildTomato(row, col);
        }

        /// <summary>
        /// builds a new potato
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildPotato(int row, int col)
        {
            return model2.BuildPotato(row, col);
        }

        /// <summary>
        /// builds a new sweet potato
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildSweetPotato(int row, int col)
        {
            return model2.BuildSweetPotato(row, col);
        }

        /// <summary>
        /// builds a new broccoli
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildBroccoli(int row, int col)
        {
            return model2.BuildBroccoli(row, col);
        }

        /// <summary>
        /// builds a new asparagus
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildAsparagus(int row, int col)
        {
            return model2.BuildAsparagus(row, col);
        }

        /// <summary>
        /// builds a new pork
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildPork(int row, int col)
        {
            return model2.BuildPork(row, col);
        }

        /// <summary>
        /// builds a new beef
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildBeef(int row, int col)
        {
            return model2.BuildBeef(row, col);
        }

        /// <summary>
        /// builds a new chicken
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildChicken(int row, int col)
        {
            return model2.BuildChicken(row, col);
        }

        /// <summary>
        /// builds a new cow
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildCow(int row, int col)
        {
            return model2.BuildCow(row, col);
        }

        /// <summary>
        /// builds a new hen
        /// </summary>
        /// <param name="col">row being placed at</param>
        /// <param name="row">col being is placed at</param>
        /// <returns>whether it was placed</returns>
        public bool BuildHen(int row, int col)
        {
            return model2.BuildHen(row, col);
        }

        /// <summary>
        /// checks if game is over
        /// </summary>
        /// <returns>whether game is over</returns>
        public bool GameIsOver()
        {
            return model1.GameIsOver();
        }

        /// <summary>
        /// checks for disasters
        /// </summary>
        public void Disaster()
        {
            model1.Disaster();
        }

        /// <summary>
        /// harvests the crop
        /// </summary>
        /// <param name="row">row crop is at</param>
        /// <param name="col">col crop is at</param>
        public void HarvestCrop(int row, int col)
        {
            model1.HarvestCrop(row, col);
        }

        /// <summary>
        /// checks if crop can be harvested
        /// </summary>
        /// <param name="row">row crop is at</param>
        /// <param name="col">col crop is at</param>
        /// <returns>whether crop can be harvested</returns>
        public bool CheckForHarvest(int row, int col)
        {
            return model1.CheckForHarvest(row, col);
        }

        /// <summary>
        /// kills off the product
        /// </summary>
        /// <param name="row">row product is in</param>
        /// <param name="col">col product is in</param>
        public void ProductDies(int row, int col)
        {
            model1.ProductDies(row, col);
        }

        //get the grid of thee products
        public Product[,] Grid
        {
            get
            {
                return variables.Grid;
            }
        }
    }
}
