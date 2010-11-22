using System.Collections.Generic;
using MefContrib.Samples.ExtensibleDashboard.Contracts;

namespace MefContrib.Samples.ExtensibleDashboard.Views.Presenters
{
    public class ShellPresentationModel
    {
        private IShellView m_View;

        public IShellView View
        {
            get { return m_View; }
            set
            {
                m_View = value;
                m_View.PresentationModel = this;
            }
        }

        public IEnumerable<IWidget> Widgets { get; private set; }

        public void Run()
        {
            m_View.Show();
        }

        public string DisplayName { get { return "Extensible Dashboard v1.0"; } }
    }
}