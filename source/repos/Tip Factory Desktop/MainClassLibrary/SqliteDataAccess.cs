using Dapper;
using MainClassLibrary.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Text;

namespace MainClassLibrary
{
    public class SqliteDataAccess
    {
        private static string SQL_MAIN = "select * from Match where 1=1";
        private static string SQL_LEAGUE_NOT_ENGLAND = " and LeagueId not in (12, 13, 14) ";
        private static string SQL_EXCLUDE_LIST = " and ListNumber != ";
        private static string SQL_ORDER_BY_HOME_WIN = " order by HomeTeamWinOdds";
        private static string SQL_ORDER_BY_AWAY_WIN = " order by AwayTeamWinOdds";

        private static string LoadConnectionString(string id = "TFUltraSQLite") => ConfigurationManager.ConnectionStrings[id].ConnectionString;

        public static List<Match> GetMatches(QueryModel queryModel)
        {
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                var query = new StringBuilder(SQL_MAIN);

                if (queryModel.IsAnyLeagueSelected)
                    query.Append($" and LeagueId in ({SqliteQueryHelper.GetLeaguesCondition(queryModel.CheckBoxes)})");

                if (queryModel.IsEnglandIgnored)
                    query.Append(SQL_LEAGUE_NOT_ENGLAND);

                if (queryModel.IsListExcluded)
                    query.Append(SQL_EXCLUDE_LIST).Append($"'{queryModel.ExcludedListNumber}'");

                if (queryModel.IsOver3GoalsOddsIncluded)
                    query.Append($" and Over3GoalsOdds = {queryModel.Over3GoalsOdds}");

                if (queryModel.FavouriteSign == "D")
                {
                    query.Append(" and HomeTeamWinOdds <= AwayTeamWinOdds");

                    if (queryModel.IsFavouriteOddsApproximate)
                    {
                        decimal minValue = queryModel.FavouriteOdds - queryModel.FavouriteOddsRange;
                        decimal maxValue = queryModel.FavouriteOdds + queryModel.FavouriteOddsRange;
                        query.Append($" and HomeTeamWinOdds >= {minValue} and HomeTeamWinOdds <= {maxValue}");
                    }
                    else if (queryModel.IsFourthShown)
                    {
                        char firstDigit = queryModel.FavouriteOdds.ToString("#.00")[0];
                        char secondDigit = queryModel.FavouriteOdds.ToString("#.00")[2];
                        query.Append($" and SUBSTRING(CAST(HomeTeamWinOdds as NVARCHAR(20)), 1, 1) = '{firstDigit}'");
                        query.Append($" and SUBSTRING(CAST(HomeTeamWinOdds as NVARCHAR(20)), 3, 1) = '{secondDigit}'");
                    }
                    else
                    {
                        query.Append($" and HomeTeamWinOdds = {queryModel.FavouriteOdds}");
                    }
                }
                else if (queryModel.FavouriteSign == "G")
                {
                    query.Append(" and AwayTeamWinOdds <= HomeTeamWinOdds");

                    if (queryModel.IsFavouriteOddsApproximate)
                    {
                        decimal minValue = queryModel.FavouriteOdds - queryModel.FavouriteOddsRange;
                        decimal maxValue = queryModel.FavouriteOdds + queryModel.FavouriteOddsRange;
                        query.Append($" and AwayTeamWinOdds >= {minValue} and AwayTeamWinOdds <= {maxValue}");
                    }
                    else if (queryModel.IsFourthShown)
                    {
                        char firstDigit = queryModel.FavouriteOdds.ToString("#.00")[0];
                        char secondDigit = queryModel.FavouriteOdds.ToString("#.00")[2];
                        query.Append($" and SUBSTRING(CAST(AwayTeamWinOdds as NVARCHAR(20)), 1, 1) = '{firstDigit}'");
                        query.Append($" and SUBSTRING(CAST(AwayTeamWinOdds as NVARCHAR(20)), 3, 1) = '{secondDigit}'");
                    }
                    else
                    {
                        query.Append($" and AwayTeamWinOdds = {queryModel.FavouriteOdds}");
                    }
                }

                if (queryModel.FavouriteSign == "D")
                    query.Append(SQL_ORDER_BY_HOME_WIN);
                else if (queryModel.FavouriteSign == "G")
                    query.Append(SQL_ORDER_BY_AWAY_WIN);
                else
                    query.Append(SQL_ORDER_BY_HOME_WIN);

                var matches = connection.Query<Match>(query.ToString()).ToList();
                return matches;
            }
        }
    }
}
