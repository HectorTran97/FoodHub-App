using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodHub.ViewModel
{
    class OrderViewModel : INotifyPropertyChanged
    {
        //INotifyPropertyChanged implementation method   
        public event PropertyChangedEventHandler PropertyChanged;

        int _selectedSegement;
        public int SelectedSegment
        {
            get
            {
                return _selectedSegement;
            }
            set
            {
                _selectedSegement = value;
                switch (SelectedSegment)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                OnPropertyChanged("SelectedSegment");
            }
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
          
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FoodID { get; set; }
        public Uri FoodImage { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }

        public OrderViewModel(string foodID, string foodName, Uri foodImage, string foodDescription)
        {
            this.FoodID = foodID;
            this.FoodImage = foodImage;
            this.FoodName = foodName;
            this.FoodDescription = foodDescription;
        }
    }
}
