using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048Project
{
    public partial class Form1 : Form
    {
        public static cell[,] myCells = new cell[4, 4];
        public static Label[,] myLabels;
        public static Panel[,] myPanels;

        static bool lose = false;
        static bool start;  //bool used to determine amount of numbers generated at the same time.

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            start = true;

            //Set up the cells
            myLabels = createLabelArray();

            //Set up color panels
            myPanels = createPanelArray();

            for (int i = 0; i < myCells.GetLength(0); i++)
            {
                for (int j = 0; j < myCells.GetLength(1); j++)
                {
                    myCells[i, j] = new cell();
                    myCells[i, j].SetLabel(myLabels[i, j]);

                    //Assign values to cells

                    textToLabel(myLabels[i, j], 0);
                    myCells[i, j].GetValue();

                    if (j > 0)
                    {
                        //We are to the right of a cell
                        myCells[i, j].setLeft(myCells[i, j - 1]);
                        myCells[i, j - 1].setRight(myCells[i, j]);
                    }

                    if (i > 0)
                    {
                        //We are above the cell
                        myCells[i, j].setUp(myCells[i - 1, j]);
                        myCells[i - 1, j].setDown(myCells[i, j]);
                    }
                }
            }
            generateRandom(myCells);
            changePanels();
        }

        public Label[,] createLabelArray()
        {
            myLabels = new Label[4, 4];

            myLabels[0, 0] = label1;    //1    First Row
            myLabels[0, 1] = label2;    //2
            myLabels[0, 2] = label3;    //3
            myLabels[0, 3] = label4;    //4

            myLabels[1, 0] = label5;    //5    Second Row
            myLabels[1, 1] = label6;    //6
            myLabels[1, 2] = label7;    //7
            myLabels[1, 3] = label8;    //8

            myLabels[2, 0] = label9;    //9    Third Row
            myLabels[2, 1] = label10;   //10
            myLabels[2, 2] = label11;   //11
            myLabels[2, 3] = label12;   //12

            myLabels[3, 0] = label13;   //13   Fourth Row
            myLabels[3, 1] = label14;   //14
            myLabels[3, 2] = label15;   //15
            myLabels[3, 3] = label16;   //16

            return myLabels;
        }

        public Panel[,] createPanelArray()
        {
            myPanels = new Panel[4, 4];

            myPanels[0, 0] = colorPanel1;    //1    First Row
            myPanels[0, 1] = colorPanel2;    //2
            myPanels[0, 2] = colorPanel3;    //3
            myPanels[0, 3] = colorPanel4;    //4

            myPanels[1, 0] = colorPanel5;    //5    Second Row
            myPanels[1, 1] = colorPanel6;    //6
            myPanels[1, 2] = colorPanel7;    //7
            myPanels[1, 3] = colorPanel8;    //8

            myPanels[2, 0] = colorPanel9;    //9    Third Row
            myPanels[2, 1] = colorPanel10;   //10
            myPanels[2, 2] = colorPanel11;   //11
            myPanels[2, 3] = colorPanel12;   //12

            myPanels[3, 0] = colorPanel13;   //13   Fourth Row
            myPanels[3, 1] = colorPanel14;   //14
            myPanels[3, 2] = colorPanel15;   //15
            myPanels[3, 3] = colorPanel16;   //16

            return myPanels;
        }

        public static void changePanels()
        {
            for (int x = 0; x < myPanels.GetLength(0); x++)
            {
                for (int y = 0; y < myPanels.GetLength(1); y++)
                {
                    if (myCells[x, y].GetValue() == 0)
                    {
                        myPanels[x, y].BackColor = Color.Transparent;

                        myLabels[x, y].Hide();
                    }
                    if (myCells[x, y].GetValue() == 2)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(238, 228, 218);
                        myLabels[x, y].BackColor = Color.FromArgb(238, 228, 218);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 4)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 224, 200);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 224, 200);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 8)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(242, 177, 121);
                        myLabels[x, y].BackColor = Color.FromArgb(242, 177, 121);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 16)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(245, 149, 99);
                        myLabels[x, y].BackColor = Color.FromArgb(245, 149, 99);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 32)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(246, 124, 96);
                        myLabels[x, y].BackColor = Color.FromArgb(246, 124, 96);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 64)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(246, 94, 59);
                        myLabels[x, y].BackColor = Color.FromArgb(246, 94, 59);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 128)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 207, 115);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 207, 115);

                        myLabels[x, y].Show();

                        MessageBox.Show("You Win!");  //  2048 is a hard number to achieve so just use 128 as a test number for winning.
                        Application.Restart();
                    }

                    if (myCells[x, y].GetValue() == 256)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 204, 98);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 204, 98);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 512)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 200, 80);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 200, 80);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 1024)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 197, 63);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 197, 63);

                        myLabels[x, y].Show();
                    }

                    if (myCells[x, y].GetValue() == 2048)
                    {
                        myPanels[x, y].BackColor = Color.FromArgb(237, 194, 45);
                        myLabels[x, y].BackColor = Color.FromArgb(237, 194, 45);

                        myLabels[x, y].Show(); 
                    }
                }
            }
        }

        public static void generateRandom(cell[,] cellArray)
        {
            //  Find a way to delay this method so the user can easily identify the randomly generated numbers to the numbers that they've already had

            int occupied = 0;

            //  This for loop determines the amount of locations available for number generation
            for (int h = 0; h < cellArray.GetLength(0); h++)
            {
                for (int i = 0; i < cellArray.GetLength(1); i++)
                {
                    if (cellArray[h, i].GetValue() == 0)
                    {
                        //  Do not add to occupied integer; room for generating random numbers
                    }
                    else if (cellArray[h, i].GetValue() != 0)
                    {
                        occupied++;
                        //  Stop generating.
                    }
                }
            }

            if (occupied == 16) //  This means that all of the cells in the board are occupied with values. The user has lost. 
            {
                //  If array is full, do not generate numbers

                //  Check the entire board and see if there are two cells next to each other that contain the same value.

                lose = true;    //  Assume the user has lost until proven otherwise

                for (int e = 0; e < cellArray.GetLength(0); e++)
                {
                    for (int f = 0; f < cellArray.GetLength(1); f++)
                    {
                        if (f > 0)  //  Left & Right
                        {
                            if (cellArray[e, f].GetValue() == cellArray[e, f - 1].GetValue())
                            {
                                lose = false;
                            }
                        }
                        if (e > 0)  //  Up & Down
                        {
                            if (cellArray[e, f].GetValue() == cellArray[e - 1, f].GetValue())
                            {
                                lose = false;
                            }
                        }
                    }
                }

                if (lose)
                {
                    MessageBox.Show("You have lost.");
                    Application.Restart();
                }
                else if (!lose)
                {
                    return;
                }
            }
            else if (occupied == 15)
            {
                Random RNG = new Random();

                //  If only one spot is open, only generate one number in that location

                continueOn:

                int t = RNG.Next(0, 4);

                int u = RNG.Next(0, 4);

                //  Checks if index is occupied by another number
                if (cellArray[t, u].GetValue() == 0)
                {
                    int twoFour = RNG.Next(0, 11);  //  In 2048, the game has a 10% chance of randomly generating a 4

                    if (twoFour == 10)
                    {
                        cellArray[t, u].SetValue(4);
                        cellArray[t, u].GetValue();
                    }
                    else if (twoFour != 10)
                    {
                        cellArray[t, u].SetValue(2);
                        cellArray[t, u].GetValue();
                    }
                }
                else if (cellArray[t, u].GetValue() != 0)   //  If RNG coordinates are already occupied by a number, then generate new random coordinates until it is not occupied.
                {
                    goto continueOn;
                }

                //  If array is full, do not generate numbers

                //  Check the entire board and see if there are two cells next to each other that contain the same value.

                lose = true;    //  Assume the user has lost until proven otherwise

                for (int e = 0; e < cellArray.GetLength(0); e++)
                {
                    for (int f = 0; f < cellArray.GetLength(1); f++)
                    {
                        if (f > 0)  //  Left & Right
                        {
                            if (cellArray[e, f].GetValue() == cellArray[e, f - 1].GetValue())
                            {
                                lose = false;
                            }
                        }
                        if (e > 0)  //  Up & Down
                        {
                            if (cellArray[e, f].GetValue() == cellArray[e - 1, f].GetValue())
                            {
                                lose = false;
                            }
                        }
                    }
                }

                if (lose)
                {
                    MessageBox.Show("You have lost.");

                    //  Reset board
                    Application.Restart();
                }
                else if (!lose)
                {
                    return;
                }
            }
            else if (occupied < 15)
            {
                // Generate normally

                if (start)
                {
                    start = false;

                    int limitVal = 0; // integer to limit amount of random coordinates generated; limits to 2 numbers

                    Random RNG = new Random();                  //  Generate random coordinates at every input //

                    continueon: //   checkpoint for generating random coordinates

                    int r = RNG.Next(0, 4);

                    int s = RNG.Next(0, 4);

                    if (limitVal < 2)
                    {
                        //  Checks if index is occupied by another number
                        if (cellArray[r, s].GetValue() == 0)
                        {
                            int twoFour = RNG.Next(0, 11);  //  In 2048, the game has a 10% chance of randomly generating a 4

                            if (twoFour == 10)
                            {
                                cellArray[r, s].SetValue(4);
                                cellArray[r, s].GetValue();

                                limitVal++;
                                goto continueon;
                            }
                            else if (twoFour != 10)
                            {
                                cellArray[r, s].SetValue(2);
                                cellArray[r, s].GetValue();

                                limitVal++;
                                goto continueon;
                            }
                        }
                        else if (cellArray[r, s].GetValue() != 0)   //  If RNG coordinates are already occupied by a number, then generate new random coordinates until it is not occupied.
                        {
                            goto continueon;    //  Go back to checkpoint.
                        }
                    }
                    else if (limitVal == 2)
                    {
                        return;
                    }
                }
                else if (!start)
                {
                    Random RNG = new Random();                  //  Generate random coordinates at every input //

                    continueon: //   checkpoint for generating random coordinates

                    int r = RNG.Next(0, 4);

                    int s = RNG.Next(0, 4);

                    //  Checks if index is occupied by another number
                    if (cellArray[r, s].GetValue() == 0)
                    {
                        int twoFour = RNG.Next(0, 11);  //  In 2048, the game has a 10% chance of randomly generating a 4

                        if (twoFour == 10)
                        {
                            cellArray[r, s].SetValue(4);
                            cellArray[r, s].GetValue();
                        }
                        else if (twoFour != 10)
                        {
                            cellArray[r, s].SetValue(2);
                            cellArray[r, s].GetValue();
                        }
                    }
                    else if (cellArray[r, s].GetValue() != 0)   //  If RNG coordinates are already occupied by a number, then generate new random coordinates until it is not occupied.
                    {
                        goto continueon;
                    }
                }
            }
        }

        public void textToLabel(Label a, int b)
        {
            a.Text = b.ToString();
        }

        public void ArrowKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                myCells[3, 0].PushUp();
                myCells[3, 1].PushUp();
                myCells[3, 2].PushUp();
                myCells[3, 3].PushUp();

                myCells[3, 0].CleanUp();
                myCells[3, 1].CleanUp();
                myCells[3, 2].CleanUp();
                myCells[3, 3].CleanUp();
            }

            if (e.KeyCode == Keys.Down)
            {
                myCells[0, 0].PushDown();
                myCells[0, 1].PushDown();
                myCells[0, 2].PushDown();
                myCells[0, 3].PushDown();

                myCells[0, 0].CleanDown();
                myCells[0, 1].CleanDown();
                myCells[0, 2].CleanDown();
                myCells[0, 3].CleanDown();
            }

            if (e.KeyCode == Keys.Left)
            {
                myCells[0, 3].PushLeft();
                myCells[1, 3].PushLeft();
                myCells[2, 3].PushLeft();
                myCells[3, 3].PushLeft();

                myCells[0, 3].CleanLeft();
                myCells[1, 3].CleanLeft();
                myCells[2, 3].CleanLeft();
                myCells[3, 3].CleanLeft();
            }

            if (e.KeyCode == Keys.Right)
            {
                myCells[0, 0].PushRight();
                myCells[1, 0].PushRight();
                myCells[2, 0].PushRight();
                myCells[3, 0].PushRight();

                myCells[0, 0].CleanRight();
                myCells[1, 0].CleanRight();
                myCells[2, 0].CleanRight();
                myCells[3, 0].CleanRight();
            }

            generateRandom(myCells);
            changePanels();
            cell.add = false;
        }
    }
    public class cell
    {
        public static bool add = false;

        cell goUp;
        cell goDown;
        cell goLeft;
        cell goRight;

        Label myLabel;

        TextBox myBox;

        int value;

        public void SetLabel(Label newLabel)
        {
            myLabel = newLabel;
        }

        public void SetText(TextBox newText)
        {
            myBox = newText;
        }

        public void setUp(cell X)
        {
            goUp = X;
        }

        public void setDown(cell X)
        {
            goDown = X;
        }

        public void setLeft(cell X)
        {
            goLeft = X;
        }

        public void setRight(cell X)
        {
            goRight = X;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int newValue)
        {
            value = newValue;
            myLabel.Text = value.ToString();
        }
        
        //PUSH METHODS FOR PUSHING CELLS IN THE DIRECTION ACCORDING TO WHAT ARROW KEY THE USER HAS PRESSED.
        public void PushUp()
        {
            if (goUp != null)
            {
                if (value != 0)
                {
                    if (goUp.GetValue() == 0)
                    {
                        goUp.SetValue(value);
                        this.SetValue(0);

                        if (goDown != null && goDown.GetValue() != 0)   //  If cell under current cell contains a value, move that value to the current cell
                        {
                            this.SetValue(goDown.GetValue());
                            goDown.SetValue(0);
                        }

                        add = false;
                        goUp.PushUp();
                    }
                    else if (goUp.GetValue() == value && !add)  //  If the cell above this cell has a value and this cell != sum of previous cell movement, add the cells
                    {
                        //  Add the two cells together and move to the next cell.
                        goUp.SetValue(value + goUp.GetValue());
                        this.SetValue(0);

                        add = true; // If value has already been added, then move to next cell.

                        if (goDown != null && goDown.GetValue() != 0)
                        {
                            this.SetValue(goDown.GetValue());
                            goDown.SetValue(0);
                        }

                        goUp.PushUp();
                    }
                    else if (goUp.GetValue() != value || goUp.GetValue() == value && add) //  If the cell above either does not = value of current cell OR has a value and this cell = sum of the previous cell movement, simply move to next cell
                    {
                        add = false;
                        goUp.PushUp();
                    }
                }
                else if (value == 0)
                {
                    add = false;
                    goUp.PushUp();
                }
            }else if (goUp == null)
            {
                return;
            }
        }

        public void PushDown()
        {
            if (goDown != null)
            {
                if (value != 0)
                {
                    if (goDown.GetValue() == 0)
                    {
                        goDown.SetValue(value);
                        this.SetValue(0);

                        if (goUp != null && goUp.GetValue() != 0)
                        {
                            this.SetValue(goUp.GetValue());
                            goUp.SetValue(0);
                        }

                        add = false;
                        goDown.PushDown();
                    }
                    else if (goDown.GetValue() == value && !add)
                    {
                        //  Add the two cells together and move to the next cell.
                        goDown.SetValue(value + goDown.GetValue());
                        this.SetValue(0);

                        add = true; // If value has already been added, then move to next cell.

                        if (goUp != null && goUp.GetValue() != 0)
                        {
                            this.SetValue(goUp.GetValue());
                            goUp.SetValue(0);
                        }
                        
                        goDown.PushDown();
                    }
                    else if (goDown.GetValue() != value || goDown.GetValue() == value && add)
                    {
                        add = false;
                        goDown.PushDown();
                    }
                }
                else if (value == 0)
                {
                    add = false;
                    goDown.PushDown();
                }
            }
            else if (goDown == null)
            {
                return;
            }
        }

        public void PushLeft()
        {
            if (goLeft != null)
            {
                if (value != 0)
                {
                    if (goLeft.GetValue() == 0)
                    {
                        goLeft.SetValue(value);
                        this.SetValue(0);

                        if (goRight != null && goRight.GetValue() != 0)
                        {
                            this.SetValue(goRight.GetValue());
                            goRight.SetValue(0);
                        }

                        add = false;
                        goLeft.PushLeft();
                    }
                    else if (goLeft.GetValue() == value && !add)
                    {
                        //  Add the two cells together and move to the next cell.
                        goLeft.SetValue(value + goLeft.GetValue());
                        this.SetValue(0);

                        add = true;

                        if (goRight != null && goRight.GetValue() != 0)
                        {
                            this.SetValue(goRight.GetValue());
                            goRight.SetValue(0);
                        }

                        goLeft.PushLeft();
                    }
                    else if (goLeft.GetValue() != value || goLeft.GetValue() == value && add)
                    {
                        add = false;
                        goLeft.PushLeft();
                    }
                }
                else if (value == 0)
                {
                    add = false;
                    goLeft.PushLeft();
                }
            }
            else if (goLeft == null)
            {
                return;
            }
        }

        public void PushRight()
        {
            if (goRight != null)
            {
                if (value != 0)
                {
                    if (goRight.GetValue() == 0)
                    {
                        goRight.SetValue(value);
                        this.SetValue(0);

                        if (goLeft != null && goLeft.GetValue() != 0)
                        {
                            this.SetValue(goLeft.GetValue());
                            goLeft.SetValue(0);

                        }

                        add = false;
                        goRight.PushRight();
                    }
                    else if (goRight.GetValue() == value & !add)
                    {
                        //  Add the two cells together and move to the next cell.
                        goRight.SetValue(value + goRight.GetValue());
                        this.SetValue(0);

                        add = true;

                        if (goLeft != null && goLeft.GetValue() != 0)
                        {
                            this.SetValue(goLeft.GetValue());
                            goLeft.SetValue(0);
                        }

                        goRight.PushRight();
                    }
                    else if (goRight.GetValue() != value || goRight.GetValue() == value && add)
                    {
                        add = false;
                        goRight.PushRight();
                    }
                }
                else if (value == 0)
                {
                    add = false;
                    goRight.PushRight();
                }
            }
            else if (goRight == null)
            {
                return;
            }
        }

        public void CleanUp()
        {
            if (goUp != null)
            {
                if (value != 0)
                {
                    if (goUp.GetValue() == 0)
                    {
                        goUp.SetValue(value);
                        this.SetValue(0);
                    }
                    else if (goUp.GetValue() != 0)
                    {
                        goUp.CleanUp();
                    }
                }
                else if (value == 0)
                {
                    if (goDown != null && goDown.GetValue() != 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        this.SetValue(goDown.GetValue());
                        goDown.SetValue(0);
                    }
                    else if (goDown == null)
                    {
                        goUp.CleanUp();
                    }
                }
            }
        }

        public void CleanDown()
        {
            if (goDown != null)
            {
                if (value != 0)
                {
                    if (goDown.GetValue() == 0)   //    If cell below is empty, move current cell value to the cell below
                    {
                        goDown.SetValue(value);
                        this.SetValue(0);
                    }
                    else if (goDown.GetValue() != 0)    //If cell below contains a value, attempt to make that value go down further
                    {
                        goDown.CleanDown();
                    }
                }
                else if (value == 0)
                {
                    if (goUp != null && goUp.GetValue() != 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        this.SetValue(goUp.GetValue());
                        goUp.SetValue(0);
                    }
                    else
                    {
                        goDown.CleanDown();
                    }
                }
            }
        }

        public void CleanLeft()
        {
            if (goLeft != null)
            {
                if (value != 0)
                {
                    if (goLeft.GetValue() == 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        goLeft.SetValue(value);
                        this.SetValue(0);
                    }
                    else if (goLeft.GetValue() != 0)
                    {
                        goLeft.CleanLeft();
                    }
                }
                else if (value == 0)
                {
                    if (goRight != null && goRight.GetValue() != 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        this.SetValue(goRight.GetValue());
                        goRight.SetValue(0);
                    }
                    else
                    {
                        goLeft.CleanLeft();
                    }
                }
            }
        }

        //CLEAN METHODS; CLEAR UP ANY EXTRA SPACE WITH RESPECT TO WHAT ARROW KEY THE USER HAS PRESSED.
        public void CleanRight()
        {
            if (goRight != null)
            {
                if (value != 0)
                {
                    if (goRight.GetValue() == 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        goRight.SetValue(value);
                        this.SetValue(0);
                    }
                    else if (goRight.GetValue() != 0)
                    {
                        goRight.CleanRight();
                    }
                }
                else if (value == 0)
                {
                    if (goLeft != null && goLeft.GetValue() != 0)   //  If cell under current cell contains a value, move that value to the current cell
                    {
                        this.SetValue(goLeft.GetValue());
                        goLeft.SetValue(0);
                    }
                    else
                    {
                        goRight.CleanRight();
                    }
                }
            }
        }
    }
}
