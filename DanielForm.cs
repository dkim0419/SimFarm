/* Daniel Kim
 * May 28, 2014
 * Sim Farm Form to display graphics of the program. 
 * Game about a farming simulation
 */
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
    public partial class DanielForm : Form
    {
        //grid size - num of rows/columns
        public const int NUM_ROWS = 10;
        public const int NUM_COLS = 10;

        SimFarmModel model = new SimFarmModel(NUM_ROWS, NUM_COLS);

        //stores whether or not the product is being placed beside another animal or a plant
        bool isPlacedBeside = false;

        //image index of product image that user clicks on
        int[,] imageClickedIndex = new int[NUM_ROWS, NUM_COLS];

        //number of products
        const int NUMBER_OF_PRODUCTS = 11;

        //Store imgs in array for simpler drawing and selection
        Image[] productImage = new Image[NUMBER_OF_PRODUCTS];

        //store whether the product has been clicked on to plant/grow
        bool[] imageClickState = new bool[NUMBER_OF_PRODUCTS];

        //store the (x,y) location of the mouse when it is being dragged
        Point imageDraggedCoordinate;

        //store the (x,y) location of the mouse when it is being dropped
        Point imageDroppedCoordinate;

        //store image size and location
        Rectangle[] imageBoundingBox = new Rectangle[NUMBER_OF_PRODUCTS];
        Point[] imageXY = new Point[NUMBER_OF_PRODUCTS];

        //form dimensions
        const int FORM_WIDTH = 600;
        const int FORM_HEIGHT = 600;

        //dimensions of each grid block
        int columnWidth;
        int rowHeight;

        //mouse location offset
        const int X_OFFSET = -30;
        int Y_OFFSET = -30;

        //store grid that's drawn on screen
        Rectangle[,] _grid;

        //image indexes of all products
        const int IMAGE_INDEX_CORN = 0;
        const int IMAGE_INDEX_TOMATO = 1;
        const int IMAGE_INDEX_ASPARAGUS = 2;
        const int IMAGE_INDEX_BROCCOLI = 3;
        const int IMAGE_INDEX_POTATO = 4;
        const int IMAGE_INDEX_SWEET_POTATO = 5;
        const int IMAGE_INDEX_BEEF = 6;
        const int IMAGE_INDEX_CHICKEN = 7;
        const int IMAGE_INDEX_PORK = 8;
        const int IMAGE_INDEX_HEN = 9;
        const int IMAGE_INDEX_COW = 10;

        //ensure all img drawn to same size
        const int STANDARD_IMAGE_WIDTH = 60;
        const int STANDARD_IMAGE_HEIGHT = 60;
        Size imageSize;

        public DanielForm()
        {
            InitializeComponent();
            InitializeGameBoard();
            InitializeImages();

            //update money label
            lblMoney.Text = "Money: $" + model.GetMoney;
            //update age label
            lblAge.Text = "Farm Age: " + model.AgeOfFarm + "months";
        }

        //assign images
        private void InitializeImages()
        {
            //standard image size
            imageSize = new Size(STANDARD_IMAGE_WIDTH, STANDARD_IMAGE_HEIGHT);

            // assign images to each productImage array
            productImage[IMAGE_INDEX_CORN] = Properties.Resources.corn;
            productImage[IMAGE_INDEX_TOMATO] = Properties.Resources.tomato;
            productImage[IMAGE_INDEX_ASPARAGUS] = Properties.Resources.asparagus;
            productImage[IMAGE_INDEX_BROCCOLI] = Properties.Resources.broccoli;
            productImage[IMAGE_INDEX_POTATO] = Properties.Resources.potato;
            productImage[IMAGE_INDEX_SWEET_POTATO] = Properties.Resources.sweet_potato;
            productImage[IMAGE_INDEX_BEEF] = Properties.Resources.beef;
            productImage[IMAGE_INDEX_CHICKEN] = Properties.Resources.chicken;
            productImage[IMAGE_INDEX_PORK] = Properties.Resources.pork;
            productImage[IMAGE_INDEX_HEN] = Properties.Resources.hen;
            productImage[IMAGE_INDEX_COW] = Properties.Resources.cow;

            //loop through every image and assign a location
            for (int i = 0; i < productImage.Length; i++)
            {
                //create location for current image
                imageXY[i] = new Point(this.Width + 100, i * STANDARD_IMAGE_WIDTH);
                //create bounding box for current image
                imageBoundingBox[i] = new Rectangle(imageXY[i], imageSize);
                //image has not been clicked yet
                imageClickState[i] = false;
            }
        }

        //initalize the game grid
        void InitializeGameBoard()
        {
            //form dimensions
            Height = FORM_HEIGHT;
            Width = FORM_WIDTH;

            //width and height of each grid square
            columnWidth = FORM_WIDTH / NUM_ROWS;
            rowHeight = FORM_HEIGHT / NUM_COLS;

            //Create graphical grid
            _grid = new Rectangle[NUM_ROWS, NUM_COLS];

            //create each rectangle of the grid
            //loop through each row and column
            for (int rows = 0; rows < NUM_ROWS; rows++)
            {
                for (int cols = 0; cols < NUM_COLS; cols++)
                {
                    //create new rectangle
                    _grid[rows, cols] = new Rectangle(cols * columnWidth, rows * rowHeight, columnWidth, rowHeight);
                }
            }
        }

        //paint the board onto the form
        private void SimFarmForm_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle at each row and column through the loop
            for (int rows = 0; rows < NUM_ROWS; rows++)
            {
                for (int cols = 0; cols < NUM_COLS; cols++)
                {
                    //fill in a green rectangle
                    e.Graphics.FillRectangle(Brushes.Green, _grid[rows, cols]);
                    //outline rectangle with white
                    e.Graphics.DrawRectangle(Pens.White, _grid[rows, cols]);
                }
            }

            //loops through the productImage array to draw every product
            for (int i = 0; i < NUMBER_OF_PRODUCTS; i++)
            {
                e.Graphics.DrawImage(productImage[i], imageBoundingBox[i]);

                //image clicked to be planted
                if (imageClickState[i] == true)
                {
                    //form a  new image bounding for the product
                    Rectangle imageBounding = new Rectangle(imageDraggedCoordinate, imageSize);
                    //draw the product image that is being dragged currently so it follows the mouse movements
                    e.Graphics.DrawImage(productImage[i], imageBounding);
                }
            }

            //re-draw all the currently placed products on the grid at every refresh
            for (int row = 0; row < NUM_ROWS; row++)
            {
                for (int col = 0; col < NUM_COLS; col++)
                {
                    if (model.Grid[row, col] != null)
                    {
                        //draw the image onto grid
                        e.Graphics.DrawImage(model.Grid[row, col].ProductImage, _grid[row, col]);

                        //the product is harvestable
                        if (model.Grid[row, col].CanHarvest == true)
                        {
                            //indicate user with an ellipse on grid of product
                            e.Graphics.DrawEllipse(Pens.Yellow, _grid[row, col]);
                        }

                        //product at location is a perennial plant, check if it is growing or not
                        else if (model.Grid[row, col] is PerennialPlant)
                        {
                            //cast product to a new perennial plant
                            PerennialPlant plant = (PerennialPlant)model.Grid[row, col];

                            //product is currently not growing (during waiting period), draw an orange ellipse indicator
                            if (plant.MonthsNotGrowing >= 0)
                            {
                                e.Graphics.FillEllipse(Brushes.Orange, _grid[row, col]);
                            }
                        }
                    }
                }
            }
        }

        //every tick = 1 month has passed by on the farm
        //update the farm age
        private void tmrFarmAge_Tick(object sender, EventArgs e)
        {
            //chance of disaster every month
            model.Disaster();

            //loop through all the products on the grid
            for (int row = 0; row < NUM_ROWS; row++)
            {
                for (int col = 0; col < NUM_COLS; col++)
                {
                    //product exists at location
                    if (model.Grid[row, col] != null)
                    {
                        //check if product is available for harvest
                        model.Grid[row, col].CanHarvest = model.CheckForHarvest(row, col);

                        //check if product has reached its lifespan and will die
                        model.ProductDies(row, col);
                    }
                }
            }

            //update all product info
            model.UpdateGame();

            //subtract upkeep cost of all products
            model.SubtractUpkeepCost();


            //update money label
            lblMoney.Text = "Money: $" + model.GetMoney;
            //update age label
            lblAge.Text = "Farm Age: " + model.AgeOfFarm + "months";

            //game is over, disable timers and show message box
            if (model.GameIsOver() == true)
            {
                tmrUpdate.Enabled = false;
                tmrFarmAge.Enabled = false;

                MessageBox.Show("Game Over!");
            }
        }

        //update the simfarm form graphics
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        //user clicks down on the mouse
        private void SimFarmForm_MouseDown(object sender, MouseEventArgs e)
        {
            //loop through images to get the image clicked state of every image
            for (int i = 0; i < productImage.Length; i++)
            {
                imageClickState[i] = imageBoundingBox[i].Contains(e.Location);
            }
        }

        //user clicks up on the mouse
        private void SimFarmForm_MouseUp(object sender, MouseEventArgs e)
        {
            //loop through all the images
            for (int i = 0; i < productImage.Length; i++)
            {
                //image has been clicked
                if (imageClickState[i] == true)
                {
                    //place the image on the grid
                    imageDroppedCoordinate = e.Location;

                    //loop through all the grid spaces to see where the user clicks
                    for (int row = 0; row < NUM_ROWS; row++)
                    {
                        for (int col = 0; col < NUM_COLS; col++)
                        {
                            //checks if current rectangle is the one clicked
                            if (_grid[row, col].Contains(imageDroppedCoordinate))
                            {
                                //the current square is empty, no product is already using the spot
                                if (model.EmptySquare(row, col) == true)
                                {
                                    //index of the image that has been clicked on to plant
                                    imageClickedIndex[row, col] = i;

                                    //build a corn
                                    if (imageClickedIndex[row, col] == IMAGE_INDEX_CORN)
                                    {
                                        isPlacedBeside = model.BuildCorn(row, col);
                                    }

                                    //build a tomato
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_TOMATO)
                                    {
                                        isPlacedBeside = model.BuildTomato(row, col);
                                    }
                                    //build a asparagus
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_ASPARAGUS)
                                    {
                                        isPlacedBeside = model.BuildAsparagus(row, col);
                                    }
                                    //build a broccoli
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_BROCCOLI)
                                    {
                                        isPlacedBeside = model.BuildBroccoli(row, col);
                                    }
                                    //build a potato
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_POTATO)
                                    {
                                        isPlacedBeside = model.BuildPotato(row, col);
                                    }
                                    //build a sweet potato
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_SWEET_POTATO)
                                    {
                                        isPlacedBeside = model.BuildSweetPotato(row, col);
                                    }
                                    //build a pork
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_PORK)
                                    {
                                        isPlacedBeside = model.BuildPork(row, col);
                                    }
                                    //build a chicken
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_CHICKEN)
                                    {
                                        isPlacedBeside = model.BuildChicken(row, col);
                                    }
                                    //build a beef
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_BEEF)
                                    {
                                        isPlacedBeside = model.BuildBeef(row, col);
                                    }
                                    //build a hen
                                    else if (imageClickedIndex[row, col] == IMAGE_INDEX_HEN)
                                    {
                                        isPlacedBeside = model.BuildHen(row, col);
                                    }
                                    //build a cow
                                    else
                                    {
                                        isPlacedBeside = model.BuildCow(row, col);
                                    }

                                    //product is allowed to be placed at the specific co-ordinate
                                    if (isPlacedBeside == true)
                                    {
                                        lblMoney.Text = "Money: $" + model.GetMoney;

                                        isPlacedBeside = false;
                                    }

                                    //show error cannot place product due to plants and animals not being able to be beside eachother
                                    else
                                    {
                                        isPlacedBeside = false;
                                        MessageBox.Show("Plants and Animals cannot be placed adjacent to eachother.");
                                    }
                                }

                                //show error that you cannot have 2 products on the same location
                                else
                                {
                                    //product is no longer being placed
                                    MessageBox.Show("Cannot place two products on the same grid! Please choose a different area.");
                                }

                                //image is no longer clicked once mouse is released
                                imageClickState[i] = false;
                            }
                        }
                    }
                }
            }
        }

        //user moves the mouse around
        private void SimFarmForm_MouseMove(object sender, MouseEventArgs e)
        {
            //location of the mouse
            imageDraggedCoordinate = e.Location;
            //offset the dragged co-ordinate to make the picture be located at the center of the mouse pointer
            imageDraggedCoordinate.X += X_OFFSET;
            imageDraggedCoordinate.Y += Y_OFFSET;
        }

        // user clicks to harvest a plant
        private void DanielForm_MouseClick(object sender, MouseEventArgs e)
        {
            //loop through all the grid spaces to see where the user clicks
            for (int row = 0; row < NUM_ROWS; row++)
            {
                for (int col = 0; col < NUM_COLS; col++)
                {
                    //checks if current rectangle is the one clicked
                    if (_grid[row, col].Contains(e.Location))
                    {
                        //product exists at location on grid
                        if (model.Grid[row, col] != null)
                        {
                            //the product at the co-ordinate is available to harvest
                            if (model.Grid[row, col].CanHarvest == true)
                            {
                                //harvest the crop
                                model.HarvestCrop(row, col);

                                //update the money label
                                lblMoney.Text = "Money: $" + model.GetMoney;
                            }
                        }
                    }
                }
            }
        }
    }
}
