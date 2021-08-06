using System;
using System.Windows.Input;

namespace SystemHelpers
{
    class CommandBuilder
    {
        class Command : ICommand
        {
            public event EventHandler CanExecuteChanged;
            internal Func<object, bool> _canExectue;
            internal Action<object> _execute;
            public bool CanExecute(object parameter) => _canExectue?.Invoke(parameter) ?? true;

            public void Execute(object parameter) => _execute.Invoke(parameter);
        }
        public CommandBuilder Create(Action<object> execute) => new(execute); 
        public CommandBuilder CanExecute(Func<object, bool> canExecute)
        {
            _command._canExectue = canExecute;
            return this;
        }
        private Command _command = new();
        private CommandBuilder(Action<object> execute) { _command._execute = execute; }
        public ICommand Build()
        {
            return _command;
            _command = null;
        }

    }
    
}
