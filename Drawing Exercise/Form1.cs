using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Drawing_Exercise
{
    public partial class Form1 : Form
    {
        public Board theBoard;
        public GFX engine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics toPass = panel1.CreateGraphics();
            engine = new GFX(toPass);

            theBoard = new Board();
            theBoard.initBoard();

            refreshLabel();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            theBoard.detectHit(mouse);

            refreshLabel();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            theBoard.reset();
            GFX.setUpCanvas();
        }

        public void refreshLabel()
        {
            String newText = "It is ";
            if (theBoard.getPlayerForTurn() == Board.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }
            newText += "'s Turn\n";
            newText += "X has won " + theBoard.getXWins() + " times.\nO has won " + theBoard.getOWins() + " times.";

            lblWinner.Text = newText;
        }
    }
}
