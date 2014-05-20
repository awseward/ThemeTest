using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using ThemeTest.Source;

namespace ThemeTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ViewModel.CcurrentThemeChanged += ViewModel_CcurrentThemeChanged;
        }

        void ViewModel_CcurrentThemeChanged(object sender, ViewModel.CurrentThemeChangedEventArgs e)
        {
            var oDictionaryPath = GetThemePath(e.OldTheme);
            var nDictionaryPath = GetThemePath(e.NewTheme);

            var oDictionary = ThemeDictionaryHelper.GetThemeDictionaryByPath(oDictionaryPath);
            var nDictionary = ThemeDictionaryHelper.GetThemeDictionaryByPath(nDictionaryPath);

            ReplaceResourceDictionary(oDictionary, nDictionary);
        }

        private String GetThemePath(Theme theme)
        {
            return String.Format("/Themes/ThemeTest.{0}.xaml", theme.ToString());
        }

        private void ReplaceResourceDictionary(ResourceDictionary oDictionary, ResourceDictionary nDictionary)
        {
            Resources.MergedDictionaries.Add(nDictionary);
            if (Resources.MergedDictionaries.Contains(oDictionary))
            {
                Resources.MergedDictionaries.Remove(oDictionary);
            }
        }
    }
}
