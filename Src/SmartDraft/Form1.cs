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
                
            }/*
            Color[,] pixelarray = new Color[10,12];
            for (int i = 0; i < 10; i ++ )
            {
                for (int j = 0; j < 4; j++ )
                {
                    pixelarray[i,j] = 
                }
            }*/
            
            imgarray2[1].SetPixel(75, 13,Color.Pink);
            imgarray2[1].SetPixel(75, 53, Color.Pink);
            imgarray2[1].SetPixel(75, 33, Color.Pink);

            imgarray2[1].SetPixel(55, 13, Color.Pink);
            imgarray2[1].SetPixel(55, 53, Color.Pink);
            imgarray2[1].SetPixel(55, 33, Color.Pink);

            imgarray2[1].SetPixel(35, 13, Color.Pink);
            imgarray2[1].SetPixel(35, 53, Color.Pink);
            imgarray2[1].SetPixel(35, 33, Color.Pink);

            imgarray2[1].SetPixel(45, 23, Color.Pink);
            imgarray2[1].SetPixel(65, 23, Color.Pink);
            imgarray2[1].SetPixel(45, 43, Color.Pink);
            imgarray2[1].SetPixel(65, 43, Color.Pink);
            
            btnChamp1.BackgroundImage = imgarray2[0];
            btnChamp2.BackgroundImage = imgarray2[1];
            btnChamp3.BackgroundImage = imgarray2[2];
            btnChamp4.BackgroundImage = imgarray2[3];
            btnChamp5.BackgroundImage = imgarray2[4];
            
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
