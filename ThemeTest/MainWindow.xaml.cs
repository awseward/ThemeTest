using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThemeTest.Source;

namespace ThemeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cycle_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CycleTheme();
            SpeechHelper.Say(String.Format("This is a test of the {0} theme", _viewModel.CurrentTheme.ToString()));
        }

        private void Party_Checked(object sender, RoutedEventArgs e)
        {
            _viewModel.Party();
            SpeechHelper.Party();
        }

        private void Party_Unchecked(object sender, RoutedEventArgs e)
        {
            _viewModel.StopPartying();
            SpeechHelper.StopPartying();
        }

        private void Wayne_Click(object sender, RoutedEventArgs e)
        {
            SpeechHelper.Say("Party on Garth!");
        }

        private void Garth_Click(object sender, RoutedEventArgs e)
        {
            SpeechHelper.Say("Party on Wayne!");
        }
    }
}
