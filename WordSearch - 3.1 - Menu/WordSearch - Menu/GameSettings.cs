using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WordSearch___Menu
{
    public partial class GameSettings : Form
    {
        //Variables-----------------------------------------------------
        public static int gridSize = 15, choice = 1, categoryIndex = 0;
        //--------------------------------------------------------------

        public GameSettings()
        {
            InitializeComponent();
            if (Settings.colour == "Blue") //if the colour setting is on blue, then...
            {
                BackColor = Color.SkyBlue; //set the background colour to blue
            }
            else
            {
                BackColor = Color.MediumOrchid; //else, set to purple
            }

            try
            { //try reading the file database
                StreamReader _sr = new StreamReader("F:/vs Projects/Database.txt");
                string line = _sr.ReadLine(); //line equals to the next line

                while (line != null) //while the line is equal to something
                {
                    if (line.Contains("<")) //if the line has that symbol, then...
                    {
                        string word = line.Remove(0, 1); //word will be equal to the ends being cut off of the line
                        word = word.Remove((word.Length - 1), 1);
                        comboBox1.Items.Add(word); //the word is then added as the category in the combobox
                    }
                    line = _sr.ReadLine(); //next line
                }
                _sr.Close();//stop reading
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("Animals");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        } //empty

        private void gridSizeBtn_Click(object sender, EventArgs e)
        { 

        }  //empty

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choice = comboBox1.SelectedIndex; //the choice is equal to what the user has picked
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        { //when the back button is pressed
            MainMenu mm = new MainMenu(); //new instance of main menu
            mm.Show(); //show that instance
            Close(); //close this instance
        }

        private void startBtn_Click(object sender, EventArgs e)
        { //when the start button is pressed
            try
            { 
                if (Convert.ToInt16(textBox1.Text) <= 25 && Convert.ToInt16(textBox1.Text) >= 15) //if the text is within the bounds of 15 and 25, then...
                {
                    gridSize = Convert.ToInt16(textBox1.Text); //grid size is set to whats in the box converted to integer
                    Grid g = new Grid(); //new instance of grid
                    g.Show(); //show instance
                    Close(); //close this instance
                }
                else
                {
                    MessageBox.Show("Choose a number between 15 and 25");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not a valid number");
            }
        }
    }
}
