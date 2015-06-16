using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AngleSharp.Demos.DeveloperWeek
{
    sealed class MainViewModel : BaseViewModel
    {
        String _content;
        String _address;
        String _userName;
        String _password;
        String _selector;

        public MainViewModel()
        {
            Submit = new RelayCommand(ExecuteSubmit);
            Navigate = new RelayCommand(ExecuteNavigate);
        }

        public String Content
        {
            get { return _content; }
            private set { _content = value; TriggerChanged(); }
        }

        public String Address
        {
            get { return _address; }
            private set { _address = value; TriggerChanged(); }
        }

        public String Selector
        {
            get { return _selector; }
            set { _selector = value; TriggerChanged(); }
        }

        public String Username
        {
            get { return _userName; }
            set { _userName = value; TriggerChanged(); }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; TriggerChanged(); }
        }

        public ICommand Submit
        {
            get;
        }

        public ICommand Navigate
        {
            get;
        }

        void ExecuteNavigate()
        {
            MessageBox.Show(Selector);
        }

        void ExecuteSubmit()
        {
            MessageBox.Show(Username + Password);
        }
    }
}
