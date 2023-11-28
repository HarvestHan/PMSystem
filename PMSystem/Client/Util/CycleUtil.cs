namespace PMSystem.Client.Util
{
    public class CycleUtil
    {
        public static List<string> GetYears()
        {
            List<string> years = new List<string>();
            int currentYear = int.Parse(DateTime.Now.ToString("yyyy"));
            for (int i = 0; i < 50; i++)
            {
                years.Add((currentYear + i).ToString());
            }
            return years;
        }
    }
}
