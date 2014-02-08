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


namespace SmartDraft
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ToolTip tip = new ToolTip();
            //this.button2.BackgroundImage = Image.FromFile(@"C:\Users\Tom\Documents\GitHub\SmartDraft\Src\SmartDraft\img\Aatrox.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParseUserData thing1 = new ParseUserData();
            bool thingValue = thing1.parse();

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
            
            if(radioButton4.Checked){
                //Solo Lane
                //run(solo,champdata)
            }
            else if(radioButton3.Checked){
                //ADC
                //run(adc,champdata)
            }
            else if (radioButton2.Checked)
            {
                //Jungle
                //run(jungle,champdata)
            }
            else
            {
                //Support
                //run(sup,champdata)
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
