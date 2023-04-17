using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MainClassLibrary
{
    public static class SqliteQueryHelper
    {
        public static string GetLeaguesCondition(CheckBox[] checkBoxes)
        {
            string retVal = "";
            foreach (var item in checkBoxes)
                if (item.IsChecked == true)
                    retVal += LeagueHelper.GetLeagueId(item.Content.ToString()) + ", ";

            retVal = retVal.Remove(retVal.Length - 2);
            return retVal;
        }
    }
}
