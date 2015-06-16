namespace AngleSharp.Demos.DeveloperWeek
{
    using System;
    using System.Windows.Input;

    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Boolean _enabled;
        Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
            _enabled = true;
        }

        public Boolean IsEnabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Boolean CanExecute(Object parameter)
        {
            return _enabled;
        }

        public void Execute(Object parameter)
        {
            if (_enabled)
                _action();
        }
    }
}
