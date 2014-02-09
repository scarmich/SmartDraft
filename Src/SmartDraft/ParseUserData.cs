using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using SmartDraft;

public class ParseUserData
{
	public ParseUserData(){  }

    public bool parse(String[] users,ref List<SmartDraft.Champion> champlist){

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

            bool victory = false;
            String champPlayed = "";

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
                    victory = true;
                }
                else if (line.Contains("ALWAYS") && line.Contains("EXITCODE_LOSE"))
                {
                    victory = false;
                }
            }

            int champLocation = -1;

            /* determine champion played */
            foreach (String summName in users)
            {
                for (int i = 0; i < summoners.Count; i++)
                {
                    //MessageBox.Show(summName + " / " + summoners[i]);
                    if (summName.Equals(summoners[i])) { champLocation = i; champPlayed = champions[i]; }
                }
            }

            /* determine enemies */
            if (champLocation < (champions.Count / 2))
            {
                for (int i = champions.Count / 2; i < champions.Count; i++)
                {
                    if (victory) {
                        foreach( Champion hero in champlist ){
                            if(hero.getName() == champPlayed){
                                hero.updateWins(champions[i]);
                            }
                        }
                    }
                    else {
                        foreach (Champion hero in champlist)
                        {
                            if (hero.getName() == champPlayed)
                            {
                                hero.updateLosses(champions[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < champions.Count / 2; i++)
                {
                    if (victory)
                    {
                        foreach (Champion hero in champlist)
                        {
                            if (hero.getName() == champPlayed)
                            {
                                hero.updateWins(champions[i]);
                            }
                        }
                    }
                    else
                    {
                        foreach (Champion hero in champlist)
                        {
                            if (hero.getName() == champPlayed)
                            {
                                hero.updateLosses(champions[i]);
                            }
                        }
                    }
                }
            }

        }

        return true;
    }
}
