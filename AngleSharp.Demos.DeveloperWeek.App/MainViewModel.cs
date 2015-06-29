using AngleSharp.Demos.DeveloperWeek.Samples;
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
        WebsiteAccessor _accessor;
        String _content;
        String _address;
        String _userName;
        String _password;
        String _selector;
        Boolean _loading;

        public MainViewModel()
        {
            Submit = new RelayCommand(ExecuteSubmit);
            Navigate = new RelayCommand(ExecuteNavigate);
            Everything = new RelayCommand(ExecuteEverything);
            IsLoading = true;
            WebsiteAccessor.CreateAsync("http://localhost:54361").ContinueWith(m =>
            {
                _accessor = m.Result;
                Update();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public Boolean IsLoading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                Submit.IsEnabled = !value;
                Navigate.IsEnabled = !value;
                TriggerChanged();
            }
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

        public RelayCommand Submit
        {
            get;
        }

        public RelayCommand Navigate
        {
            get;
        }

        public RelayCommand Everything
        {
            get;
        }

        void Update()
        {
            IsLoading = false;
            Content = _accessor.CurrentSource;
            Address = _accessor.CurrentUrl;
        }

        async void ExecuteNavigate()
        {
            IsLoading = true;
            await _accessor.NavigateToLink(_selector);
            Update();
        }

        async void ExecuteSubmit()
        {
            IsLoading = true;
            await _accessor.SubmitForm(new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase)
            {
                ["user"] = _userName,
                ["password"] = _password
            });
            Update();
        }

        async void ExecuteEverything()
        {
            IsLoading = true;
            await _accessor.NavigateToLink(".log-in");
            await _accessor.SubmitForm(new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase)
            {
                ["user"] = "User",
                ["password"] = "secret"
            });
            await _accessor.NavigateToLink(".secret-link");
            Update();
            var secret = _accessor.GetTextOf("#secret");
            MessageBox.Show($"The secret is {secret}.");
        }
    }
}
