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
            String line; String champ = ""; String username = "";

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("ALWAYS") && line.Contains("Creating Hero") && line.Contains("...") == false )
                {
                    line = reader.ReadLine();
                    if (line.Contains("ALWAYS") == false) { 
                        /* read through potential errors */
                        while ((line = reader.ReadLine()).Contains("ALWAYS") == false) { /*keep reading until line contains always*/}
                    }
                    int index = line.IndexOf("ALWAYS");
                    line = line.Substring(index + 8);

                    if ( line.Contains("Hero") && line.Contains("pawning") == false )
                    {
                        String[] components = line.Split(' ');
                        int compLength = components.Length;
                        champ = components[1];
                        if (components[1].Contains("(")) { String[] components2 = components[1].Split('('); champ = components2[0]; }

                        username = components[4];
                        if (compLength > 5)
                        {
                            for (int i = 5; i < compLength; i++)
                            {
                                username = username + " " + components[i];
                            }
                        }
                    }

                    System.Diagnostics.Debug.WriteLine(username + " is using " + champ);

                }
                else if (line.Contains("ALWAYS") && line.Contains("Hero") && line.Contains("created for"))
                {
                    int index = line.IndexOf("ALWAYS");
                    line = line.Substring(index + 8);

                    String[] components = line.Split(' ');
                    int compLength = components.Length;
                    champ = components[1];
                    if (components[1].Contains("(")) { String[] components2 = components[1].Split('('); champ = components2[0]; }

                    username = components[4];
                    if (compLength > 5)
                    {
                        for (int i = 5; i < compLength; i++)
                        {
                            username = username + " " + components[i];
                        }
                    }
                    System.Diagnostics.Debug.WriteLine(username + " is using " + champ);
                }
            }


        }

        return false;
    }
}
