using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ThemeTest.Source
{
    public static class ThemeDictionaryHelper
    {
        private static Uri GetDictionaryPath(String dictionaryPath)
        {
            var uriString = String.Format("/ThemeTest;component{0}", dictionaryPath);
            return new Uri(uriString, UriKind.Relative);
        }

        public static ResourceDictionary GetThemeDictionaryByPath(String dictPath)
        {
            return new ResourceDictionary
            {
                Source = GetDictionaryPath(dictPath)
            };
        }
    }
}
