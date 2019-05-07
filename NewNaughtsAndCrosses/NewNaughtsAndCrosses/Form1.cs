using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewNaughtsAndCrosses
{
    public partial class Form1 : Form
    {
        public GFX engine;
        public Board theBoard;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics ToPass = panel1.CreateGraphics();
            engine = new GFX(ToPass);

            theBoard = new Board();
            theBoard.initBoard();

            refreshLabel();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            theBoard.detectHit(mouse);
            refreshLabel();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            theBoard.reset();
            GFX.setUpCanvas();
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wudup dawg\nThis was made by Matt Wood.");
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void refreshLabel()
        {
            String newText = "It is ";
            if(theBoard.getPlayerForTurn() == Board.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }

            newText += "'s Turn\n";
            newText += "X has won " + theBoard.getXWins() + " times.\nO has won " + theBoard.getOWins() + " times.";

            label1.Text = newText;
        }



    }
}
