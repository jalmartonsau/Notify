using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Notify
{
	public class DelegateCommand : ICommand
	{
		private Action _Execute;
		private Func<bool> _CanExecute;

		public DelegateCommand(Action execute, Func<bool> canExecute = null)
		{
			_Execute = execute;
			_CanExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (_CanExecute != null)
				return _CanExecute();
			return _Execute != null;
		}

		public void Execute(object parameter)
		{
			if (_Execute != null)
				_Execute();
		}

		event EventHandler ICommand.CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}
