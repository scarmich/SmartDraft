using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartDraft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Initialize all the potential champion areas
            InitializeComponent();
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;
            button2.Visible = false;
            button2.MouseEnter += new EventHandler(button2_MouseEnter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When the user clicks the button, make all portraits visible
            button2.Visible = true;
            //button2.BackgroundImage = Image.FromFile(@"/img/Aatrox.png");
        }
        void button2_MouseEnter(object sender, EventArgs e)
        {
            //Example of how to add a picture and text
            ToolTip tip = new ToolTip();
            tip.ToolTipTitle = "Aatrox";
            tip.Show("Aatrox is a legendary warrior,\n one of only five that remain"
                +" of an ancient race known as the Darkin.\n He wields his massive "
                +"blade with grace and poise, slicing through legions in a style\n "
                +"that is hypnotic to behold. With each foe felled, Aatrox's seemingly"
                +" living blade drinks in \ntheir blood, empowering him and fueling his "
                +"brutal, elegant campaign of slaughter.", this, 385, 40, 10000);
        }

    }
}
