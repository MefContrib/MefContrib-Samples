namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.ViewModels
{
    using System;
    using MefContrib.Samples.ExtensibleDashboard.Contracts.Common;

    public class Tweet : BindableBase
    {
        private string m_UserName;
        public string UserName
        {
            get { return m_UserName; }
            set
            {
                m_UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        private DateTime m_Date;
        public DateTime Date
        {
            get { return m_Date; }
            set
            {
                m_Date = value;
                OnPropertyChanged("Date");
            }
        }

        private string m_ProgramName;
        public string ProgramName
        {
            get { return m_ProgramName; }
            set
            {
                m_ProgramName = value;
                OnPropertyChanged("ProgramName");
            }
        }

        private string m_Message;
        public string Message
        {
            get { return m_Message; }
            set
            {
                m_Message = value;
                OnPropertyChanged("Message");
            }
        }
    }
}