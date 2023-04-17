using System;

namespace Tip_Factory_Desktop.Util
{
    public static class OddsUtilities
    {
        public static Tuple<string, decimal> FindFavourite(decimal homeTeamWinnerOdds, decimal awayTeamWinnerOdds)
        {
            if (homeTeamWinnerOdds == 0 && awayTeamWinnerOdds == 0)
                return null;

            if (homeTeamWinnerOdds > 0 && awayTeamWinnerOdds == 0)
                return Tuple.Create("D", homeTeamWinnerOdds);
            else if (awayTeamWinnerOdds > 0 && homeTeamWinnerOdds == 0)
                return Tuple.Create("G", awayTeamWinnerOdds);
            else
                return (homeTeamWinnerOdds < awayTeamWinnerOdds) ? Tuple.Create("D", homeTeamWinnerOdds) : Tuple.Create("G", awayTeamWinnerOdds);
        }
    }
}
