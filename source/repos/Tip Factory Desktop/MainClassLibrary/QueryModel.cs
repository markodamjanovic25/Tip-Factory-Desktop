using System.Linq;
using System.Windows.Controls;

namespace MainClassLibrary
{
    public class QueryModel
    {
        public bool IsAnyLeagueSelected { get; private set; }

        private CheckBox[] checkBoxes;
        public CheckBox[] CheckBoxes { 
            get => checkBoxes;
            set { 
                checkBoxes = value;
                if (value.Any(x => x.IsChecked.Value))
                    IsAnyLeagueSelected = true;
            }
        }
        public bool IsEnglandIgnored { get; set; }
        public bool IsListExcluded { get; set; }
        public string ExcludedListNumber { get; set; }
        public string FavouriteSign { get; set; }
        public decimal FavouriteOdds { get; set; }
        public bool IsFourthShown { get; set; }
        public bool IsOver3GoalsOddsIncluded { get; set; }
        public decimal Over3GoalsOdds { get; set; }
        public bool IsFavouriteOddsApproximate { get; set; }
        public decimal FavouriteOddsRange { get; set; }

    }
}
