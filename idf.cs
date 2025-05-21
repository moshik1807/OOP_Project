namespace IDF.model
{
    public class Idf
    {
       public int DateOfEstablishment;
       private string _Commander;
       public List<int> AttackTool;

        public  Idf(List<int> attackTool, string commander = "eyal zamir")
        {
            DateOfEstablishment = 1948;
            _Commander = commander;
            AttackTool = attackTool;
        }
        public string Coommander
        {
            get { return _Commander; }
            set { _Commander = value; }
        }
        public void AddToAttackTool(int x)
        {
            AttackTool.Add(x);
        }
    }

}
