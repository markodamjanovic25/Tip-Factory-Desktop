using MainClassLibrary.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tip_Factory_Desktop.Util
{
    public static class DataGridUtilities
    {

        public static Match GenerateMatchData(Match m)
        {
            SetBetOutcomes(ref m);
            return m;
        }

        private static void SetBetOutcomes(ref Match retVal)
        {
            if (retVal.HomeTeamTotalGoals > 0 && retVal.AwayTeamTotalGoals > 0)
                retVal.GGWin = "DA";
            else
                retVal.GGWin = "NE";

            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 2)
                retVal.Over3Win = "DA";
            else
                retVal.Over3Win = "NE";

            if (retVal.HomeTeamTotalGoals > 1)
                retVal.HomeOver2Win = "DA";
            else
                retVal.HomeOver2Win = "NE";

            if (retVal.HomeTeamTotalGoals > 2)
                retVal.HomeOver3Win = "DA";
            else
                retVal.HomeOver3Win = "NE";

            if (retVal.AwayTeamTotalGoals > 1)
                retVal.AwayOver2Win = "DA";
            else
                retVal.AwayOver2Win = "NE";

            if (retVal.AwayTeamTotalGoals > 2)
                retVal.AwayOver3Win = "DA";
            else
                retVal.AwayOver3Win = "NE";

            if (retVal.HomeTeamTotalGoals > 1 && retVal.AwayTeamTotalGoals > 1)
                retVal.BothTeamsOver2Win = "DA";
            else
                retVal.BothTeamsOver2Win = "NE";

            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0
                && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0)
                retVal.OnePlusOneWin = "DA";
            else
                retVal.OnePlusOneWin = "NE";

            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0
                && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1)
                retVal.OnePlusTwoWin = "DA";
            else
                retVal.OnePlusTwoWin = "NE";

            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1
                && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1)
                retVal.TwoPlusTwoWin = "DA";
            else
                retVal.TwoPlusTwoWin = "NE";

            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 3)
                retVal.Over4Win = "DA";
            else
                retVal.Over4Win = "NE";

            if (retVal.HomeTeamTotalGoals > 0 && retVal.AwayTeamTotalGoals > 0 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 2)
                retVal.BothTeamsToScoreAndOver3Win = "DA";
            else
                retVal.BothTeamsToScoreAndOver3Win = "NE";

            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1
                || GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1)
                retVal.FirstOrSecondHalfTwoWin = "DA";
            else
                retVal.FirstOrSecondHalfTwoWin = "NE";

            //0-1I
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 2)
                retVal.ZeroToOneFirstHalfWin = "DA";
            else
                retVal.ZeroToOneFirstHalfWin = "NE";

            //1+I
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0)
                retVal.Over1FirstHalfWin = "DA";
            else
                retVal.Over1FirstHalfWin = "NE";

            //1-2I
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0 && GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 3)
                retVal.OneToTwoFirstHalfWin = "DA";
            else
                retVal.OneToTwoFirstHalfWin = "NE";

            //1-3I
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0 && GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 4)
                retVal.OneToThreeFirstHalfWin = "DA";
            else
                retVal.OneToThreeFirstHalfWin = "NE";

            //2+I
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1)
                retVal.Over2FirstHalfWin = "DA";
            else
                retVal.Over2FirstHalfWin = "NE";

            //0-1II
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 2)
                retVal.ZeroToOneSecondHalfWin = "DA";
            else
                retVal.ZeroToOneSecondHalfWin = "NE";

            //1+II
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0)
                retVal.Over1SecondHalfWin = "DA";
            else
                retVal.Over1SecondHalfWin = "NE";

            //1-2II
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0
                && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 3)
                retVal.OneToTwoSecondHalfWin = "DA";
            else
                retVal.OneToTwoSecondHalfWin = "NE";

            //1-3II
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0
                && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 4)
                retVal.OneToThreeSecondHalfWin = "DA";
            else
                retVal.OneToThreeSecondHalfWin = "NE";

            //2+II
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 1)
                retVal.Over2SecondHalfWin = "DA";
            else
                retVal.Over2SecondHalfWin = "NE";

            //2+
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 1)
                retVal.Over2TotalWin = "DA";
            else
                retVal.Over2TotalWin = "NE";

            //2-3
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 1 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 4)
                retVal.TwoToThreeTotalWin = "DA";
            else
                retVal.TwoToThreeTotalWin = "NE";

            //2-4
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 1 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 5)
                retVal.TwoToFourTotalWin = "DA";
            else
                retVal.TwoToFourTotalWin = "NE";

            //2-5
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 1 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 6)
                retVal.TwoToFiveTotalWin = "DA";
            else
                retVal.TwoToFiveTotalWin = "NE";

            //2-6
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 1 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 7)
                retVal.TwoToSixTotalWin = "DA";
            else
                retVal.TwoToSixTotalWin = "NE";

            //0-1
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 2)
                retVal.ZeroToOneTotalWin = "DA";
            else
                retVal.ZeroToOneTotalWin = "NE";

            //0-2
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 3)
                retVal.ZeroToTwoTotalWin = "DA";
            else
                retVal.ZeroToTwoTotalWin = "NE";

            //0-3
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 4)
                retVal.ZeroToThreeTotalWin = "DA";
            else
                retVal.ZeroToThreeTotalWin = "NE";

            //1-3
            if (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) > 0 && GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) < 4)
                retVal.OneToThreeTotalWin = "DA";
            else
                retVal.OneToThreeTotalWin = "NE";

            //GG NE
            if (retVal.HomeTeamTotalGoals < 1 || retVal.AwayTeamTotalGoals < 1)
                retVal.GGNOWin = "DA";
            else
                retVal.GGNOWin = "NE";

            //d1+I
            if (retVal.HomeTeamHalfGoals > 0)
                retVal.HomeOver1FirstHalfWin = "DA";
            else
                retVal.HomeOver1FirstHalfWin = "NE";
            //d1+I
            if ((retVal.HomeTeamTotalGoals - retVal.HomeTeamHalfGoals) > 0)
                retVal.HomeOver1SecondHalfWin = "DA";
            else
                retVal.HomeOver1SecondHalfWin = "NE";

            //g1+I
            if (retVal.AwayTeamHalfGoals > 0)
                retVal.AwayOver1FirstHalfWin = "DA";
            else
                retVal.AwayOver1FirstHalfWin = "NE";
            //g1+I
            if ((retVal.AwayTeamTotalGoals - retVal.AwayTeamHalfGoals) > 0)
                retVal.AwayOver1SecondHalfWin = "DA";
            else
                retVal.AwayOver1SecondHalfWin = "NE";

            //0-1 prvo i 1+ drugo
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) < 2 && (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals)) > 0)
                retVal.Under2FirstAndOver1SecondWin = "DA";
            else
                retVal.Under2FirstAndOver1SecondWin = "NE";

            //1+ prvo i 0-1 drugo
            if (GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals) > 0 && (GetTotalGoals(retVal.HomeTeamTotalGoals, retVal.AwayTeamTotalGoals) - GetFirstHalfGoals(retVal.HomeTeamHalfGoals, retVal.AwayTeamHalfGoals)) < 2)
                retVal.Over1FirstAndUnder2SecondWin = "DA";
            else
                retVal.Over1FirstAndUnder2SecondWin = "NE";
        }

        public static int GetFirstHalfGoals(int homeTeam, int awayTeam)
        {
            return homeTeam + awayTeam;
        }

        public static int GetTotalGoals(int homeTeam, int awayTeam)
        {
            return homeTeam + awayTeam;
        }

        public static PercentageCalculator GetPercentages(List<Match> matches)
        {
            var calculator = new PercentageCalculator();

            calculator.TotalMatches         =    matches.Count;
            calculator.GGWins               =    matches.Where(x => x.GGWin == "DA").Count();
            calculator.Over3Wins            =    matches.Where(x => x.Over3Win == "DA").Count();
            calculator.HomeOver2Wins        =    matches.Where(x => x.HomeOver2Win == "DA").Count();
            calculator.HomeOver3Wins        =    matches.Where(x => x.HomeOver3Win == "DA").Count();
            calculator.AwayOver2Wins        =    matches.Where(x => x.AwayOver2Win == "DA").Count();
            calculator.AwayOver3Wins        =    matches.Where(x => x.AwayOver3Win == "DA").Count();
            calculator.BothTeamsOver2Wins   =    matches.Where(x => x.BothTeamsOver2Win == "DA").Count();
            calculator.OnePlusOneWins       =    matches.Where(x => x.OnePlusOneWin == "DA").Count();
            calculator.OnePlusTwoWins       =    matches.Where(x => x.OnePlusTwoWin == "DA").Count();
            calculator.TwoPlusTwoWins       =    matches.Where(x => x.TwoPlusTwoWin == "DA").Count();
            calculator.Over2FirstHalfWins   =    matches.Where(x => x.Over2FirstHalfWin == "DA").Count();
            calculator.Over2SecondHalfWins  =    matches.Where(x => x.Over2SecondHalfWin == "DA").Count();
            calculator.Over4Wins            =    matches.Where(x => x.Over4Win == "DA").Count();
            calculator.BothTeamsToScoreAndOver3Wins = matches.Where(x => x.BothTeamsToScoreAndOver3Win == "DA").Count();
            calculator.FirstOrSecondHalfTwoWins = matches.Where(x => x.FirstOrSecondHalfTwoWin == "DA").Count();

            calculator.ZeroToOneFirstHalfWins = matches.Where(x => x.ZeroToOneFirstHalfWin == "DA").Count();
            calculator.Over1FirstHalfWins = matches.Where(x => x.Over1FirstHalfWin == "DA").Count();
            calculator.OneToTwoFirstHalfWins = matches.Where(x => x.OneToTwoFirstHalfWin == "DA").Count();
            calculator.OneToThreeFirstHalfWins = matches.Where(x => x.OneToThreeFirstHalfWin == "DA").Count();
            calculator.Over2FirstHalfWins = matches.Where(x => x.Over2FirstHalfWin == "DA").Count();

            calculator.ZeroToOneSecondHalfWins = matches.Where(x => x.ZeroToOneSecondHalfWin == "DA").Count();
            calculator.Over1SecondHalfWins = matches.Where(x => x.Over1SecondHalfWin == "DA").Count();
            calculator.OneToTwoSecondHalfWins = matches.Where(x => x.OneToTwoSecondHalfWin == "DA").Count();
            calculator.OneToThreeSecondHalfWins = matches.Where(x => x.OneToThreeSecondHalfWin == "DA").Count();
            calculator.Over2SecondHalfWins = matches.Where(x => x.Over2SecondHalfWin == "DA").Count();

            calculator.Over2TotalWins = matches.Where(x => x.Over2TotalWin == "DA").Count();
            calculator.TwoToThreeTotalWins = matches.Where(x => x.TwoToThreeTotalWin == "DA").Count();
            calculator.TwoToFourTotalWins = matches.Where(x => x.TwoToFourTotalWin == "DA").Count();
            calculator.TwoToFiveTotalWins = matches.Where(x => x.TwoToFiveTotalWin == "DA").Count();
            calculator.TwoToSixTotalWins = matches.Where(x => x.TwoToSixTotalWin == "DA").Count();

            calculator.ZeroToOneTotalWins = matches.Where(x => x.ZeroToOneTotalWin == "DA").Count();
            calculator.ZeroToTwoTotalWins = matches.Where(x => x.ZeroToTwoTotalWin == "DA").Count();
            calculator.ZeroToThreeTotalWins = matches.Where(x => x.ZeroToThreeTotalWin == "DA").Count();
            calculator.OneToThreeTotalWins = matches.Where(x => x.OneToThreeTotalWin == "DA").Count();
            calculator.GGNOWins = matches.Where(x => x.GGNOWin == "DA").Count();

            calculator.HomeOver1FirstHalfWins = matches.Where(x => x.HomeOver1FirstHalfWin == "DA").Count();
            calculator.HomeOver1SecondHalfWins = matches.Where(x => x.HomeOver1SecondHalfWin == "DA").Count();
            calculator.AwayOver1FirstHalfWins = matches.Where(x => x.AwayOver1FirstHalfWin == "DA").Count();
            calculator.AwayOver1SecondHalfWins = matches.Where(x => x.AwayOver1SecondHalfWin == "DA").Count();

            calculator.Under2FirstAndOver1SecondWins = matches.Where(x => x.Under2FirstAndOver1SecondWin == "DA").Count();
            calculator.Over1FirstAndUnder2SecondWins = matches.Where(x => x.Over1FirstAndUnder2SecondWin == "DA").Count();

            return calculator;
        }
    }
}
