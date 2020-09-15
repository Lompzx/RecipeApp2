using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Text;
using System.Runtime.CompilerServices;

namespace RecipeApp2.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public Color GetColorFromResources(string resourceName)
        {
            return (Color)Application.Current.Resources[resourceName];
        }

        /*
            var AlertColor = GetColorFromResources("AlertColor");
            var DangerColor = GetColorFromResources("DangerColor");
            var SuccessColor = GetColorFromResources("SuccessColor");
            var PrimaryColor = GetColorFromResources("PrimaryColor");
        */


        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
