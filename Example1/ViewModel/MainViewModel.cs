using Example1.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Example1.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        Server server;
        Client client;
        private ObservableCollection<Entry> historyList;

        public ObservableCollection<Entry> HistoryList
        {
            get { return historyList; }
            set { historyList = value; RaisePropertyChanged(); }
        }


        public RelayCommand<int> ToggleButtonClicked { get; set; }
        public RelayCommand ListenButtonClicked { get; set; }
        public RelayCommand ConnectButtonClicked { get; set; }

        public int Circle1 { get; set; }
        public int Circle2 { get; set; }
        public int Circle3 { get; set; }
        public int Circle4 { get; set; }

        public int CircleColor1 { get; set; }
        public int CircleColor2 { get; set; }
        public int CircleColor3 { get; set; }
        public int CircleColor4 { get; set; }

        private bool toggleEnabled;

        public bool ToggleEnabled
        {
            get { return toggleEnabled; }
            set { toggleEnabled = value; RaisePropertyChanged(); }
        }



        public MainViewModel()
        {
            Circle1 = 1;
            Circle2 = 2;
            Circle3 = 3;
            Circle4 = 4;

            ToggleEnabled = false;
            HistoryList = new ObservableCollection<Entry>();

            ToggleButtonClicked = new RelayCommand<int>((p) =>
            {
                Entry newEntry = new Entry();
                newEntry.ButtonId = p;
                newEntry.Timestamp = DateTime.Now;

                switch (p)
                {
                    case 1:
                        if (CircleColor1 == 0)
                        {
                            CircleColor1 = 1;
                            newEntry.ColorChangedTo = "Green";
                        }
                        else
                        {
                            CircleColor1 = 0;
                            newEntry.ColorChangedTo = "Red";
                        }
                        RaisePropertyChanged("CircleColor1");
                        break;
                    case 2:
                        if (CircleColor2 == 0)
                        {
                            CircleColor2 = 1;
                            newEntry.ColorChangedTo = "Green";
                        }
                        else
                        {
                            CircleColor2 = 0;
                            newEntry.ColorChangedTo = "Red";
                        }
                        RaisePropertyChanged("CircleColor2");
                        break;
                    case 3:
                        if (CircleColor3 == 0)
                        {
                            CircleColor3 = 1;
                            newEntry.ColorChangedTo = "Green";
                        }
                        else
                        {
                            CircleColor3 = 0;
                            newEntry.ColorChangedTo = "Red";
                        }
                        RaisePropertyChanged("CircleColor3");
                        break;
                    case 4:
                    
                        if (CircleColor4 == 0)
                        {
                            CircleColor4 = 1;
                            newEntry.ColorChangedTo = "Green";
                        }
                        else
                        {
                            CircleColor4 = 0;
                            newEntry.ColorChangedTo = "Red";
                        }
                        RaisePropertyChanged("CircleColor4");
                        break;
                    default:
                        break;
                }
                HistoryList.Add(newEntry);
            }, (p)=> { return ToggleEnabled; });

            ListenButtonClicked = new RelayCommand(() =>
            {
                ToggleEnabled = true;
                server = new Server();
            });

            ConnectButtonClicked = new RelayCommand(() =>
            {
                ToggleEnabled = false;
                server = new Server();
                client = new Client();
            });

            CircleColor1 = CircleColor3 = 1;
            CircleColor2 = CircleColor4 = 0;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                
            }
        }
    }
}