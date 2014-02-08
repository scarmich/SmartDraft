using System;
using System.IO;
using System.Windows.Forms;

public class LocateUserLogs
{
	public String LocateUserLogs()
	{
        if (Directory.Exists("C:\\Riot Games\\League of Legends\\Logs"))
        {
            MessageBox.Show("The log files were not detected in their default install location. Please specify the 'Riot Games\\League of Legends\\Logs' directory location.");
            return "Somewhere else";
        }
        else
        {
            return "C:\\Riot Games\\League of Legends\\Logs";
        }
	}
}