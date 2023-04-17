
namespace MainClassLibrary.Models
{
    public class PercentageCalculator
    {
        private double _ggWins;
        public double GGWins 
        { 
            get => _ggWins / TotalMatches * 100;  
            set => _ggWins = value; 
        }

        private double _over3Wins;
        public double Over3Wins 
        { 
            get => _over3Wins / TotalMatches * 100;  
            set => _over3Wins = value;  
        }

        private double _homeOver2Wins;
        public double HomeOver2Wins 
        { 
            get => _homeOver2Wins / TotalMatches * 100;  
            set => _homeOver2Wins = value;  
        }
        private double _homeOver3Wins;
        public double HomeOver3Wins
        {
            get => _homeOver3Wins / TotalMatches * 100;
            set => _homeOver3Wins = value;
        }

        private double _awayOver2Wins;
        public double AwayOver2Wins 
        { 
            get =>  _awayOver2Wins / TotalMatches * 100;  
            set => _awayOver2Wins = value;  
        }
        private double _awayOver3Wins;
        public double AwayOver3Wins
        {
            get => _awayOver3Wins / TotalMatches * 100;
            set => _awayOver3Wins = value;
        }

        private double _bothTeamsOver2Wins;
        public double BothTeamsOver2Wins
        {
            get => _bothTeamsOver2Wins / TotalMatches * 100;
            set => _bothTeamsOver2Wins = value;
        }

        private double _onePlusOneWins;
        public double OnePlusOneWins 
        { 
            get => _onePlusOneWins / TotalMatches * 100;  
            set => _onePlusOneWins = value; 
        }

        private double _onePlusTwoWins;
        public double OnePlusTwoWins
        {
            get => _onePlusTwoWins / TotalMatches * 100;
            set => _onePlusTwoWins = value;
        }

        private double _twoPlusTwoWins;
        public double TwoPlusTwoWins
        {
            get => _twoPlusTwoWins / TotalMatches * 100;
            set => _twoPlusTwoWins = value;
        }

        private double _over4Wins;
        public double Over4Wins 
        { 
            get => _over4Wins / TotalMatches * 100; 
            set => _over4Wins = value; 
        }

        private double _bothTeamsToScoreAndOver3Wins;
        public double BothTeamsToScoreAndOver3Wins
        {
            get => _bothTeamsToScoreAndOver3Wins / TotalMatches * 100;
            set => _bothTeamsToScoreAndOver3Wins = value;
        }

        private double _firstOrSecondHalfTwoWins;
        public double FirstOrSecondHalfTwoWins
        {
            get => _firstOrSecondHalfTwoWins / TotalMatches * 100;
            set => _firstOrSecondHalfTwoWins = value;
        }

        private double _zeroToOneFirstHalfWins;
        public double ZeroToOneFirstHalfWins
        {
            get => _zeroToOneFirstHalfWins / TotalMatches * 100;
            set => _zeroToOneFirstHalfWins = value;
        }
        private double _over1FirstHalfWins;
        public double Over1FirstHalfWins
        {
            get => _over1FirstHalfWins / TotalMatches * 100;
            set => _over1FirstHalfWins = value;
        }
        private double _oneToTwoFirstHalfWins;
        public double OneToTwoFirstHalfWins
        {
            get => _oneToTwoFirstHalfWins / TotalMatches * 100;
            set => _oneToTwoFirstHalfWins = value;
        }
        private double _oneToThreeFirstHalfWins;
        public double OneToThreeFirstHalfWins
        {
            get => _oneToThreeFirstHalfWins / TotalMatches * 100;
            set => _oneToThreeFirstHalfWins = value;
        }
        private double _over2FirstHalfWins;
        public double Over2FirstHalfWins
        {
            get => _over2FirstHalfWins / TotalMatches * 100;
            set => _over2FirstHalfWins = value;
        }

        private double _zeroToOneSecondHalfWins;
        public double ZeroToOneSecondHalfWins
        {
            get => _zeroToOneSecondHalfWins / TotalMatches * 100;
            set => _zeroToOneSecondHalfWins = value;
        }
        private double _over1SecondHalfWins;
        public double Over1SecondHalfWins
        {
            get => _over1SecondHalfWins / TotalMatches * 100;
            set => _over1SecondHalfWins = value;
        }
        private double _oneToTwoSecondHalfWins;
        public double OneToTwoSecondHalfWins
        {
            get => _oneToTwoSecondHalfWins / TotalMatches * 100;
            set => _oneToTwoSecondHalfWins = value;
        }
        private double _oneToThreeSecondHalfWins;
        public double OneToThreeSecondHalfWins
        {
            get => _oneToThreeSecondHalfWins / TotalMatches * 100;
            set => _oneToThreeSecondHalfWins = value;
        }
        private double _over2SecondHalfWins;
        public double Over2SecondHalfWins
        {
            get => _over2SecondHalfWins / TotalMatches * 100;
            set => _over2SecondHalfWins = value;
        }
        //
        private double _over2TotalWins;
        public double Over2TotalWins
        {
            get => _over2TotalWins / TotalMatches * 100;
            set => _over2TotalWins = value;
        }
        private double _twoToThreeTotalWins;
        public double TwoToThreeTotalWins
        {
            get => _twoToThreeTotalWins / TotalMatches * 100;
            set => _twoToThreeTotalWins = value;
        }
        private double _twoToFourTotalWins;
        public double TwoToFourTotalWins
        {
            get => _twoToFourTotalWins / TotalMatches * 100;
            set => _twoToFourTotalWins = value;
        }
        private double _twoToFiveTotalWins;
        public double TwoToFiveTotalWins
        {
            get => _twoToFiveTotalWins / TotalMatches * 100;
            set => _twoToFiveTotalWins = value;
        }
        private double _twoToSixTotalWins;
        public double TwoToSixTotalWins
        {
            get => _twoToSixTotalWins / TotalMatches * 100;
            set => _twoToSixTotalWins = value;
        }

        private double _zeroToOneTotalWins;
        public double ZeroToOneTotalWins
        {
            get => _zeroToOneTotalWins / TotalMatches * 100;
            set => _zeroToOneTotalWins = value;
        }
        private double _zeroToTwoTotalWins;
        public double ZeroToTwoTotalWins
        {
            get => _zeroToTwoTotalWins / TotalMatches * 100;
            set => _zeroToTwoTotalWins = value;
        }
        private double _zeroToThreeTotalWins;
        public double ZeroToThreeTotalWins
        {
            get => _zeroToThreeTotalWins / TotalMatches * 100;
            set => _zeroToThreeTotalWins = value;
        }
        private double _oneToThreeTotalWins;
        public double OneToThreeTotalWins
        {
            get => _oneToThreeTotalWins / TotalMatches * 100;
            set => _oneToThreeTotalWins = value;
        }
        private double _gGNOWins;
        public double GGNOWins
        {
            get => _gGNOWins / TotalMatches * 100;
            set => _gGNOWins = value;
        }

        private double _homeOver1FirstHalfWins;
        public double HomeOver1FirstHalfWins
        {
            get => _homeOver1FirstHalfWins / TotalMatches * 100;
            set => _homeOver1FirstHalfWins = value;
        }

        private double _homeOver1SecondHalfWins;
        public double HomeOver1SecondHalfWins
        {
            get => _homeOver1SecondHalfWins / TotalMatches * 100;
            set => _homeOver1SecondHalfWins = value;
        }

        private double _awayOver1FirstHalfWins;
        public double AwayOver1FirstHalfWins
        {
            get => _awayOver1FirstHalfWins / TotalMatches * 100;
            set => _awayOver1FirstHalfWins = value;
        }

        private double _awayOver1SecondHalfWins;
        public double AwayOver1SecondHalfWins
        {
            get => _awayOver1SecondHalfWins / TotalMatches * 100;
            set => _awayOver1SecondHalfWins = value;
        }

        private double _under2FirstAndOver1SecondWins;
        public double Under2FirstAndOver1SecondWins
        {
            get => _under2FirstAndOver1SecondWins / TotalMatches * 100;
            set => _under2FirstAndOver1SecondWins = value;
        }

        private double _over1FirstAndUnder2SecondWins;
        public double Over1FirstAndUnder2SecondWins
        {
            get => _over1FirstAndUnder2SecondWins / TotalMatches * 100;
            set => _over1FirstAndUnder2SecondWins = value;
        }


        public int TotalMatches { get; set; }
    }
}
