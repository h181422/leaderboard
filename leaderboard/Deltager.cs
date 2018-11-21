namespace leaderboard
{
    class Deltager
    {
        Plassering plassering;
        private string navn;
        public Deltager(string navn, int tid)
        {
            this.plassering = new Plassering(tid, this);
            this.navn = navn;
        }
        public string GetNavn()
        {
            return navn;
        }
        public void forsvinn()
        {
            if(plassering != null)
            {
                plassering.forsvinn();
                plassering = null;
            }
        }
    }
}
