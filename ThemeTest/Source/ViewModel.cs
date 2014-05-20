using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThemeTest.Source
{
    public enum Theme { Light, Dark, Red, Orange, Yellow, Green, Blue, Purple };
    
    public class ViewModel : INotifyPropertyChanged
    {
        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged == null) { return; }
            
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public static event CurrentThemeChangedEventHandler CcurrentThemeChanged;

        private static void OnCcurrentThemeChanged(Theme oTheme, Theme nTheme)
        {
            if (CcurrentThemeChanged == null) { return; }

            var args = new CurrentThemeChangedEventArgs(oTheme, nTheme);
            CcurrentThemeChanged(null, args);
        }

        public delegate void CurrentThemeChangedEventHandler(Object sender, CurrentThemeChangedEventArgs e);

        public class CurrentThemeChangedEventArgs : EventArgs
        {
            public Theme OldTheme { get; private set; }
            public Theme NewTheme { get; private set; }

            public CurrentThemeChangedEventArgs(Theme oTheme, Theme nTheme)
            {
                OldTheme = oTheme;
                NewTheme = nTheme;
            }
        }

        private Theme _currentTheme = Theme.Light;

        public Theme CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                if (value != _currentTheme)
                {
                    var oTheme = _currentTheme;
                    var nTheme = value;
                    _currentTheme = value;
                    OnPropertyChanged("CurrentTheme");
                    OnCcurrentThemeChanged(oTheme, nTheme);
                }
            }
        }

        public void CycleTheme()
        {
            Int32 themeCount = Enum.GetNames(typeof(Theme)).Length;
            Int32 currentIndex = (Int32) CurrentTheme;
            Int32 nextIndex = (currentIndex + 1) % themeCount;
            CurrentTheme = (Theme) nextIndex;
        }

        private BackgroundWorker _partyWorker;

        public void Party()
        {
            _partyWorker = new BackgroundWorker();
            _partyWorker.WorkerSupportsCancellation = true;
            _partyWorker.DoWork += partyWorker_DoWork;

            _partyWorker.RunWorkerAsync();
        }

        private void partyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker partyWorker = (BackgroundWorker) sender;
            
            while (!partyWorker.CancellationPending)
            {
                CycleTheme();
                Thread.Sleep(20);
            }

            e.Cancel = true;
        }

        public void StopPartying()
        {
            BackgroundWorker partyWorker = _partyWorker;
            _partyWorker = null;
            partyWorker.CancelAsync();
        }
    }
}
