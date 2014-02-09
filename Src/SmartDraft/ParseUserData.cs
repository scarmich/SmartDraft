using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

public class ParseUserData
{
	public ParseUserData(){  }

    public bool parse(String[] users){

        LocateUserLogs locator = new LocateUserLogs();
        String filepath = locator.locate();

        String[] logs = Directory.GetFiles(filepath);

        foreach (String gamelog in logs)
        {
            /* open each file in the logs folder and parse the data */
            System.Diagnostics.Debug.WriteLine(gamelog);

            StreamReader reader = File.OpenText(gamelog);
            String line; String champ = ""; String username = "";

            List<String> champions = new List<String>();
            List<String> summoners = new List<String>();

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("ALWAYS") && line.Contains("Creating Hero") && line.Contains("...") == false)
                {
                    line = reader.ReadLine();
                    if (line.Contains("ALWAYS") == false)
                    {
                        /* read through potential errors */
                        while ((line = reader.ReadLine()).Contains("ALWAYS") == false) { /*keep reading until line contains always*/}
                    }
                    int index = line.IndexOf("ALWAYS");
                    line = line.Substring(index + 8);

                    if (line.Contains("Hero ") && line.Contains("pawning") == false)
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

                    champions.Add(champ);
                    summoners.Add(username);
                }
                else if (line.Contains("ALWAYS") && line.Contains("Hero ") && line.Contains("created for"))
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
                    champions.Add(champ);
                    summoners.Add(username);
                }
                else if (line.Contains("ALWAYS") && line.Contains("EXITCODE_WIN"))
                {

                }
                else if (line.Contains("ALWAYS") && line.Contains("EXITCODE_LOSE"))
                {

                }
            }

            int champLocation = -1;

            /* determine champion played */
            foreach (String summName in users)
            {
                for (int i = 0; i < summoners.Count; i++)
                {
                    if (summName.Equals(summoners[i])) { champLocation = i; System.Diagnostics.Debug.WriteLine("You played " + champions[i]); }
                }
            }

            /* determine enemies */
            if (champLocation < (champions.Count / 2))
            {
                for (int i = champions.Count / 2; i < champions.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Enemy is " + champions[i]);
                }
            }
            else
            {
                for (int i = 0; i < champions.Count / 2; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Enemy is " + champions[i]);
                }
            }

        }

        return false;
    }
}
