using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing_Exercise
{
    public class Board
    {
        public int movesMade = 0;
        public int Owins = 0;
        public int Xwins = 0;

        // private Rectangle[,] slots = new Rectangle[3, 3];
        private Holder[,] holders = new Holder[3, 3];

        public const int X = 0;
        public const int O = 1;
        public const int B = 2;

        public int playersTurn = X;

        public int getPlayerForTurn()
        {
            return playersTurn;
        }

        public int getOWins()
        {
            return Owins;
        }

        public int getXWins()
        {
            return Xwins;
        }

        public void initBoard()
        {
            for (int x=0; x<3; x++)
            {
                for (int y=0; y<3; y++)
                {
                    
                    holders[x, y] = new Holder();
                    holders[x, y].setValue(B);
                    holders[x, y].setLocation(new Point(x, y));

                }
            }
         }

        public void detectHit(Point loc)
        {
            // Checks if the board was clicked
            if (loc.Y <= 300)
            {
                int x = 0;
                int y = 0;

                if (loc.X < 100)
                {
                    x = 0;
                }
                else if (loc.X > 100 && loc.X < 200)
                {
                    x = 1;
                }
                else if (loc.X > 200)
                {
                    x = 2;
                }

                if (loc.Y < 100)
                {
                    y = 0;
                }
                else if (loc.Y > 100 && loc.Y < 200)
                {
                    y = 1;
                }
                else if (loc.Y > 200 && loc.Y < 300)
                {
                    y = 2;
                }

                if (movesMade % 2 == 0)
                {
                    GFX.drawX(new Point(x,y));
                    holders[x, y].setValue(X);
                    if (detectRow())
                    {
                        MessageBox.Show("You have won, X");
                        Xwins++;
                        reset();
                        GFX.setUpCanvas();
                    }
                    playersTurn = O;
                }
                else
                {
                    GFX.drawO(new Point(x, y));
                    holders[x, y].setValue(O);
                    if (detectRow())
                    {
                        MessageBox.Show("You have won, O");
                        Owins++;
                        reset();
                        GFX.setUpCanvas();
                    }
                    playersTurn = X;
                }
                movesMade++;
            }
        }
        public bool detectRow()
        {
            bool isWon = false;
            //Detects vertical wins
            for(int x = 0; x<3; x++)
            {
                if (holders[x, 0].getValue() == X && holders[x, 1].getValue() == X && holders[x, 2].getValue() == X)
                {
                    return true;
                }
                if (holders[x, 0].getValue() == O && holders[x, 1].getValue() == O && holders[x, 2].getValue() == O)
                {
                    return true;
                }

                // Detects diagonal wins
                switch (x)
                {
                    case 0:
                        if (holders[x, 0].getValue() == X && holders[x+1, 1].getValue() == X && holders[x+2,2].getValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x + 1, 1].getValue() == O && holders[x + 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;

                    case 2:
                        if (holders[x, 0].getValue() == X && holders[x - 1, 1].getValue() == X && holders[x - 2, 2].getValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x - 1, 1].getValue() == O && holders[x - 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;
                }
                // Detects horizontal wins
                for(int y = 0; y <3; y++)
                {
                    if (holders[0, y].getValue() == X && holders[1, y].getValue() == X && holders[2, y].getValue() == X)
                    {
                        return true;
                    }
                    if (holders[0, y].getValue() == O && holders[1, y].getValue() == O && holders[2, y].getValue() == O)
                    {
                        return true;
                    }
                }

            }

            return isWon;
        }

        public void reset()
        {
            holders = new Holder[3,3];
            initBoard();
        }
    }

    public class Holder
    {
        private Point location;
        private int value = Board.B;
        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }

        public void setValue(int i)
        {
            value = i;
        }
        public int getValue()
        {
            return value;
        }
    }
}
