using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WordSearch___Menu
{
    public partial class Grid : Form
    {
        //Variables------------------------------------------------------
        public static int cellSize = 25, xEnd = 0, yEnd = 0; //Size of the cell - the end coordinates (for the word)
        private int point1x = 0, point1y = 0, point2x = 0, point2y = 0; //First and second coordinate on the grid for the selection process
        private bool loaded = false, gridBuilt = false, showAnswers = false; //checking if the game has been loaded properly so certain parts of the program can run separately 

        private int mouseClick = 0; //mouse click incrementer - to keep a record of clicks

        public List<string> wordsFound; //words found by the user in a list
        public List<Word> wordsToFind = new List<Word>(); //a list of objects which are words
        public List<List<char>> gridLoc = new List<List<char>>(); //the values of a grid in a two dimensional list
        //--------------------------------------------------------------
        

        public Grid()
        {
            InitializeComponent();
            wordsFound = new List<string>(); // For later, when the words are found, the words are added to this list

            if (MainMenu.continueGame) //if continue game is true...
            {
                Word newWord = new Word("null", 0, 0, 0, 0, 0, false); //new Word object called newWord - values are set as null, 0 or false
                StreamReader s = new StreamReader("C:/Users/Becca/Documents/School stuff - true stuff/Comp sci project/saveGame.txt"); //reads text file from location
                string line = s.ReadLine();//reads next line from file
                GameSettings.gridSize = Convert.ToInt16(line); //this line is set as gridsize
                line = s.ReadLine(); //next line
                GameSettings.choice = Convert.ToInt16(line); //this line is set as choice
                for (int i = 0; i < GameSettings.gridSize; i++)//goes through the grid
                {
                    newWord = new Word(line, 0, 0, 0, 0, 0, false); //sets the line as the word
                    wordsToFind.Add(newWord);//adds new word to the list
                }
            }

            //Sets the values for the grid
            //A list needs a place holder before it can be edited
            for (int i = 0; i < GameSettings.gridSize; i++)//first for loop, for the x axis
            {
                List<char> sublist = new List<char>();
                for (int v = 0; v < GameSettings.gridSize; v++) //second loop for the y axis
                {
                    sublist.Add(' '); // this is a placeholder - so we know exactly whats in the cell
                }
                gridLoc.Add(sublist);//this adds the y axis to the x axis in the list                
            }
        }

        public class Word
        {
            public Word()//making this public to use
            {
            }
            //all of this below is setting the variables under the word class, and making it public to the rest of the program
            public Word(string wordtofind, int sx, int sy, int ex, int ey, int dir, bool found)
            {
                this.WordToFind = wordtofind;
                this.SX = sx;
                this.SY = sy;
                this.EX = ex;
                this.EY = ey;
                this.Dir = dir;
                this.Found = found;
            }
            public string WordToFind { set; get; }
            public int SX { set; get; }
            public int SY { set; get; }
            public int EX { set; get; }
            public int EY { set; get; }
            public int Dir { set; get; }
            public bool Found { set; get; }
        }



        //Retreive words------------
        private void GrabWords()
        {
            Word newWord = new Word("null", 0, 0, 0, 0, 0, false);//Initializing each word to be blank so we can edit it easly later
            // This gets re-iterated once the go button is pressed.
            //wordsFound.Clear();
            wordsToFind.Clear();
            //messageLabel.Text = "";
            
            int index = 0;
            try
            {
                StreamReader sr = new StreamReader("F:/vs Projects/Database.txt");
                // finds the file
                string line = sr.ReadLine();//reads the line in the file
                while (line != null) //this will stop when there is not data to be found
                {
                    //This collects the integer value from the combo box
                    int count = 0;
                    while (count < GameSettings.choice + 1) // this will look through each line and will increment count. 
                    //when count is bigger than choice (+1) then we would have found the category of choice 
                    {
                        if (line.Contains("<"))
                        {
                            count++;
                        }
                        line = sr.ReadLine();
                    }
                    //now the category has been selected, we move on to the contents
                    while (!line.Contains("<"))//this will move through each line aprt from the category tiles
                    {
                        newWord = new Word(line, 0, 0, 0, 0, 0, false); //sets the line as the word
                        wordsToFind.Add(newWord); //adds the object to the list
                        line = sr.ReadLine(); //next line
                        index++; //this will total to the amount of words to find
                    }
                    //This then adds the words under the title to the list of words to find
                    sr.Close();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            listTitle.Text = "Find these " + wordsToFind.Count.ToString() + " words"; //title text - shows how many to find

            string[] words = new string[index];
            index = 0;

            foreach (var word in wordsToFind) //for every word to find
            {
                words[index] = word.WordToFind; //puts the word into the array
                index++;
                boxOfWords.SelectionLength = 0;//Unselect the selection
                boxOfWords.Lines = words; //puts the words into this array

                string[] textBoxLines = boxOfWords.Lines;//then into this array
                for (int i = 0; i < textBoxLines.Length; i++)//for every line in the textbox
                {
                    // This resets the font of each word
                    string line_ = textBoxLines[i];//the selected line in the box
                    //this next bit sets the font of each word in the text box and puts them in
                    boxOfWords.SelectionStart = boxOfWords.GetFirstCharIndexFromLine(i);
                    boxOfWords.SelectionLength = line_.Length;
                    boxOfWords.SelectionFont = new Font("", 8, FontStyle.Regular);
                    boxOfWords.SelectionColor = Color.Black;
                }
            }
        }
        //--------------------------

        //Graphics-----------------------------------------------------------------------
        private void Grid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //sets the dimensions for the borders
            int upperBorderWidth = Size.Width - 16;
            int UpperBorderHeight = 50;
            int LeftBorderWidth = 120;
            int LeftBorderHeight = Size.Height - 39;

            Graphics g = e.Graphics;//declares new graphics tools
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //Makes the lines look better

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Size.Width, Size.Height);//this covers the background incase the previous drawings come though
            g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, LeftBorderWidth, LeftBorderHeight); //this draws the left border
            g.FillRectangle(new SolidBrush(Color.BlueViolet), 0, 0, upperBorderWidth, UpperBorderHeight); //draws upper border

            for (int i = 0; i <= GameSettings.gridSize; i++)  //goes through each cell in one dimension (x = y so theres no need to do two for loops (and this only draws the grid))
            {
                g.DrawLine(new Pen(Color.Black, 1), LeftBorderWidth + (cellSize * i), UpperBorderHeight,
                    LeftBorderWidth + (cellSize * i), UpperBorderHeight + (cellSize * GameSettings.gridSize)); //this draws the horizontal lines in the grid

                g.DrawLine(new Pen(Color.Black, 1), LeftBorderWidth, UpperBorderHeight + (cellSize * i),
                    LeftBorderWidth + (cellSize * GameSettings.gridSize), UpperBorderHeight + (cellSize * i)); //this draws the vertical lines in the grid
            }
            gridBuilt = true; //now the grid is built, we can set the value to true

            if (loaded == false)
            {
                for (int i = 0; i < GameSettings.gridSize; i++) //x axis to the grid size
                {
                    for (int j = 0; j < GameSettings.gridSize; j++) //y axis
                    {
                        gridLoc[i][j] = ' '; //resets values to space as a placeholder
                    }
                }
                CreateGrid(); //calling methods
                loaded = true;
                RndLetter();
            }
            

            foreach (var word in wordsToFind)//for every word in the list
            {
                if (showAnswers)//if show answers is true
                {
                    for (int i = 0; i < word.WordToFind.Length; i++)
                    {
                        //Up
                        if (word.Dir == 0)//grabs the word direction
                        { //highlights the words in blue - each cell at a time
                            g.FillRectangle(new SolidBrush(Color.Blue), LeftBorderWidth + word.SX * cellSize, UpperBorderHeight + (word.SY - i) * cellSize, cellSize, cellSize);
                        }
                        //Right
                        else if (word.Dir == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.Blue), LeftBorderWidth + (word.SX + i) * cellSize, UpperBorderHeight + word.SY * cellSize, cellSize, cellSize);
                        }
                        //Down
                        else if (word.Dir == 2)
                        {
                            g.FillRectangle(new SolidBrush(Color.Blue), LeftBorderWidth + word.SX * cellSize, UpperBorderHeight + (word.SY + i) * cellSize, cellSize, cellSize);
                        }
                        //Left
                        else if (word.Dir == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.Blue), LeftBorderWidth + (word.SX - i) * cellSize, UpperBorderHeight + word.SY * cellSize, cellSize, cellSize);
                        }
                    }
                }
                if (word.Found == true)//if the word is found, then highlight in green
                {
                    for (int i = 0; i < word.WordToFind.Length; i++)
                    {
                        //Up
                        if (word.Dir == 0)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), LeftBorderWidth + word.SX * cellSize, UpperBorderHeight + (word.SY - i) * cellSize, cellSize, cellSize);
                        }
                        //Right
                        else if (word.Dir == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), LeftBorderWidth + (word.SX + i) * cellSize, UpperBorderHeight + word.SY * cellSize, cellSize, cellSize);
                        }
                        //Down
                        else if (word.Dir == 2)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), LeftBorderWidth + word.SX * cellSize, UpperBorderHeight + (word.SY + i) * cellSize, cellSize, cellSize);
                        }
                        //Left
                        else if (word.Dir == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), LeftBorderWidth + (word.SX - i) * cellSize, UpperBorderHeight + word.SY * cellSize, cellSize, cellSize);
                        }
                    }
                }
            }

            MatrixValues();

            if (mouseClick >= 1) //if the user has clicked at least once, then...
            {
                int x1 = (point1x - LeftBorderWidth) / cellSize; //this finds the cell in the x axis that the user has selected
                int y1 = (point1y - UpperBorderHeight) / cellSize; //same here but the y axis
                if (x1 < GameSettings.gridSize && y1 < GameSettings.gridSize) //as long as the coordinates are within the boundaries of the grid, then...
                {
                    g.DrawEllipse(new Pen(Color.DarkRed, 2), LeftBorderWidth + x1 * cellSize, UpperBorderHeight + y1 * cellSize, cellSize, cellSize); //draw a circle around the letter
                }
                else
                {
                    mouseClick = 0;
                }

                if (mouseClick >= 2)//this part is almost identical to the last
                {
                    int x2 = (point2x - LeftBorderWidth) / cellSize;
                    int y2 = (point2y - UpperBorderHeight) / cellSize;

                    if ((x2 < GameSettings.gridSize && y2 < GameSettings.gridSize) && (x2 == x1 || y2 == y1)) //the extra bit means that the second set of cordinates must be on the same axis
                    {
                        g.DrawEllipse(new Pen(Color.DarkRed, 2), LeftBorderWidth + x2 * cellSize, UpperBorderHeight + y2 * cellSize, cellSize, cellSize);
                        checkWord(x1, y1, x2, y2); //pass the coordinates through to checkword
                        mouseClick = 0; //reset variable
                    }
                    else
                    {
                        mouseClick = 1;
                    }
                }
            }
        }

        public void DrawString(int x, int y, string letter)
        {
            //declaring the sizes of the borders
            int upperBorderWidth = Size.Width - 16;
            int UpperBorderHeight = 50;
            int LeftBorderWidth = 120;
            int LeftBorderHeight = Size.Height - 39;

            System.Drawing.Graphics formGraphics = this.CreateGraphics(); //sets up the graphics and font of the letters going to be drawn
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", cellSize - 5); //font being chosen
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black); //colour being picked

            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(); //Choosing the format
            formGraphics.DrawString(letter, drawFont, drawBrush, LeftBorderWidth + (cellSize * x), UpperBorderHeight + (cellSize * y)-4, drawFormat); //drawing the letter to the grid
            //disposing the tools
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }
        //------------------------------------------------------------------------------

        //Algorithms--------------------------------------------------------------------
        private void CreateGrid()
        {
            //initialise grid
            wordsFound = new List<string>(); //new list
            gridBuilt = false; //grid hasnt been made yet

            GrabWords();

            if (!MainMenu.continueGame) //if its a new game and not continued, the...
            {
                int longest = 0;
                foreach (var word in wordsToFind) //This finds the longest word in the list of words
                {
                    if (word.WordToFind.Length > longest) 
                    {
                        longest = word.WordToFind.Length; //sets the word as longest
                    }
                }
                try
                {
                    if (GameSettings.gridSize >= longest && GameSettings.gridSize <= 35) 
                        //this sets the limits of the gridsize so thw words fit and the computer doesnt crash with high processing power
                    {
                        //Insert words randomly
                        Random rnd = new Random();
                        int index = 0;
                        foreach (var word in wordsToFind) //for every word to find
                        {
                            bool wordInserted = false;
                            while (!wordInserted) //while the word hasnt been inserted
                            {
                                bool wordOk = false;
                                int xStart = 0;
                                int yStart = 0;
                                int dir = rnd.Next(0, 4); //direction is random between 0 and 3

                                //setting the start
                                if (dir == 0)
                                {
                                    xStart = rnd.Next(0, GameSettings.gridSize); //the word will start anywhere in the x axis between 0 and the grid size
                                    yStart = rnd.Next(word.WordToFind.Length - 1, GameSettings.gridSize); //same with the y axis but the word has room to be put in
                                }
                                else if (dir == 1)
                                {
                                    xStart = rnd.Next(0, GameSettings.gridSize - word.WordToFind.Length + 1);
                                    yStart = rnd.Next(0, GameSettings.gridSize);
                                }
                                else if (dir == 2)
                                {
                                    xStart = rnd.Next(0, GameSettings.gridSize);
                                    yStart = rnd.Next(0, GameSettings.gridSize - word.WordToFind.Length + 1);
                                }
                                else if (dir == 3)
                                {
                                    xStart = rnd.Next(word.WordToFind.Length - 1, GameSettings.gridSize);
                                    yStart = rnd.Next(0, GameSettings.gridSize);
                                }
                                else
                                {
                                    MessageBox.Show("CreateGrid() setting start of word failed: {0}", word.WordToFind); //just in case it fails - i know what happened
                                }
                                
                                wordOk = wordFit(dir, word.WordToFind, xStart, yStart); //this will determine whether the word is ok to fit in this location - returns bool

                                if (wordOk == false)
                                {//dislay message to show what may have gone wrong
                                    Console.WriteLine("word was not fitted: {0}, Dir {1}, xStart {2}, yStart {3}", word.WordToFind, dir, xStart, yStart);
                                }
                                else
                                {
                                    //then insert here
                                    wordInserted = InsertWord(dir, word.WordToFind, xStart, yStart); //after checks, the word is actually inserted

                                    //all the information is put into the list of objects
                                    wordsToFind[index].Dir = dir;
                                    wordsToFind[index].SX = xStart;
                                    wordsToFind[index].SY = yStart;
                                    wordsToFind[index].EX = xEnd;
                                    wordsToFind[index].EY = yEnd;
                                    Console.WriteLine("Word fitted: Word = {0}, SX = {1}, SY = {2}, EX = {3}, EY = {4}, Dir = {5}", wordsToFind[index].WordToFind
                                        , wordsToFind[index].SX, wordsToFind[index].SY, wordsToFind[index].EX, wordsToFind[index].EY, wordsToFind[index].Dir);
                                    //confirmation of the word fitting
                                    index++;
                                }
                            }
                        }
                    }
                }
                catch //throw catch
                {
                    MessageBox.Show("Build error - placement of words");
                }
            }
            else
            { //this else is if the game is continued
                StreamReader s = new StreamReader("C:/Users/Becca/Documents/School stuff - true stuff/Comp sci project/saveGame.txt"); //read file
                string line = s.ReadLine();
                s.ReadLine(); //reads to the second line - to skip to the grid values
                int index = 1;
                for (int y = 0; y < GameSettings.gridSize; y++)
                {
                    for (int x = 0; x < GameSettings.gridSize; x++)
                    {
                        index++; //this is to keep track of the line in the file
                        gridLoc[x][y] = Convert.ToChar(s.ReadLine()); // sets line as the grid value
                    }
                }
                line = s.ReadLine(); //read the next line and set as line
                while(line != ",") //the comma was a marker to easily see when the list of found words stoped
                {
                    wordsFound.Add(line);//the line was then added to the words found list
                    line = s.ReadLine(); //next line
                }
                line = s.ReadLine();
                int i = 0; //index for the words to find list
                while (line != null) //this loop will stop when the text file ends
                {
                    string[] substrings = line.Split(' '); //each line has a space separated set of values which makes each property of a value
                    wordsToFind[i].Dir = Convert.ToInt16(substrings[0]); //these values are then set to the list of objects here
                    wordsToFind[i].SX = Convert.ToInt16(substrings[1]);
                    wordsToFind[i].SY = Convert.ToInt16(substrings[2]);
                    wordsToFind[i].EX = Convert.ToInt16(substrings[3]);
                    wordsToFind[i].EY = Convert.ToInt16(substrings[4]);
                    wordsToFind[i].Found = Convert.ToBoolean(substrings[5]);
                    wordsToFind[i].WordToFind = substrings[6];
                    line = s.ReadLine(); //next line
                    i++; //next word
                }
            }
            gridBuilt = true;
        }

        private void RndLetter()
        {
            Random rnd = new Random(); //new random instance
            for (int x = 0; x < GameSettings.gridSize; x++)
            {
                for (int y = 0; y < GameSettings.gridSize; y++) //two dimensional for loop
                {
                    if (gridLoc[x][y] == ' ') //if the value doesnt have a specific value, then...
                    {
                        gridLoc[x][y] = (char)('a' + rnd.Next(0, 26)); //set the value of the cell as a lowercase alphabetic character 
                    }
                }
            }
        }

        private void MatrixValues()
        {
            //output here
            for (int y = 0; y < GameSettings.gridSize; y++)
            {
                for (int x = 0; x < GameSettings.gridSize; x++)
                {
                    string letter = Convert.ToString(gridLoc[x][y]); //takes the value as a string
                    DrawString(x, y, letter); //pass it through with the coordinates to drawstring
                }
            }
        }

        private bool InsertWord(int direction, string word, int x, int y)
        {
            int xInsert = x;
            int yInsert = y;
            for (int i = 0; i < word.Length; i++) //goes through each character of the word
            {
                //Up
                if (direction == 0) //if direction up
                {
                    gridLoc[xInsert][yInsert - i] = word[i]; //the x coordinate stays the same - the y decreases - each letter is assigned to that location
                    xEnd = xInsert; //these are set for a later use
                    yEnd = yInsert - i;
                }
                //Right
                else if (direction == 1)
                {
                    gridLoc[xInsert + i][yInsert] = word[i];
                    xEnd = xInsert + i;
                    yEnd = yInsert;
                }
                //Down
                else if (direction == 2)
                {
                    gridLoc[xInsert][yInsert + i] = word[i];
                    xEnd = xInsert;
                    yEnd = yInsert + i;
                }
                //Left
                else if (direction == 3)
                {
                    gridLoc[xInsert - i][yInsert] = word[i];
                    xEnd = xInsert - i;
                    yEnd = yInsert;
                }
            }
            return true;
        }

        private void checkWord(int X1, int Y1, int X2, int Y2)
        {
            string word = null;
            if (X1 < X2) //these if statements are to determine what the direction is without the need to pass it through
            {
                for (int i = X1; i <= X2; i++)
                {
                    word += gridLoc[i][Y1]; //takes each letter from the grid and forms the word
                }
                confirmWord(word); //this word is then checked - more information in the function
            }
            else if (X2 < X1)
            {
                for (int i = X2; i <= X1; i++)
                {
                    word += gridLoc[i][Y1];
                }
                confirmWord(word);
            }
            else if (Y1 < Y2)
            {
                for (int i = Y1; i <= Y2; i++)
                {
                    word += gridLoc[X1][i];
                }
                confirmWord(word);
            }
            else if (Y2 < Y1)
            {
                for (int i = Y2; i <= Y1; i++)
                {
                    word += gridLoc[X1][i];
                }
                confirmWord(word);
            }
        }
        
        private void confirmWord(string word)
        {
            foreach (var wordToFind in wordsToFind) //for every word to find in the list
            {
                if (wordToFind.WordToFind == word || wordToFind.WordToFind == ReversedString(word)) //if the word selected matches the words in the list or reversed, then...
                {
                    if (wordToFind.WordToFind == ReversedString(word)) //to perminantly flip the word
                    {
                        word = ReversedString(word);
                    }
                    wordToFind.Found = true; //found
                    if (!wordsFound.Contains(word)) //this stops double selecting a word - if the word isnt in the wordsfound list
                    {
                        wordsFound.Add(word); //add the word to the list

                        msgLabel.Text = "Well done! You have found \n\"" + word + "\"\n"
                            + wordsFound.Count.ToString() + "/" + wordsToFind.Count.ToString() + " Words Found!"; //message label changes its text

                        this.Invalidate(); //refreshes the board - redraws it so it doesnt have circles on it and the word is highlighted
                    }
                    if (wordsFound.Count >= wordsToFind.Count) //if the found word list is equal or bigger than the words to find list, then...
                    {
                        DialogResult result = MessageBox.Show("Congratulations!!! You found all the words!!! Continue?", 
                            "Game Over", //this displays a message box that gives different options to the player
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes) //if the result is yes, then...
                        {
                            MainMenu mm = new MainMenu(); //new instance of the main menu
                            gridBuilt = false;
                            mm.Show(); //shows the instance
                            Close(); //Closes the grid instance
                        }
                        else
                        {
                            System.Environment.Exit(0); //otherwise, stop the program
                        }
                    }
                }

            }

            string[] textBoxLines = boxOfWords.Lines; //set new array to equal all the lines in the box of words
            for (int i = 0; i < textBoxLines.Length; i++) //goes through each line in the box
            {
                foreach (var word_ in wordsFound) //for every word in the words found list
                {
                    string line = textBoxLines[i]; //a new string is set as the current line
                    if (line.Equals(word_)) //if the line is equal to a word that is found, then...
                    {
                        boxOfWords.SelectionStart = boxOfWords.GetFirstCharIndexFromLine(i); //select word from line
                        boxOfWords.SelectionLength = line.Length; //grab the word length for the selection
                        boxOfWords.SelectionFont = new Font("", 8, FontStyle.Strikeout); //change font to be the same size but have a strike through it
                        boxOfWords.SelectionColor = Color.Gray; //change colour to grey
                    }
                }
            }
        }

        private string ReversedString(string input)
        {
            string temp = ""; //new empty string
            foreach (char c in input) //for every charater in the input
            {
                temp = c + temp; //add to the temporary string
            }
            return temp; //output temp string
        }

        private bool wordFit(int dir, string word, int x, int y)
        {
            int ok = 0;

            for (int i = 0; i < word.Length; i++) //goes through each letter of the word
            {
                if (dir == 0) //if up
                {
                    if (gridLoc[x][y - i] != ' ') //if it contains something
                    {
                        i = word.Length; //stop the for loop by setting i as word length
                    }
                    else
                    {
                        ok++; //this says that the cell value is available to put a letter
                    }
                }
                else if (dir == 1)
                {
                    if (gridLoc[x + i][y] != ' ')
                    {
                        i = word.Length;
                    }
                    else
                    {
                        ok++;
                    }
                }
                else if (dir == 2)
                {
                    if (gridLoc[x][y + i] != ' ')
                    {
                        i = word.Length;
                    }
                    else
                    {
                        ok++;
                    }
                }
                else if (dir == 3)
                {
                    if (gridLoc[x - i][y] != ' ')
                    {
                        i = word.Length;
                    }
                    else
                    {
                        ok++;
                    }
                }
                else
                {
                    Console.WriteLine("something went wrong under wordFit()"); //Error handling
                }
            }

            if (ok >= word.Length) //we know if the word can fit if all cells are available which should be the same number as the word length
            {
                return true;
            }
            else //else it cant fit - false
            {
                return false;
            }
        }

        private void SaveGame()
        {
            string[] lines = new string[GameSettings.gridSize * GameSettings.gridSize + wordsFound.Count + wordsToFind.Count + 3]; 
            //the amount of lines equates to the grid size squared, plus the size of words found plus the words to find and plus three (grid size, choice and a comma)
            lines[0] = Convert.ToString(GameSettings.gridSize); //to know the size
            lines[1] = Convert.ToString(GameSettings.choice); //to know the choice
            int index = 1;
            for (int y = 0; y < GameSettings.gridSize; y++)
            {
                for (int x = 0; x < GameSettings.gridSize; x++)
                {
                    index++; //keeps track of the line index
                    lines[index] = Convert.ToString(gridLoc[x][y]); //adds each cell value to the lines array
                }
            } 
            foreach (var word in wordsFound) //for every word in the wordsfound list
            {
                index++; //increment line index
                lines[index] = word; //adds word from the list to the array
            }
            index++;
            lines[index] = ","; //the marker is then placed
            foreach (var word in wordsToFind) //for every word in words to find
            {
                index++;
                lines[index] = (Convert.ToString(word.Dir) + " " + Convert.ToString(word.SX) + " " + Convert.ToString(word.SY) + " " + Convert.ToString(word.EX)
                    + " " + Convert.ToString(word.EY) + " " + Convert.ToString(word.Found) + " " + Convert.ToString(word.WordToFind));
                //the line equals the word properties (direction, start x, start y, end x, end y, found, word to find)
            }
            System.IO.File.WriteAllLines(@"F:/vs Projects/saveGame.txt", lines);
            //adds lines to a new save game file
        }
        //------------------------------------------------------------------------------
        
        //Form--------------------------------------------------------------------------
        private void Form1_Click(object sender, EventArgs e)
        {//the player has clicked on the form, so this method gets initiated
            if (gridBuilt) //if the grid has been built, then...
            {
                mouseClick++;//increment mouse click
                if (mouseClick == 1) 
                {
                    point1x = this.PointToClient(Cursor.Position).X; //sets the cursor coordinates of x and y to the public variables
                    point1y = this.PointToClient(Cursor.Position).Y;
                }
                else
                {
                    point2x = this.PointToClient(Cursor.Position).X; //same as before but the second set
                    point2y = this.PointToClient(Cursor.Position).Y;
                }
                this.Invalidate(); //refresh 
            }
        }

        private void openMainMenu_Click_1(object sender, EventArgs e)
        {
            MainMenu.continueGame = false;
            SaveGame(); //call save game
            MainMenu mm = new MainMenu(); //new instance of the main menu
            gridBuilt = false; 
            mm.Show(); //shows the instance
            Close(); //Closes the grid instance
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            SaveGame(); //calls the save game function before stopping the program
            System.Environment.Exit(0);
        }
        
        private void Grid_Load(object sender, EventArgs e)
        {

        } //empty

        private void boxOfWords_TextChanged(object sender, EventArgs e)
        {

        } //empty

        private void showAnsBtn_Click(object sender, EventArgs e)
        { //when the show answers button is clicked
            showAnswers = true; 
            this.Invalidate(); //refreshes draw
        }
        //------------------------------------------------------------------------------
    }
}
