using MainClassLibrary;
using MainClassLibrary.Models;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tip_Factory_Desktop.Util;

namespace Tip_Factory_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Match> previousMatches;
        List<Match> filteredMatches;
        string favourite = "";
        decimal favouriteOdds;

        public MainWindow()
        {
            InitializeComponent();
            previousMatches = new List<Match>();
            filteredMatches = new List<Match>();
        }

        private void Validate()
        {
            if (cbShowFourth.IsChecked.Value && (string.IsNullOrEmpty(tbHomeTeamWinnerOdds.Text) && string.IsNullOrEmpty(tbAwayTeamWinnerOdds.Text)))
                throw new Exception("Moras upisati kvotu na favorita jer je cekirana 4ta podela.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbOverOdds.Clear();
            tbHomeTeamWinnerOdds.Clear();
            tbDrawOdds.Clear();
            tbAwayTeamWinnerOdds.Clear();
            ClearPreviousMatches();
            tbTeamDomacinFilter.Text = "";
            tbTeamGostFilter.Text = "";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                ClearPreviousMatches();

                decimal.TryParse(tbOverOdds.Text, out decimal overOdds);
                decimal.TryParse(tbHomeTeamWinnerOdds.Text, out decimal homeTeamWinnerOdds);
                decimal.TryParse(tbAwayTeamWinnerOdds.Text, out decimal awayTeamWinnerOdds);

                var tpl = OddsUtilities.FindFavourite(homeTeamWinnerOdds, awayTeamWinnerOdds);
                if (tpl is (string fav, decimal odds))
                {
                    favourite = fav;
                    favouriteOdds = odds;
                }

                foreach (var item in SqliteDataAccess.GetMatches(GenerateQueryModel(overOdds)))
                    previousMatches.Add(DataGridUtilities.GenerateMatchData(item));

                matchesDG.ItemsSource = null;
                RefreshView(previousMatches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private QueryModel GenerateQueryModel(decimal overOdds)
        {
            return new QueryModel()
            {
                CheckBoxes = InitializeCheckboxes(),
                IsEnglandIgnored = cbIgnoreEngland.IsChecked.Value,
                IsListExcluded = cbExcludeList.IsChecked.Value,
                ExcludedListNumber = tbExcludeList.Text,
                FavouriteSign = favourite,
                FavouriteOdds = favouriteOdds,
                IsFourthShown = cbShowFourth.IsChecked.Value,
                IsOver3GoalsOddsIncluded = overOdds > 0,
                Over3GoalsOdds = overOdds,
                IsFavouriteOddsApproximate = cbPomeriFiks.IsChecked.Value,
                FavouriteOddsRange = Convert.ToDecimal(tbPomeriFiks.Text)
            };
        }

        private CheckBox[] InitializeCheckboxes()
        {
            var checkBoxes = new CheckBox[14];
            checkBoxes[0] = cbEngland1;
            checkBoxes[1] = cbGermany1;
            checkBoxes[2] = cbSpain1;
            checkBoxes[3] = cbItaly1;
            checkBoxes[4] = cbFrance1;
            checkBoxes[5] = cbBelgium1;
            checkBoxes[6] = cbPortugal1;
            checkBoxes[7] = cbNetherlands1;
            checkBoxes[8] = cbAustria1;
            checkBoxes[9] = cbDenmark1;
            checkBoxes[10] = cbSwitzerland1;
            checkBoxes[11] = cbEngland2;
            checkBoxes[12] = cbEngland3;
            checkBoxes[13] = cbEngland4;
            return checkBoxes;
        }

        

        private void RefreshView(List<Match> matches)
        {
            var stats = DataGridUtilities.GetPercentages(matches);
            matchesDG.ItemsSource = matches;
            statsGrid.DataContext = stats;
            statsSecondGrid.DataContext = stats;
            statsSiguriceGrid.DataContext = stats;
            tbMatchesCount.Text = "Broj utakmica: " + matches.Count;
        }

        private void ClearPreviousMatches()
        {
            previousMatches.Clear();
            filteredMatches.Clear();
            matchesDG.ItemsSource = null;
            favouriteOdds = 0;
            favourite = "";
        }

        private void SearchByTeam(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            if (previousMatches != null && previousMatches.Count >= 1 && (!string.IsNullOrEmpty(tbTeamDomacinFilter.Text) || !string.IsNullOrEmpty(tbTeamGostFilter.Text)))
            {
                string tbDomacinText = tbTeamDomacinFilter.Text.Length > 0 ? tbTeamDomacinFilter.Text + " " : null;
                string tbGostText = tbTeamGostFilter.Text.Length > 0 ? " " + tbTeamGostFilter.Text : null;

                if (!string.IsNullOrEmpty(tbDomacinText) && !string.IsNullOrEmpty(tbGostText))
                    filteredMatches = previousMatches.Where(x => x.Teams.ToLower().Contains(tbDomacinText.ToLower()) || x.Teams.ToLower().Contains(tbGostText.ToLower())).ToList();
                else if (!string.IsNullOrEmpty(tbDomacinText))
                    filteredMatches = previousMatches.Where(x => x.Teams.ToLower().Contains(tbDomacinText.ToLower())).ToList();
                else if (!string.IsNullOrEmpty(tbGostText))
                    filteredMatches = previousMatches.Where(x => x.Teams.ToLower().Contains(tbGostText.ToLower())).ToList();
                else
                    return;

                RefreshView(filteredMatches);
            }
            else
            {
                if (filteredMatches.Count > 0)
                    filteredMatches.Clear();

                RefreshView(previousMatches);
            }

        }

        private void PomeriFiks(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            if (previousMatches == null || previousMatches.Count < 1)
                return;
            if (favouriteOdds == 0)
                MessageBox.Show("Da bi pomerao fiks, mora da postoji kvota na favorita.");

            decimal pomeriFiks = Convert.ToDecimal((sender as TextBox).Text);

            var lowerOddsList = new List<decimal>();

            var higherOddsList = new List<decimal>();

            for (decimal i = 0; i <= pomeriFiks + (decimal)0.01; i += (decimal)0.01)
            {
                higherOddsList.Add(Math.Round((favouriteOdds + i), 2));
                lowerOddsList.Add(Math.Round((favouriteOdds - i), 2));
            }

            var list = new List<Match>();

            var sourceMatches = filteredMatches.Count > 0 ? filteredMatches : previousMatches;

            var oddsList = higherOddsList.Concat(lowerOddsList).ToList();

            foreach (decimal item in oddsList)
            {
                if (favourite == "D")
                    list.AddRange(sourceMatches.Where(x => x.HomeTeamWinOdds == item).ToList());
                else
                    list.AddRange(sourceMatches.Where(x => x.AwayTeamWinOdds == item).ToList());
            }


            RefreshView(list);
        }

        private void Matches_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                if (filteredMatches.Count > 0)
                    RefreshView(filteredMatches);
                else
                    RefreshView(previousMatches);
        }

    }
}
