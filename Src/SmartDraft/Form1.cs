using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace SmartDraft
{

    public partial class Form1 : Form
    {
        public const int CHAMPNUM = 117;
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, out Rectangle rect);

        Bitmap CaptureScreen(int x1, int y1)
        {
            var image = new Bitmap(100, 75, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            //MessageBox.Show(""+Screen.PrimaryScreen.Bounds.Size);
            gfx.CopyFromScreen(x1, y1, 0, 0, new Size(100,75), CopyPixelOperation.SourceCopy);
            //gfx.CopyFromScreen(x1, y1,);
            /*Rectangle cropRect = new Rectangle();
            Bitmap src = image;
            Bitmap target = new Bitmap(120, 50);

            using(Graphics g = Graphics.FromImage(target))
            {
               g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                                cropRect,                        
                                GraphicsUnit.Pixel);
            }
            MessageBox.Show(image.Width+" "+image.Height);*/
            return image;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmStartScreen start = new frmStartScreen();
            start.Show();
            //At minimum scale from top left to first pixel in champ portrait is
            //67w 62h
            //min width total = 1024
            //min height total = 640
            //from champ 1 to champ 2 is 62 -> 81, width of img is 46
            ToolTip tip = new ToolTip();
        }

        /*
        private int[,] getChampBoxes(int w, int h)
        {

            //find first champ x and y, check if player
            //find first champ width
            //based on first champ x,y find next champs
            
        }*/



        private void button1_Click(object sender, EventArgs e)
        {
            
            int usernum;

            ParseUserData thing1 = new ParseUserData();
            bool thingValue = thing1.parse();
            System.Diagnostics.Debug.WriteLine("Returned from Parser without Error");

            //ParseUserData thing1 = new ParseUserData();
            //bool thingValue = thing1.parse();

            Process[] processes = Process.GetProcessesByName("LolClient");
            Process lol = processes[0];
            IntPtr ptr = lol.MainWindowHandle;
            Rectangle NotepadRect = new Rectangle();
            //int i = NotepadRect.Bottom;
            
            //MessageBox.Show(""+i);
            GetWindowRect(ptr, out NotepadRect);
            MessageBox.Show("" + NotepadRect.X);
            Bitmap[] imgarray = new Bitmap[10];
            Bitmap[] imgarray2 = new Bitmap[10];
            int x = NotepadRect.X;
            int y = NotepadRect.Y;
            //Figure out which turn you are
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    imgarray[i] = CaptureScreen(x + 45, y + 60);
                    y += 120;
                }
                else if (i == 1)
                {
                    imgarray[i] = CaptureScreen(x + 45, y + 30);
                    y += 120;
                }
                else
                {
                    imgarray[i] = CaptureScreen(x + 45, y);
                    y += 90;
                }

                //need to adjust this based on window size

            }

            System.Diagnostics.Debug.WriteLine("Returned from Parser without Error");

            for (int i = 0; i < 5; i++)
            {
                if (imgarray[i].GetPixel(20, 10).A == 255
                    && imgarray[i].GetPixel(20, 10).B == 21
                    && imgarray[i].GetPixel(20, 10).R == 250
                    && imgarray[i].GetPixel(20, 10).G == 147)
                {
                    usernum = i;
                    MessageBox.Show(""+usernum);
                }
            }
            x = NotepadRect.X;
            y = NotepadRect.Y;
            //Get all the opponents
            for (int i = 0; i < 10; i ++ )
            {
                if (i == 0)
                {
                    imgarray2[i] = CaptureScreen(x+970, y + 60);
                    y += 120;
                }
                else if (i == 1)
                {
                    imgarray2[i] = CaptureScreen(x+970, y + 30);
                    y += 120;
                }
                else
                {
                    imgarray2[i] = CaptureScreen(x+970, y);
                    y += 90;
                }
                //need to adjust this based on window size

            }

            System.Diagnostics.Debug.WriteLine("Returned from Parser without Error");
            
            /*
            Color[,] pixelarray = new Color[10,12];
            for (int i = 0; i < 10; i ++ )
            {
                for (int j = 0; j < 4; j++ )
                {
                    pixelarray[i,j] = 
                }
            }*/
            for (int i = 0; i < 5; i++ )
            {
               /* imgarray[i].SetPixel(75, 13, Color.Pink);
                imgarray[i].SetPixel(75, 53, Color.Pink);
                imgarray[i].SetPixel(75, 33, Color.Pink);

                imgarray[i].SetPixel(55, 13, Color.Pink);
                imgarray[i].SetPixel(55, 53, Color.Pink);
                imgarray[i].SetPixel(55, 33, Color.Pink);

                imgarray[i].SetPixel(35, 13, Color.Pink);
                imgarray[i].SetPixel(35, 53, Color.Pink);
                imgarray[i].SetPixel(35, 33, Color.Pink);

                imgarray[i].SetPixel(45, 23, Color.Pink);
                imgarray[i].SetPixel(65, 23, Color.Pink);
                imgarray[i].SetPixel(45, 43, Color.Pink);
                imgarray[i].SetPixel(65, 43, Color.Pink);*/
                string temp = "";
                string[] champ = new string[5];
                temp = imgarray2[i].GetPixel(75,13)+""
                    +imgarray2[i].GetPixel(75,53)+""
                    +imgarray2[i].GetPixel(75,33)+""
                    +imgarray2[i].GetPixel(55,13)+""
                    +imgarray2[i].GetPixel(55,53)+""
                    +imgarray2[i].GetPixel(55,33)+""
                    +imgarray2[i].GetPixel(35,13)+""
                    +imgarray2[i].GetPixel(35,53)+""
                    +imgarray2[i].GetPixel(35,33)+""
                    +imgarray2[i].GetPixel(45,23)+""
                    +imgarray2[i].GetPixel(65,23)+""
                    +imgarray2[i].GetPixel(45,43)+""
                    +imgarray2[i].GetPixel(65,43);
                //read file line by line
                //if(curLine.Contains(temp))
                //champ[i] = first word
                //MessageBox.Show(champ[i]);
                //MessageBox.Show(temp);
                String line;

                // Read the file and display it line by line.
                StreamReader file = File.OpenText("maps.txt");
                //MessageBox.Show("before");
                //MessageBox.Show(file.ReadLine());
                while ((line = file.ReadLine()) != null)
                {
                    //MessageBox.Show("the line"+line);
                    if(line.Contains(temp)){
                        champ[i] = line.Substring(0, line.IndexOf(" "));
                    }
                }
                Champion newChamp = new Champion(champ[i],"solo");
                file.Close();
                MessageBox.Show(newChamp.getPos());
                



            }/*
            Color[,] enemyVals = new Color[5,13];
            //enemy champ 1
            enemyVals[0,0] = imgarray2[0].GetPixel(75, 13);
            enemyVals[0, 1] = imgarray2[0].GetPixel(75, 53);
            enemyVals[0, 2] = imgarray2[0].GetPixel(75, 33);
            enemyVals[0, 3] = imgarray2[0].GetPixel(55, 13);
            enemyVals[0, 4] = imgarray2[0].GetPixel(55, 53);
            enemyVals[0, 5] = imgarray2[0].GetPixel(55, 33);
            enemyVals[0, 6] = imgarray2[0].GetPixel(35, 13);
            enemyVals[0, 7] = imgarray2[0].GetPixel(35, 53);
            enemyVals[0, 8] = imgarray2[0].GetPixel(35, 33);
            enemyVals[0, 9] = imgarray2[0].GetPixel(45, 23);
            enemyVals[0, 10] = imgarray2[0].GetPixel(65, 23);
            enemyVals[0, 11] = imgarray2[0].GetPixel(45, 43);
            enemyVals[0, 12] = imgarray2[0].GetPixel(65, 43);

            //enemy champ 2
            enemyVals[1, 0] = imgarray2[1].GetPixel(75, 13);
            enemyVals[1, 1] = imgarray2[1].GetPixel(75, 53);
            enemyVals[1, 2] = imgarray2[1].GetPixel(75, 33);
            enemyVals[1, 3] = imgarray2[1].GetPixel(55, 13);
            enemyVals[1, 4] = imgarray2[1].GetPixel(55, 53);
            enemyVals[1, 5] = imgarray2[1].GetPixel(55, 33);
            enemyVals[1, 6] = imgarray2[1].GetPixel(35, 13);
            enemyVals[1, 7] = imgarray2[1].GetPixel(35, 53);
            enemyVals[1, 8] = imgarray2[1].GetPixel(35, 33);
            enemyVals[1, 9] = imgarray2[1].GetPixel(45, 23);
            enemyVals[1, 10] = imgarray2[1].GetPixel(65, 23);
            enemyVals[1, 11] = imgarray2[1].GetPixel(45, 43);
            enemyVals[1, 12] = imgarray2[1].GetPixel(65, 43);

            //enemy champ 3
            enemyVals[2, 0] = imgarray2[2].GetPixel(75, 13);
            enemyVals[2, 1] = imgarray2[2].GetPixel(75, 53);
            enemyVals[2, 2] = imgarray2[2].GetPixel(75, 33);
            enemyVals[2, 3] = imgarray2[2].GetPixel(55, 13);
            enemyVals[2, 4] = imgarray2[2].GetPixel(55, 53);
            enemyVals[2, 5] = imgarray2[2].GetPixel(55, 33);
            enemyVals[2, 6] = imgarray2[2].GetPixel(35, 13);
            enemyVals[2, 7] = imgarray2[2].GetPixel(35, 53);
            enemyVals[2, 8] = imgarray2[2].GetPixel(35, 33);
            enemyVals[2, 9] = imgarray2[2].GetPixel(45, 23);
            enemyVals[2, 10] = imgarray2[2].GetPixel(65, 23);
            enemyVals[2, 11] = imgarray2[2].GetPixel(45, 43);
            enemyVals[2, 12] = imgarray2[2].GetPixel(65, 43);

            //enemy champ 4
            enemyVals[3, 0] = imgarray2[3].GetPixel(75, 13);
            enemyVals[3, 1] = imgarray2[3].GetPixel(75, 53);
            enemyVals[3, 2] = imgarray2[3].GetPixel(75, 33);
            enemyVals[3, 3] = imgarray2[3].GetPixel(55, 13);
            enemyVals[3, 4] = imgarray2[3].GetPixel(55, 53);
            enemyVals[3, 5] = imgarray2[3].GetPixel(55, 33);
            enemyVals[3, 6] = imgarray2[3].GetPixel(35, 13);
            enemyVals[3, 7] = imgarray2[3].GetPixel(35, 53);
            enemyVals[3, 8] = imgarray2[3].GetPixel(35, 33);
            enemyVals[3, 9] = imgarray2[3].GetPixel(45, 23);
            enemyVals[3, 10] = imgarray2[3].GetPixel(65, 23);
            enemyVals[3, 11] = imgarray2[3].GetPixel(45, 43);
            enemyVals[3, 12] = imgarray2[3].GetPixel(65, 43);

            //enemy champ 5
            enemyVals[4, 0] = imgarray2[4].GetPixel(75, 13);
            enemyVals[4, 1] = imgarray2[4].GetPixel(75, 53);
            enemyVals[4, 2] = imgarray2[4].GetPixel(75, 33);
            enemyVals[4, 3] = imgarray2[4].GetPixel(55, 13);
            enemyVals[4, 4] = imgarray2[4].GetPixel(55, 53);
            enemyVals[4, 5] = imgarray2[4].GetPixel(55, 33);
            enemyVals[4, 6] = imgarray2[4].GetPixel(35, 13);
            enemyVals[4, 7] = imgarray2[4].GetPixel(35, 53);
            enemyVals[4, 8] = imgarray2[4].GetPixel(35, 33);
            enemyVals[4, 9] = imgarray2[4].GetPixel(45, 23);
            enemyVals[4, 10] = imgarray2[4].GetPixel(65, 23);
            enemyVals[4, 11] = imgarray2[4].GetPixel(45, 43);
            enemyVals[4, 12] = imgarray2[4].GetPixel(65, 43);
            */
            btnChamp1.BackgroundImage = imgarray2[0];
            btnChamp2.BackgroundImage = imgarray2[1];
            btnChamp3.BackgroundImage = imgarray2[2];
            btnChamp4.BackgroundImage = imgarray2[3];
            btnChamp5.BackgroundImage = imgarray2[4];

           /*
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader("champdata.txt"))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string champdata = sb.ToString();
            */
            if(radSolo.Checked == true)
            {
                //Solo Lane
                //run(solo,champdata)
            }
            else if(radADC.Checked == true)
            {
                //ADC
                //run(adc,champdata)
            }
            else if (radJungle.Checked == true)
            {
                //Jungle
                //run(jungle,champdata)
            }
            else if (radSupport.Checked == true)
            {
                //Support
                //run(sup,champdata)
            }
            else //nothing is selected
            {
                MessageBox.Show("Please select a role you are picking for.");
            }
        }
        //This button will show graphs comparing stats of the selected champion
        //and enemy champion, if there is a picture.
        private void button2_Click(object sender, EventArgs e)
        {
            if (btnChamp1.BackgroundImage == null)
            {
                return;
            }
            FrmStats formStats = new FrmStats();
            formStats.ShowDialog();
        }
        //The reset button clears all fields on the program.
        private void btnReset_Click(object sender, EventArgs e)
        {
            radADC.Checked = false;
            radJungle.Checked = false;
            radSolo.Checked = false;
            radSupport.Checked = false;
            btnChamp1.BackgroundImage = null;
            btnChamp2.BackgroundImage = null;
            btnChamp3.BackgroundImage = null;
            btnChamp4.BackgroundImage = null;
            btnChamp5.BackgroundImage = null;
        }
    }
}
