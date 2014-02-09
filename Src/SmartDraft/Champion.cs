using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace SmartDraft
{
    public class Champion
    {
        string name;
        int[] winsAgainst = new int[3];
        int[] lossesAgainst = new int[3];
        string position;

        Dictionary<String, int> dictwinsagainst = new Dictionary<String, int>();
        Dictionary<String, int> dictlossesagainst = new Dictionary<String, int>();

        public Champion(string name, string pos)  //actual champ
        {
            this.name = name;
            this.position = pos;
        }
        public void updateWins(string name) //enemy champ
        {
            if(!dictwinsagainst.ContainsKey(name)){
                dictwinsagainst.Add(name,0);
                dictwinsagainst[name] = dictwinsagainst[name] + 1;
            }
            else
            {
                dictwinsagainst[name] = dictwinsagainst[name] + 1;
            }

        }
        public void updateLosses(string name) //enemy champ
        {
            if (!dictlossesagainst.ContainsKey(name))
            {
                dictlossesagainst.Add(name, 0);
                dictlossesagainst[name] = dictlossesagainst[name] + 1;
            }
            else
            {
                dictlossesagainst[name] = dictlossesagainst[name] + 1;
            }
        }
        public string getName()
        {
            return this.name;

        }
        public string getPos()
        {
            return position;
        }
        public double lookUpWinRate(string enemy)
        {
            return dictwinsagainst[enemy]/dictlossesagainst[enemy];
        }
    }
}
