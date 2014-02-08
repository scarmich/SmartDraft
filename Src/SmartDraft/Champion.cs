using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDraft
{
    class Champion
    {
        string CHAMPNAME;
        int[] killsAgainst = new int[3];
        int[] deathsAgainst = new int[3];
        int[] winsAgainst = new int[3];
        int[] lossesAgainst = new int[3];
        string position;

        public Champion(string name,string position)
        {
            //do everything
            this.position = position;
        }
        public string getPos()
        {
            return position;
        }

    }
}
