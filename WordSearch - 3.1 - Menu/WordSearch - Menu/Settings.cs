using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordSearch___Menu
{
    public partial class Settings : Form
    {
        public static string colour = "Blue"; //default colour of the background

        public Settings()
        {
            InitializeComponent();
            comboBox1.Items.Add("Blue");//adding blue and purple to the drop down box
            comboBox1.Items.Add("Purple");
            if (Settings.colour == "Blue") //if the colour settings are blue, then...
            {
                BackColor = Color.SkyBlue; //the background colour equals blue
            }
            else
            {
                BackColor = Color.MediumOrchid; //else equals purple
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        { //when back button is clicked
            MainMenu mm = new MainMenu(); //new instance of main menu
            mm.Show(); //show instance
            Close(); //close this instance
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { //if the combobox changes
            colour = Convert.ToString(comboBox1.SelectedValue); //the user selected value is set as the colour
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        } //empty
    }
}
