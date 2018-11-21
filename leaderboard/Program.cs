using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leaderboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Deltager d1 = new Deltager("Ole", 100);
            Deltager d2 = new Deltager("Dole", 90);

            {
                Deltager d3 = new Deltager("Doffen", 103);
                Console.WriteLine(Plassering.printLeaderboard());

                d3.forsvinn();
            }

            Console.WriteLine(Plassering.printLeaderboard());
            Console.ReadKey();
        }
    }
    class Plassering : IComparable
    {
        public static List<Plassering> leaderboard = new List<Plassering>();
        private int tid;
        Deltager deltager;
        public Plassering(int tid, Deltager deltager)
        {
            this.deltager = deltager;
            this.tid = tid;
            leaderboard.Add(this);
        }
        public int GetTid()
        {
            return tid;
        }
        public int GetPlassering()
        {
            return leaderboard.IndexOf(this)+1;
        }
        
        public static string printLeaderboard()
        {
            leaderboard.Sort();
            string s = "";
            for(int i = 0; i < leaderboard.Count; i++)
            {
                s += leaderboard[i].GetPlassering() + ". " +
                    leaderboard[i].deltager.GetNavn() + " med " + leaderboard[i].GetTid() + " sekunder\n";
            }
            return s;
        }
        public void forsvinn()
        {
            leaderboard.Remove(this);
            deltager = null;
        }

        public int CompareTo(object obj)
        {
            Plassering p = obj as Plassering;
            if (this.GetTid() == p.GetTid())
            {
                return 0;
            }
            else if (this.GetTid() < p.GetTid())
            {
                return -1;
            }
            else return 1;

        }
    }
}
