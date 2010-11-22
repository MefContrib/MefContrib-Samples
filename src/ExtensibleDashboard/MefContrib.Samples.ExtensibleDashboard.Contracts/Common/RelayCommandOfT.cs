namespace MefContrib.Samples.ExtensibleDashboard.Contracts.Common
{
    using System;
    using System.Windows.Input;

    public sealed class RelayCommand<T> : ICommand
    {
        #region Declarations

        private readonly Predicate<T> m_CanExecuteMethod;
        private readonly Action<T> m_ExecuteMethod;

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

        #region Constructors

        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod)
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

            return m_CanExecuteMethod((T)parameter);
        }

        public void Execute(object parameter)
        {
            m_ExecuteMethod((T)parameter);
        }

        #endregion
    }
}