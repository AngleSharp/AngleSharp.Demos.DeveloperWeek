namespace AngleSharp.Demos.DeveloperWeek
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void TriggerChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
