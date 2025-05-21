namespace IDF.model
{
    public class Idf
    {
        int DateOfEstablishment;
       private string _Commander;
        List<int> AttackTool;

        public  Idf(List<int> attackTool, string commander = "eyal zamir")
        {
            DateOfEstablishment = 10;
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
