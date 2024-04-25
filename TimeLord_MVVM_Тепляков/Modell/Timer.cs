using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimeLord_MVVM_Тепляков.ViewModell;

namespace TimeLord_MVVM_Тепляков.Modell
{
    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private int timeTimer;

        public int TimeTimer
        {
            get { return timeTimer; }
            set
            {
                if (value != timeTimer)
                {
                    timeTimer = value;
                    OnPropertyChanged();
                }
            }
        }

        private string timeInContent;

        public string TimeInContent
        {
            get { return timeInContent; }
            set
            {
                if (value != timeInContent)
                {
                    timeInContent = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool work;

        public bool Work
        {
            get { return work; }
            set
            {
                if (value != work)
                {
                    work = value;
                    OnPropertyChanged();
                }
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                if (value != content)
                {
                    content = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}