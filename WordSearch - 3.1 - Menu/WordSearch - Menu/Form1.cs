using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WordSearch___Menu
{
    public partial class MainMenu : Form
    {
        public static bool continueGame = false;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.colour == "Blue") //This grabs the colour option from the settings form 
            {
                BackColor = Color.SkyBlue;// sets background to sky blue
            }
            else
            {
                BackColor = Color.MediumOrchid; //else, set to purple
            }
        }

        //Buttons----------------------------------------------------
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            GameSettings gameSet = new GameSettings(); //creates a new instance of gameSettings
            gameSet.Show(); //shows that instant
            Hide(); //hides this form (can't close it as it runs the program)
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            try //trys this code - if fail - catch
            {
                StreamReader s = new StreamReader("F:/vs Projects/saveGame.txt"); //reads text file from location
                continueGame = true; //set true
                Grid g = new Grid(); //new instance of grid
                g.Show(); //shows instance
                Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find saved game"); //a message box will appear with message if failed
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            Hide();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Show();
            Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //stops program
        }
        //-----------------------------------------------------------


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
