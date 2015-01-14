using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimFarm
{
    class SharedVariables
    {
        public SharedVariables(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;

            _grid = new Product[NumCols, NumRows];

        }
        //grid size - number of rows and columns
        private int _numRows;
        public int NumRows
        {
            get
            {
                return _numRows;
            }
            
            set
            {
                _numRows = value;
            }
        }
        public int _numCols;
        public int NumCols
        {
            get
            {
                return _numCols;
            }
            set
            {
                _numCols = value;
            }
        }
        //stores the amount of money the user has
        private double _money = 100000;
        public double Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }
        //stores the amount of revenue the user makes
        private double _revenue = 0;
        public double Revenue
        {
            get
            {
                return _revenue;
            }
            set
            {
                _revenue = value;
            }
        }
        //stores the grid
        private Product[,] _grid;
        public Product[,] Grid
        {
            get
            {
                return _grid;
            }
            set
            {
                _grid = value;
            }
        }

        //stores the age of the farm
        private int _ageOfFarm = 0;
        public int AgeOfFarm
        {
            get
            {
                return _ageOfFarm;
            }
            set
            {
                _ageOfFarm = value;
            }
        }
        //creates a random number
        Random numberGenerator = new Random();


    }
}
