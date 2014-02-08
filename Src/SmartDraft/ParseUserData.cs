using System;
using System.IO;
using System.Windows.Forms;

public class ParseUserData
{
	public ParseUserData(){  }

    public bool parse(){

        LocateUserLogs locator = new LocateUserLogs();
        String filepath = locator.locate();

        String[] logs = Directory.GetFiles(filepath);

        foreach (String gamelog in logs)
        {
            /* open each file in the logs folder and parse the data */
            System.Diagnostics.Debug.WriteLine(gamelog);

            StreamReader reader = File.OpenText(gamelog);
            String line; String champ = "";

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("ALWAYS") && line.Contains("Creating Hero") )
                {
                    line = reader.ReadLine();
                    if (line.Contains("ALWAYS") == false) { 
                        /* read through potential errors */
                        while ((line = reader.ReadLine()).Contains("ALWAYS") == false) { /*keep reading until line contains always*/}
                    }
                    int index = line.IndexOf("ALWAYS");
                    line = line.Substring(index + 8);

                    if ( line.Contains("Hero") )
                    {
                        String[] components = line.Split(' ');
                        champ = components[1];
                        if (components[1].Contains("(")) { components = components[1].Split('('); champ = components[0]; }
                    }
                    if (line.Contains("Spawning"))
                    {
                        String[] components = line.Split(' ');
                        champ = components[2].Substring(1, components[2].Length - 2);
                    }

                    System.Diagnostics.Debug.WriteLine(champ);
                    //System.Diagnostics.Debug.WriteLine("Index of ALWAYS = " + index);
                   
                    //System.Diagnostics.Debug.WriteLine(line);
                }
            }


        }

        return false;
    }
}
