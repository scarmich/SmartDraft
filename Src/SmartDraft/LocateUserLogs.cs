using System;
using System.IO;
using System.Windows.Forms;

public class LocateUserLogs
{
	public LocateUserLogs()
	{
	}

    public String locate()
    {
        if (Directory.Exists("C:\\Riot Games\\League of Legends\\Logs\\Game - R3d Logs"))
        {
            return "C:\\Riot Games\\League of Legends\\Logs\\Game - R3d Logs";
        }
        else
        {
            MessageBox.Show("Log files are not found at the default install location. Please select the location of the 'Game - R3d Logs' folder.  (Default install location is 'C:\\Riot Games\\League of Legends\\Logs\\Game - R3d Logs')");

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            return fbd.SelectedPath;
        }
    }
}