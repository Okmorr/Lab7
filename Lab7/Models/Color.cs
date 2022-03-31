using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab7.Models
{
    public class Item : INotifyPropertyChanged
    {
        string name;
        string color;
        string score;
        public event PropertyChangedEventHandler PropertyChanged;

        public Item(string _name, string _score = "0")
        {
            Name = _name;
            color = "OrangeRed";
            Score = _score;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetCScolor()
        {
            try
            {
                if (Convert.ToDouble(score) == 0)
                    Color = "OrangeRed";
                else if (Convert.ToDouble(score) == 1)
                    Color = "Yellow";
                else if (Convert.ToDouble(score) == 2)
                    Color = "LightGreen";
                else
                {
                    Color = "White";
                    score = "#ERROR";
                }
            }
            catch
            {
                Color = "White";
                score = "#ERROR";
            }
        }


        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value;
                NotifyPropertyChanged();
            }
        }

        public string Score
        {
            get => score;
            set
            {
                score = value;
                if (score != "" && score != "#ERROR")
                {
                    SetCScolor();
                }
                NotifyPropertyChanged();
            }
        }
    }
}