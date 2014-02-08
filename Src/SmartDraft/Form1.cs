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
            var image = new Bitmap(120, 120, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            MessageBox.Show(""+Screen.PrimaryScreen.Bounds.Size);
            gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X+x1+35, Screen.PrimaryScreen.Bounds.Y+y1+35, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            //gfx.CopyFromScreen(x1, y1,);
            Rectangle cropRect = new Rectangle();
            Bitmap src = image;
            Bitmap target = new Bitmap(50, 50);

            using(Graphics g = Graphics.FromImage(target))
            {
               g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                                cropRect,                        
                                GraphicsUnit.Pixel);
            }
            MessageBox.Show(src.Width+" "+src.Height);
            return src;
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

            //this.button2.BackgroundImage = Image.FromFile(@"C:\Users\Tom\Documents\GitHub\SmartDraft\Src\SmartDraft\img\Aatrox.png");
            this.btnChamp1.BackgroundImage = Image.FromFile(@"C:\Users\Tom\Documents\GitHub\SmartDraft\Src\SmartDraft\img\Aatrox.png");
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
            
            Process[] processes = Process.GetProcessesByName("LolClient");
            Process lol = processes[0];
            IntPtr ptr = lol.MainWindowHandle;
            Rectangle NotepadRect = new Rectangle();
            int i = NotepadRect.Bottom;
            
            //MessageBox.Show(""+i);
            GetWindowRect(ptr, out NotepadRect);
            MessageBox.Show("" + NotepadRect.X);
            
            btnChamp2.BackgroundImage = CaptureScreen(NotepadRect.X, NotepadRect.Y);
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
