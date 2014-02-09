using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace SmartDraft
{
    class Champion
    {
        string name;
        int[] winsAgainst = new int[3];
        int[] lossesAgainst = new int[3];
        string position;

        OrderedDictionary dictwinsagainst = new OrderedDictionary();
        OrderedDictionary dictlossesagainst = new OrderedDictionary();

        public Champion(string name)
        {
            dictwinsagainst.Add(name,0);
            dictlossesagainst.Add(name,0);
        }

        public string getPos()
        {
            return position;
        }

    }
}
