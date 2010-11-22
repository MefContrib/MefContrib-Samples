namespace MefContrib.Samples.ExtensibleDashboard.Contracts.Common
{
    using System;
    using System.Windows.Input;
    
    public sealed class RelayCommand : ICommand
    {
        #region Declarations

        private readonly Predicate<object> m_CanExecuteMethod;
        private readonly Action<object> m_ExecuteMethod;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (m_CanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (m_CanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        #endregion

        #region Constructor

        public RelayCommand(Action<object> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {

            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod", "Delegate comamnds can not be null");
            }

            m_ExecuteMethod = executeMethod;
            m_CanExecuteMethod = canExecuteMethod;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (m_CanExecuteMethod == null)
            {
                return true;
            }

            return m_CanExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            if (m_ExecuteMethod == null)
            {
                return;
            }

            m_ExecuteMethod(parameter);
        }

        #endregion
    }
}