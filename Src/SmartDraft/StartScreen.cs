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
    public partial class frmStartScreen : Form
    {
        public frmStartScreen()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Submit button records the summoner's name to a file that will be used for 
        //searching stats in previous games
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a summoner name.");
                txtName.Focus();
                return;
            }
            
            using (StreamWriter sw = File.AppendText("sumNames.txt"))
            {
                sw.WriteLine(txtName.Text + "\r\n");
            }

            txtName.Text = "";
            lblGreetings.Text = "Please enter another of your summoner names." + "\r\n"
                + "If you have more names, click finish." + "\r\n"
                + "Note: If you have changed your summoner name, you must include" + "\r\n"
                + "your old summoner name(s) for better accuracy.";
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {

            // If there is already a non-empty file for Summoner names, 
            // close the StartScreen form.
            if (File.Exists("sumNames.txt"))
            {
                if (new FileInfo("sumNames.txt").Length > 0)
                {
                    Close();
                }
            }
            else
            {
                //Create the empty file
                using (FileStream fs = File.Create("sumNames.txt"))
                {
                    //oooh, empty
                }
            }
        }

    }
}
