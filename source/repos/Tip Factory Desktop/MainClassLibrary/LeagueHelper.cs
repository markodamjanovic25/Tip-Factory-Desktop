namespace MainClassLibrary
{
    public class LeagueHelper
    {
        public static int GetLeagueId(string leagueName)
        {
            switch (leagueName)
            {
                case "England1":
                    return 1;
                case "Germany1":
                    return 2;
                case "Spain1":
                    return 3;
                case "Italy1":
                    return 4;
                case "France1":
                    return 5;
                case "Belgium1":
                    return 6;
                case "Portugal1":
                    return 7;
                case "Netherlands1":
                    return 8;
                case "Austria1":
                    return 9;
                case "Denmark1":
                    return 10;
                case "Switzerland1":
                    return 11;
                case "England2":
                    return 12;
                case "England3":
                    return 13;
                case "England4":
                    return 14;
                default:
                    return 0;
            }
        }
    }
}
