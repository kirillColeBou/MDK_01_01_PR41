using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using TimeLord_MVVM_Тепляков.Modell;

namespace TimeLord_MVVM_Тепляков.ViewModell
{
    public class VMTimer : INotifyPropertyChanged
    {
        private Modell.Timer newModellTimer;
        private DispatcherTimer newTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };

        public VMTimer()
        {
            newModellTimer = new Modell.Timer() { Work = false, TimeTimer = 0 };
            newTimer.Tick += (s, e) => { TimeTimer--; if (newModellTimer.TimeTimer == 0) newTimer.Stop(); };
        }

        public int TimeTimer
        {
            get { return newModellTimer.TimeTimer; }
            set { if (value != newModellTimer.TimeTimer) { newModellTimer.TimeTimer = value; OnPropertyChanged(); TimeInContent = TimeSpan.FromSeconds(TimeTimer).ToString(@"hh\:mm\:ss"); } }
        }

        public string TimeInContent
        {
            get { return newModellTimer.TimeInContent; }
            set { if (value != newModellTimer.TimeInContent) { newModellTimer.TimeInContent = value; OnPropertyChanged(); } }
        }

        public bool IsTimerRunning
        {
            get { return newModellTimer.Work; }
            set { if (value != newModellTimer.Work) { newModellTimer.Work = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextButton)); } }
        }

        public string TextButton => IsTimerRunning ? "Стоп" : "Начать";
        private bool isTextBoxVisible = true;

        public bool IsTextBoxVisible
        {
            get { return isTextBoxVisible; }
            set { if (value != isTextBoxVisible) { isTextBoxVisible = value; OnPropertyChanged(); } }
        }

        public ICommand StartStopCommand => new RelayCommand(param =>
        {
            IsTimerRunning = !IsTimerRunning;
            if (IsTimerRunning)
            {
                newTimer.Start();
                IsTextBoxVisible = false;
            }
            else
            {
                newTimer.Stop();
                IsTextBoxVisible = true;
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

}
