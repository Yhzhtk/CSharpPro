using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LuckYicha
{
    class RankMode
    {
        public RankMode(string[] infos)
        {
            init(int.Parse(infos[0]), infos[1], infos[2], int.Parse(infos[3]));
        }

        public void init(int rank, string rankName, string rankGift, int rankAll)
        {
            this.rank = rank;
            this.rankName = rankName;
            this.rankGift = rankGift;
            this.rankAll = rankAll;
            rankNow = 0;
        }

        public int rank;

        public string rankName;

        public string rankGift;

        public int rankAll;

        public int rankNow;

        public List<string> rankPeople = new List<string>();

        private Hashtable seqPeople = new Hashtable();

        public Hashtable SeqPeople
        {
            get{
                seqPeople.Clear();
                foreach (string p in rankPeople)
                {
                    string area = (string)LuckForm.phoneArea[p];
                    if (seqPeople.Contains(area))
                    {
                        ((List<string>)seqPeople[area]).Add(p);
                    }
                    else
                    {
                        List<string> ps = new List<string>();
                        ps.Add(p);
                        seqPeople.Add(area, ps);
                    }
                }
                return seqPeople;
            }
        }
    }
}
