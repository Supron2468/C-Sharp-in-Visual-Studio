using System;
using System.Windows.Forms;
using System.Drawing;

namespace WordSearch___Menu
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent(); //start form
        }

        private void label1_Click(object sender, EventArgs e)
        {

        } //empty

        private void backBtn_Click(object sender, EventArgs e)
        { //when the back button gets clicked
            MainMenu mm = new MainMenu(); //new main menu instance
            mm.Show(); //show instance
            Close(); //closes this instance
        }

        private void Information_Load(object sender, EventArgs e)
        { //when the form loads
            if (Settings.colour == "Blue") //if the colour settings are blue, then...
            {
                BackColor = Color.SkyBlue; //the background colour equals blue
            }
            else
            {
                BackColor = Color.MediumOrchid; //else equals purple
            }
        }

        private void infoBox_TextChanged(object sender, EventArgs e)
        {

        } //empty
    }
}
